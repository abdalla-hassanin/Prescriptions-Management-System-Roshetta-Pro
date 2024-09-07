using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Delete
{
    public class DeleteXrayHandler : IRequestHandler<DeleteXrayCommand, ApiResponse<XrayResponse>>
    {
        private readonly IXrayService _xrayService;
        private readonly ApiResponseHandler _responseHandler;

        public DeleteXrayHandler(IXrayService xrayService, ApiResponseHandler responseHandler)
        {
            _xrayService = xrayService;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<XrayResponse>> Handle(DeleteXrayCommand request, CancellationToken cancellationToken)
        {
            var xray = await _xrayService.GetByIdAsync(request.XrayID, cancellationToken);
            if (xray == null)
            {
                return _responseHandler.NotFound<XrayResponse>("Xray not found.");
            }

            await _xrayService.RemoveAsync(xray, cancellationToken);
            return _responseHandler.Deleted<XrayResponse>("Xray deleted successfully.");
        }
    }
}