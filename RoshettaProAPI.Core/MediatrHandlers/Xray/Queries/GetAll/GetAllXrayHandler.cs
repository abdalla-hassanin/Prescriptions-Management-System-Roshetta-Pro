using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Xray.Queries.GetAll
{
    public class
        GetAllXrayHandler : IRequestHandler<GetAllXrayQuery,
        ApiResponse<IEnumerable<XrayResponse>>>
    {
        private readonly IXrayService _xrayService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public GetAllXrayHandler(IXrayService xrayService, IMapper mapper,
            ApiResponseHandler responseHandler)
        {
            _xrayService = xrayService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<IEnumerable<XrayResponse>>> Handle(GetAllXrayQuery request,
            CancellationToken cancellationToken)
        {
            var xrays = await _xrayService.GetAllAsync(cancellationToken);

            var xrayResponses = _mapper.Map<IEnumerable<XrayResponse>>(xrays);
            return _responseHandler.Success(xrayResponses);
        }
    }
}