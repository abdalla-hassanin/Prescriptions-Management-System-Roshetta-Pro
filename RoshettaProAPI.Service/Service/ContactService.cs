using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class ContactService : GenericService<Contact>, IContactService
{
    public ContactService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // Implement any Contact-specific methods here
}
