using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class PatientXrayService : GenericService<PatientXray>, IPatientXrayService
{
    public PatientXrayService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // Implement any PatientXray-specific methods here
}
