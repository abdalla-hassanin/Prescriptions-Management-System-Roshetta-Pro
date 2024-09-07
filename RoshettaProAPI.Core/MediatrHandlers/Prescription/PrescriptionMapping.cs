using AutoMapper;
using RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Create;
using RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Update;
using RoshettaProAPI.Data.Entities;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription;

public class PrescriptionMapping : Profile
{
    public PrescriptionMapping()
    {
        CreateMap<CreatePrescriptionCommand, Data.Entities.Prescription>()
            .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<UpdatePrescriptionCommand, Data.Entities.Prescription>()
            .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                srcMember != null &&
                (!srcMember.GetType().Equals(typeof(string)) || !string.IsNullOrWhiteSpace((string)srcMember))));

        CreateMap<Data.Entities.Prescription, PrescriptionResponse>();
        CreateMap<PrescriptionMedication, PrescriptionMedicationDto>().ReverseMap();
        CreateMap<PrescriptionMedication, PrescriptionMedicationResponse >().ReverseMap();
    }
}
