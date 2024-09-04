using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Clinic.Commands.RequestModels;
using RoshettaProAPI.Core.MediatrHandlers.Clinic.Queries.Response;
using RoshettaProAPI.Data.Entities;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Clinic.Commands.Handler
{
    public class UpdateClinicCommandHandler : IRequestHandler<UpdateClinicCommand, ApiResponse<ClinicResponseDto>>
    {
        private readonly IClinicService _clinicService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public UpdateClinicCommandHandler(IClinicService clinicService, IMapper mapper, ApiResponseHandler responseHandler)
        {
            _clinicService = clinicService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<ClinicResponseDto>> Handle(UpdateClinicCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the existing clinic entity
            var clinic = await _clinicService.GetByIdAsync(request.ClinicID, cancellationToken);
            if (clinic == null)
            {
                return _responseHandler.NotFound<ClinicResponseDto>("Clinic not found.");
            }

            // Map the updated values from the request to the existing clinic entity
            _mapper.Map(request, clinic);
            
            // Save the updated clinic entity
            await _clinicService.UpdateAsync(clinic, cancellationToken);

            // Map the updated clinic entity to the response DTO
            var clinicDto = _mapper.Map<ClinicResponseDto>(clinic);
            return _responseHandler.Success(clinicDto, "Clinic updated successfully.");
        }
    }
}