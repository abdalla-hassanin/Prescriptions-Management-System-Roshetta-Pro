using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ChangePassword;

public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, ApiResponse<string>>
{
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public ChangePasswordHandler(IMapper mapper,
        ApiResponseHandler responseHandler, UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
    {
        _mapper = mapper;
        _responseHandler = responseHandler;
        _userManager = userManager;
        _signInManager = signInManager;
    }


    public async Task<ApiResponse<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        // Get the current user from the authentication context
        var userId = _userManager.GetUserId(_signInManager.Context.User);

        if (string.IsNullOrEmpty(userId))
            return _responseHandler.BadRequest<string>("No user is currently authenticated.");

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return _responseHandler.BadRequest<string>("Invalid user ID.");

        var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (!result.Succeeded)
            return _responseHandler.BadRequest<string>(string.Join(", ", result.Errors.Select(e => e.Description)));

        return _responseHandler.Success("Password has been changed successfully.");
    }
}