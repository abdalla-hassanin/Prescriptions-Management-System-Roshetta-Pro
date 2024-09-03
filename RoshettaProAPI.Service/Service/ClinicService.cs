using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class ClinicService : GenericService<Clinic>, IClinicService
{
    public ClinicService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // Implement any Clinic-specific methods here
}
