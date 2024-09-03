using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class GenderService : GenericService<Gender>, IGenderService
{
    public GenderService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // Implement any Gender-specific methods here
}
