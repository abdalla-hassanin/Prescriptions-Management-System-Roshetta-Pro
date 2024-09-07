using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Commands.Create
{
    public class CreateMedicalHistoryHandler : IRequestHandler<CreateMedicalHistoryCommand, ApiResponse<MedicalHistoryResponse>>
    {
        private readonly IMedicalHistoryService _medicalHistoryService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public CreateMedicalHistoryHandler(IMedicalHistoryService medicalHistoryService, IMapper mapper, ApiResponseHandler responseHandler)
        {
            _medicalHistoryService = medicalHistoryService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<MedicalHistoryResponse>> Handle(CreateMedicalHistoryCommand request, CancellationToken cancellationToken)
        {
            var medicalHistory = _mapper.Map<Data.Entities.MedicalHistory>(request);

            await _medicalHistoryService.AddAsync(medicalHistory, cancellationToken);

            var medicalHistoryResponse = _mapper.Map<MedicalHistoryResponse>(medicalHistory);
            return _responseHandler.Created(medicalHistoryResponse);
        }
    }
}