// using AutoMapper;
// using MediatR;
// using RoshettaProAPI.Core.Base.ApiResponse;
// using RoshettaProAPI.Core.MediatrHandlers.Clinic.Queries.RequestModels;
// using RoshettaProAPI.Core.MediatrHandlers.Clinic.Queries.Response;
// using RoshettaProAPI.Service.IService;
//
// namespace RoshettaProAPI.Core.MediatrHandlers.Clinic.Queries.Handler
// {
//     public class GetClinicByIdQueryHandler : IRequestHandler<GetClinicByIdQuery, ApiResponse<ClinicResponseDto>>
//     {
//         private readonly IClinicService _clinicService;
//         private readonly IMapper _mapper;
//         private readonly ApiResponseHandler _responseHandler;
//
//         public GetClinicByIdQueryHandler(IClinicService clinicService, IMapper mapper, ApiResponseHandler responseHandler)
//         {
//             _clinicService = clinicService;
//             _mapper = mapper;
//             _responseHandler = responseHandler;
//         }
//
//         public async Task<ApiResponse<ClinicResponseDto>> Handle(GetClinicByIdQuery request, CancellationToken cancellationToken)
//         {
//             var clinic = await _clinicService.GetByIdAsync(request.ClinicID, cancellationToken);
//             if (clinic == null)
//             {
//                 return _responseHandler.NotFound<ClinicResponseDto>("Clinic not found.");
//             }
//
//             var clinicDto = _mapper.Map<ClinicResponseDto>(clinic);
//             return _responseHandler.Success(clinicDto);
//         }
//     }
// }