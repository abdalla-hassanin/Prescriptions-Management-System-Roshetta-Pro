using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Queries.ConfirmEmail;

public class ConfirmEmailHandler : IRequestHandler<ConfirmEmailQuery, ApiResponse<string>>
{
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;
    private readonly UserManager<IdentityUser> _userManager;

    public ConfirmEmailHandler( IMapper mapper,
        ApiResponseHandler responseHandler,UserManager<IdentityUser> userManager)
    {
        
        _mapper = mapper;
        _responseHandler = responseHandler;
        _userManager = userManager;

    }

    public async Task<ApiResponse<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
            return _responseHandler.NotFound<string>("Invalid user ID.");
        
        var decodedToken = Uri.UnescapeDataString(request.Token); // Properly decode the token
        var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
        if (!result.Succeeded)
            return _responseHandler.BadRequest<string>("Email confirmation failed.");
       
        return _responseHandler.Success("Email confirmed successfully.");
    }
}