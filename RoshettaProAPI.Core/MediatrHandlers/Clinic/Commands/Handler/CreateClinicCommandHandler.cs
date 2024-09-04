// using AutoMapper;
// using MediatR;
// using RoshettaProAPI.Core.Base.ApiResponse;
// using RoshettaProAPI.Core.MediatrHandlers.Clinic.Commands.RequestModels;
// using RoshettaProAPI.Core.MediatrHandlers.Clinic.Queries.Response;
// using RoshettaProAPI.Service.IService;
//
// namespace RoshettaProAPI.Core.MediatrHandlers.Clinic.Commands.Handler
// {
//     public class CreateClinicCommandHandler : IRequestHandler<CreateClinicCommand, ApiResponse<ClinicResponseDto>>
//     {
//         private readonly IClinicService _clinicService;
//         private readonly IMapper _mapper;
//         private readonly ApiResponseHandler _responseHandler;
//
//         public CreateClinicCommandHandler(IClinicService clinicService, IMapper mapper, ApiResponseHandler responseHandler)
//         {
//             _clinicService = clinicService;
//             _mapper = mapper;
//             _responseHandler = responseHandler;
//         }
//
//         public async Task<ApiResponse<ClinicResponseDto>> Handle(CreateClinicCommand request, CancellationToken cancellationToken)
//         {
//             var clinic = _mapper.Map<Data.Entities.Clinic>(request);
//
//             await _clinicService.AddAsync(clinic, cancellationToken);
//
//             var clinicDto = _mapper.Map<ClinicResponseDto>(clinic);
//             return _responseHandler.Created(clinicDto);
//         }
//     }
// }