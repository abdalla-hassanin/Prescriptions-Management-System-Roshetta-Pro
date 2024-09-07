using AutoMapper;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.RequestModels;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor;

public class DoctorMapping : Profile
{
    public DoctorMapping()
    {
        CreateMap<CreateDoctorCommand, DoctorResponse>()
            .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<UpdateDoctorCommand, DoctorResponse>()
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => 
                srcMember != null && 
                (!srcMember.GetType().Equals(typeof(string)) || !string.IsNullOrWhiteSpace((string)srcMember))));

        CreateMap<Data.Entities.Doctor, DoctorResponse>();
    }
}