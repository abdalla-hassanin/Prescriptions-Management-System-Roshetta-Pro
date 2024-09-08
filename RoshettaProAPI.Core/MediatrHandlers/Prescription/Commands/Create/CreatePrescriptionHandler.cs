using AutoMapper;
using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Prescription.Commands.Create;
public class CreatePrescriptionHandler : IRequestHandler<CreatePrescriptionCommand, ApiResponse<PrescriptionResponse>>
{
    private readonly IPrescriptionService _prescriptionService;
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;

    public CreatePrescriptionHandler(IPrescriptionService prescriptionService, IMapper mapper, ApiResponseHandler responseHandler)
    {
        _prescriptionService = prescriptionService;
        _mapper = mapper;
        _responseHandler = responseHandler;
    }

    public async Task<ApiResponse<PrescriptionResponse>> Handle(CreatePrescriptionCommand request, CancellationToken cancellationToken)
    {
        var prescription = _mapper.Map<Data.Entities.Prescription>(request);
        await _prescriptionService.AddAsync(prescription, cancellationToken);
        var prescriptionResponse = _mapper.Map<PrescriptionResponse>(prescription);
        return _responseHandler.Created(prescriptionResponse);
    }
}
