using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class MedicationService : GenericService<Medication>, IMedicationService
{
    public MedicationService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // Implement any Medication-specific methods here
}