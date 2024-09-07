using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Xray.Commands.Update
{
    public class UpdateXrayHandler : IRequestHandler<UpdateXrayCommand, ApiResponse<XrayResponse>>
    {
        private readonly IXrayService _xrayService;
        private readonly IMapper _mapper;
        private readonly ApiResponseHandler _responseHandler;

        public UpdateXrayHandler(IXrayService xrayService, IMapper mapper, ApiResponseHandler responseHandler)
        {
            _xrayService = xrayService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<ApiResponse<XrayResponse>> Handle(UpdateXrayCommand request,
            CancellationToken cancellationToken)
        {
            // Retrieve the existing xray entity
            var xray = await _xrayService.GetByIdAsync(request.XrayID, cancellationToken);
            if (xray == null)
            {
                return _responseHandler.NotFound<XrayResponse>("Xray not found.");
            }

            // Map the updated values from the request to the existing xray entity
            _mapper.Map(request, xray);

            // Save the updated xray entity
            await _xrayService.UpdateAsync(xray, cancellationToken);

            var xrayResponse = _mapper.Map<XrayResponse>(xray);

            return _responseHandler.Success(xrayResponse, "Xray updated successfully.");
        }
    }
}