using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class BloodTypeService : GenericService<BloodType>, IBloodTypeService
{
    public BloodTypeService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // Implement any BloodType-specific methods here
}
