using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class PrescriptionService : GenericService<Prescription>, IPrescriptionService
{
    private readonly IUnitOfWork _unitOfWork;

    public PrescriptionService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // Add a new Prescription with its medications in a transaction
    public override async Task AddAsync(Prescription prescription, CancellationToken cancellationToken = default)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            if (prescription.PrescriptionMedications.Any())
            {
                foreach (var medication in prescription.PrescriptionMedications)
                {
                    await _unitOfWork.Repository<PrescriptionMedication>().AddAsync(medication, cancellationToken);
                }
            }

            await base.AddAsync(prescription, cancellationToken); // Save prescription using base method
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw; // Re-throw the caught exception
        }
    }


    // Update Prescription and its medications in a transaction
    public override async Task UpdateAsync(Prescription prescription, CancellationToken cancellationToken = default)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            await RemoveObsoleteMedicationsAsync(prescription, cancellationToken);
            await AddOrUpdateMedicationsAsync(prescription.PrescriptionMedications, cancellationToken);

            await base.UpdateAsync(prescription, cancellationToken); // Save prescription using base method
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw; // Re-throw the caught exception
        }
    }


    // Remove Prescription and cascade delete its medications
    public override async Task RemoveAsync(Prescription prescription, CancellationToken cancellationToken = default)
    {
        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            var prescriptionMedications = await _unitOfWork.Repository<PrescriptionMedication>()
                .FindAsync(pm => pm.PrescriptionID == prescription.PrescriptionID,
                    cancellationToken: cancellationToken);

            await _unitOfWork.Repository<PrescriptionMedication>()
                .RemoveMultipleAsync(prescriptionMedications, cancellationToken);

            await base.RemoveAsync(prescription, cancellationToken); // Remove the prescription
            await _unitOfWork.CommitTransactionAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            throw; // Re-throw the caught exception
        }
    }

    // Override GetByIdAsync to include PrescriptionMedications
    public override async Task<Prescription> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var prescription = _unitOfWork.Repository<Prescription>()
            .Find(
                p => p.PrescriptionID == id,
                include: query => query
                    .Include(p => p.PrescriptionMedications)
                    .ThenInclude(pm => pm.Medication) // Include Medication if needed
                    .Include(p => p.Patient) // Include Patient
                    .Include(p => p.Doctor) // Include Doctor
            );
        return (await prescription.FirstOrDefaultAsync(cancellationToken))!;
    }

    public override async Task<IEnumerable<Prescription>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var prescription = await _unitOfWork.Repository<Prescription>()
            .FindAsync(
                p => true,
                include: query => query
                    .Include(p => p.PrescriptionMedications)
                    .ThenInclude(pm => pm.Medication) // Include Medication if needed
                    .Include(p => p.Patient) // Include Patient
                    .Include(p => p.Doctor), // Include Doctor
                cancellationToken: cancellationToken);
        return prescription;
    }

    // Get all Prescriptions (with optional eager loading and pagination)
    public override async Task<(IEnumerable<Prescription> Items, int TotalCount)> GetPagedAsync(
        Expression<Func<Prescription, bool>> predicate, int pageNumber, int pageSize,
        Func<IQueryable<Prescription>, IOrderedQueryable<Prescription>> orderBy = null,
        Func<IQueryable<Prescription>, IIncludableQueryable<Prescription, object>> include = null,
        CancellationToken cancellationToken = default)
    {
        var result = await _unitOfWork.Repository<Prescription>()
            .GetPagedAsync(predicate != null ? predicate : p => true,
                pageNumber,
                pageSize,
                query => query.OrderBy(p => p.DateIssued),
                include != null
                    ? include
                    : query => query
                        .Include(p => p.PrescriptionMedications)
                        .ThenInclude(pm => pm.Medication)
                        .Include(p => p.Patient)
                        .Include(p => p.Doctor),
                cancellationToken);
        return (result.Items, result.TotalCount);
    }

    // Handle upsert logic for PrescriptionMedications
    private async Task AddOrUpdateMedicationsAsync(IEnumerable<PrescriptionMedication> medications,
        CancellationToken cancellationToken)
    {
        foreach (var medication in medications)
        {
            if (medication.PrescriptionMedicationID == 0)
            {
                await _unitOfWork.Repository<PrescriptionMedication>().AddAsync(medication, cancellationToken);
            }
            else
            {
                await _unitOfWork.Repository<PrescriptionMedication>().UpdateAsync(medication, cancellationToken);
            }
        }
    }

    // Remove medications that are no longer in the updated Prescription
    private async Task RemoveObsoleteMedicationsAsync(Prescription prescription, CancellationToken cancellationToken)
    {
        var existingMedications = await _unitOfWork.Repository<PrescriptionMedication>()
            .FindAsync(pm => pm.PrescriptionID == prescription.PrescriptionID, cancellationToken: cancellationToken);

        foreach (var existingMedication in existingMedications)
        {
            if (prescription.PrescriptionMedications.All(pm =>
                    pm.PrescriptionMedicationID != existingMedication.PrescriptionMedicationID))
            {
                await _unitOfWork.Repository<PrescriptionMedication>()
                    .RemoveAsync(existingMedication, cancellationToken);
            }
        }
    }
}