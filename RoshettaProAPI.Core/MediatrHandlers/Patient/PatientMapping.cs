using AutoMapper;
using RoshettaProAPI.Core.MediatrHandlers.Patient.Commands.RequestModels;

namespace RoshettaProAPI.Core.MediatrHandlers.Patient;

public class PatientMapping : Profile
{
    public PatientMapping()
    {
        CreateMap<CreatePatientCommand, PatientResponse>()
            .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<UpdatePatientCommand, PatientResponse>()
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => 
                srcMember != null && 
                (!srcMember.GetType().Equals(typeof(string)) || !string.IsNullOrWhiteSpace((string)srcMember))));

        CreateMap<Data.Entities.Patient, PatientResponse>();
    }
}