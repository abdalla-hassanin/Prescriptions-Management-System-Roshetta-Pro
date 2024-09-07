using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Create
{
    public class CreateXrayHandler : IRequestHandler<CreateXrayCommand, ApiResponse<XrayResponse>>
    {
        private readonly IXrayService _xrayService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public CreateXrayHandler(IXrayService xrayService, IMapper mapper, ApiResponseHandler responseHandler)
        {
            _xrayService = xrayService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<XrayResponse>> Handle(CreateXrayCommand request,
            CancellationToken cancellationToken)
        {
            var xray = _mapper.Map<Data.Entities.Xray>(request);

            await _xrayService.AddAsync(xray, cancellationToken);

            var xrayResponse = _mapper.Map<XrayResponse>(xray);
            return _responseHandler.Created(xrayResponse);
        }
    }
}