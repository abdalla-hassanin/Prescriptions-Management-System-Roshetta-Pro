using AutoMapper;
using RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Create;
using RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Update;

namespace RoshettaProAPI.Core.MediatrHandlers.Xray;

public class XrayMapping : Profile
{
    public XrayMapping()
    {
        CreateMap<CreateXrayCommand, XrayResponse>()
            .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<UpdateXrayCommand, XrayResponse>()
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                srcMember != null &&
                (!srcMember.GetType().Equals(typeof(string)) || !string.IsNullOrWhiteSpace((string)srcMember))));

        CreateMap<Data.Entities.Xray, XrayResponse>();
    }
}