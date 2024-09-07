using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Infrustructure.Base;
using RoshettaProAPI.Service.Base;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service;

public class PatientService : GenericService<Patient>, IPatientService
{
    public PatientService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    // Implement any Medication-specific methods here
}