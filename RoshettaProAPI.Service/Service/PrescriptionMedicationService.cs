using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class PrescriptionMedicationService : GenericService<PrescriptionMedication>, IPrescriptionMedicationService
{
    public PrescriptionMedicationService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // Implement any PrescriptionMedication-specific methods here
}
