using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.MedicalHistory.Queries.GetAll
{
    public class
        GetAllMedicalHistoryHandler : IRequestHandler<GetAllMedicalHistoryQuery,
        ApiResponse<IEnumerable<MedicalHistoryResponse>>>
    {
        private readonly IMedicalHistoryService _medicalHistoryService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public GetAllMedicalHistoryHandler(IMedicalHistoryService medicalHistoryService, IMapper mapper,
            ApiResponseHandler responseHandler)
        {
            _medicalHistoryService = medicalHistoryService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<IEnumerable<MedicalHistoryResponse>>> Handle(GetAllMedicalHistoryQuery request,
            CancellationToken cancellationToken)
        {
            var medicalHistorys = await _medicalHistoryService.GetAllAsync(cancellationToken);

            var medicalHistoryResponses = _mapper.Map<IEnumerable<MedicalHistoryResponse>>(medicalHistorys);
            return _responseHandler.Success(medicalHistoryResponses);
        }
    }
}