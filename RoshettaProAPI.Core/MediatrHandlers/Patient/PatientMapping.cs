using AutoMapper;
using RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Create;
using RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.Update;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient;

public class PatientMapping : Profile
{
    public PatientMapping()
    {
        CreateMap<CreatePatientCommand, Data.Entities.Patient>()
            .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<UpdatePatientCommand, Data.Entities.Patient>()
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => 
                srcMember != null && 
                (!srcMember.GetType().Equals(typeof(string)) || !string.IsNullOrWhiteSpace((string)srcMember))));

        CreateMap<Data.Entities.Patient, PatientResponse>();
    }
}