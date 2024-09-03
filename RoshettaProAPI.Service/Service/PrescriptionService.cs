using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class PrescriptionService : GenericService<Prescription>, IPrescriptionService
{
    public PrescriptionService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // Implement any Prescription-specific methods here
}
