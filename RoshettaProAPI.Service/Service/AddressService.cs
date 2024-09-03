using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class AddressService : GenericService<Address>, IAddressService
{
    public AddressService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // Implement any Address-specific methods here
}
