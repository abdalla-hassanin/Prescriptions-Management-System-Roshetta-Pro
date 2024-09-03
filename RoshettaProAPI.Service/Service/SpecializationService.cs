using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class SpecializationService : GenericService<Specialization>, ISpecializationService
{
    public SpecializationService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // Implement any Specialization-specific methods here
}
