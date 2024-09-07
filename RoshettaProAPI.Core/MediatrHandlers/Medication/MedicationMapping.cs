using AutoMapper;
using RoshettaProAPI.Core.MediatrHandlers.Medication.Commands.Create;
using RoshettaProAPI.Core.MediatrHandlers.Medication.Commands.Update;

namespace RoshettaProAPI.Core.MediatrHandlers.Medication;

public class MedicationMapping : Profile
{
    public MedicationMapping()
    {
        CreateMap<CreateMedicationCommand, MedicationResponse>()
            .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<UpdateMedicationCommand, MedicationResponse>()
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                srcMember != null &&
                (!srcMember.GetType().Equals(typeof(string)) || !string.IsNullOrWhiteSpace((string)srcMember))));

        CreateMap<Data.Entities.Medication, MedicationResponse>();
    }
}