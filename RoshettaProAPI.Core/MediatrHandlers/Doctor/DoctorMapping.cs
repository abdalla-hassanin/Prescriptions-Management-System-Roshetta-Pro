using AutoMapper;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.Create;
using RoshettaProAPI.Core.MediatrHandlers.Doctor.Commands.Update;

namespace RoshettaProAPI.Core.MediatrHandlers.Doctor;

public class DoctorMapping : Profile
{
    public DoctorMapping()
    {
        CreateMap<CreateDoctorCommand, Data.Entities.Doctor>()
            .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<UpdateDoctorCommand, Data.Entities.Doctor>()
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => 
                srcMember != null && 
                (!srcMember.GetType().Equals(typeof(string)) || !string.IsNullOrWhiteSpace((string)srcMember))));

        CreateMap<Data.Entities.Doctor, DoctorResponse>();
    }
}