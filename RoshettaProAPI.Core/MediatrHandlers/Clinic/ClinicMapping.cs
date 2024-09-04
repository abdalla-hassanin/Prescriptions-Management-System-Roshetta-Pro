// using AutoMapper;
// using RoshettaProAPI.Core.MediatrHandlers.Clinic.Commands.RequestModels;
// using RoshettaProAPI.Core.MediatrHandlers.Clinic.Queries.Response;
//
// namespace RoshettaProAPI.Core.MediatrHandlers.Clinic;
//
// public class ClinicMapping : Profile
// {
//     public ClinicMapping()
//     {
//         CreateMap<CreateClinicCommand, Data.Entities.Clinic>()
//             .ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
//             .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow));
//
//         CreateMap<UpdateClinicCommand, Data.Entities.Clinic>()
//             .ForMember(dest => dest.UpdatedTime, opt => opt.MapFrom(_ => DateTime.UtcNow))
//             .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => 
//                 srcMember != null && 
//                 (!srcMember.GetType().Equals(typeof(string)) || !string.IsNullOrWhiteSpace((string)srcMember))));
//
//         CreateMap<Data.Entities.Clinic, ClinicResponseDto>();
//     }
// }