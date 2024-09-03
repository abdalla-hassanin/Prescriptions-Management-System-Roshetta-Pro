using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class MedicalHistoryService : GenericService<MedicalHistory>, IMedicalHistoryService
{
    public MedicalHistoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // Implement any MedicalHistory-specific methods here
}
