using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Xray.Queries.GetById
{
    public class GetXrayByIdHandler : IRequestHandler<GetXrayByIdQuery, ApiResponse<XrayResponse>>
    {
        private readonly IXrayService _xrayService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public GetXrayByIdHandler(IXrayService xrayService, IMapper mapper,
            ApiResponseHandler responseHandler)
        {
            _xrayService = xrayService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<XrayResponse>> Handle(GetXrayByIdQuery request,
            CancellationToken cancellationToken)
        {
            var xray = await _xrayService.GetByIdAsync(request.XrayID, cancellationToken);
            if (xray == null)
            {
                return _responseHandler.NotFound<XrayResponse>("Medication not found.");
            }

            var xrayResponse = _mapper.Map<XrayResponse>(xray);
            return _responseHandler.Success(xrayResponse);
        }
    }
}