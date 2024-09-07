using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Queries.GetById
{
    public class GetMedicalHistoryByIdHandler : IRequestHandler<GetMedicalHistoryByIdQuery, ApiResponse<MedicalHistoryResponse>>
    {
        private readonly IMedicalHistoryService _medicalHistoryService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public GetMedicalHistoryByIdHandler(IMedicalHistoryService medicalHistoryService, IMapper mapper,
            ApiResponseHandler responseHandler)
        {
            _medicalHistoryService = medicalHistoryService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<MedicalHistoryResponse>> Handle(GetMedicalHistoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var medicalHistory = await _medicalHistoryService.GetByIdAsync(request.MedicalHistoryID, cancellationToken);
            if (medicalHistory == null)
            {
                return _responseHandler.NotFound<MedicalHistoryResponse>("Medication not found.");
            }

            var medicalHistoryResponse = _mapper.Map<MedicalHistoryResponse>(medicalHistory);
            return _responseHandler.Success(medicalHistoryResponse);
        }
    }
}