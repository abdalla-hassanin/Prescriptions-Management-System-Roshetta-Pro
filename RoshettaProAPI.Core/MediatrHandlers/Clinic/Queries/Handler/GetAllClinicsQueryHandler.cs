// using AutoMapper;
// using MediatR;
// using RoshettaProAPI.Core.Base.ApiResponse;
// using RoshettaProAPI.Core.MediatrHandlers.Clinic.Queries.RequestModels;
// using RoshettaProAPI.Core.MediatrHandlers.Clinic.Queries.Response;
// using RoshettaProAPI.Data.Entities;
// using RoshettaProAPI.Service.IService;
//
// namespace RoshettaProAPI.Core.MediatrHandlers.Clinic.Queries.Handler
// {
//     public class GetAllClinicsQueryHandler : IRequestHandler<GetAllClinicsQuery, ApiResponse<IEnumerable<ClinicResponseDto>>>
//     {
//         private readonly IClinicService _clinicService;
//         private readonly IMapper _mapper;
//         private readonly ApiResponseHandler _responseHandler;
//
//         public GetAllClinicsQueryHandler(IClinicService clinicService, IMapper mapper, ApiResponseHandler responseHandler)
//         {
//             _clinicService = clinicService;
//             _mapper = mapper;
//             _responseHandler = responseHandler;
//         }
//
//         public async Task<ApiResponse<IEnumerable<ClinicResponseDto>>> Handle(GetAllClinicsQuery request, CancellationToken cancellationToken)
//         {
//             var clinics = await _clinicService.GetAllAsync(cancellationToken);
//             var clinicDtos = _mapper.Map<IEnumerable<ClinicResponseDto>>(clinics);
//
//             return _responseHandler.Success(clinicDtos);
//         }
//     }
// }