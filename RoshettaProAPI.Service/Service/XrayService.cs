using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class XrayService : GenericService<Xray>, IXrayService
{
    public XrayService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // Implement any Medication-specific methods here
}
