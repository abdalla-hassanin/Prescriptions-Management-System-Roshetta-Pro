using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class DoctorService : GenericService<Doctor>, IDoctorService
{
    public DoctorService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // Implement any Doctor-specific methods here
}