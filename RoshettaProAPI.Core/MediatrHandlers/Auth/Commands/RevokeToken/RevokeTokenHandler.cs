using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.RevokeToken;

public class RevokeTokenHandler : IRequestHandler<RevokeTokenCommand, ApiResponse<string>>
{
    private readonly ApiResponseHandler _responseHandler;
    private readonly UserManager<IdentityUser> _userManager;


    public RevokeTokenHandler(
        ApiResponseHandler responseHandler, UserManager<IdentityUser> userManager
    )
    {
        _responseHandler = responseHandler;
        _userManager = userManager;
    }


    public async Task<ApiResponse<string>> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
    {
        // Find the user by refresh token from AspNetUserTokens
        var user = await _userManager.Users
            .SingleOrDefaultAsync(u =>
                _userManager.GetAuthenticationTokenAsync(u, "MyApp", "RefreshToken").Result == request.Token);

        if (user == null)
            return _responseHandler.BadRequest<string>("Invalid refresh token.");

        // Retrieve the existing refresh token
        var refreshToken = await _userManager.GetAuthenticationTokenAsync(user, "MyApp", "RefreshToken");

        // Check if refresh token is valid
        if (string.IsNullOrEmpty(refreshToken) || refreshToken != request.Token)
            return _responseHandler.BadRequest<string>("Invalid refresh token.");

        // Remove the refresh token from AspNetUserTokens
        await _userManager.RemoveAuthenticationTokenAsync(user, "MyApp", "RefreshToken");

        // Optionally, revoke JWT token as well
        var jwtToken = await _userManager.GetAuthenticationTokenAsync(user, "MyApp", "JwtToken");
        if (!string.IsNullOrEmpty(jwtToken))
        {
            await _userManager.RemoveAuthenticationTokenAsync(user, "MyApp", "JwtToken");
        }

        // Return success response
        return _responseHandler.Success<string>("Token revoked successfully.");
    }
}