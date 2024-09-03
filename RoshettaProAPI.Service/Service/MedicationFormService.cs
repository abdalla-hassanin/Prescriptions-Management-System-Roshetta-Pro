using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class MedicationFormService : GenericService<MedicationForm>, IMedicationFormService
{
    public MedicationFormService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // Implement any MedicationForm-specific methods here
}
