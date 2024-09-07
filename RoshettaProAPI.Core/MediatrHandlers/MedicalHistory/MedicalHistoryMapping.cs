using AutoMapper;
using RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Commands.Create;
using RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Commands.Update;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory;

public class MedicalHistoryMapping : Profile
{
    public MedicalHistoryMapping()
    {
        CreateMap<CreateMedicalHistoryCommand, MedicalHistoryResponse>()
            .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<UpdateMedicalHistoryCommand, MedicalHistoryResponse>()
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                srcMember != null &&
                (!srcMember.GetType().Equals(typeof(string)) || !string.IsNullOrWhiteSpace((string)srcMember))));

        CreateMap<Data.Entities.MedicalHistory, MedicalHistoryResponse>();
    }
}