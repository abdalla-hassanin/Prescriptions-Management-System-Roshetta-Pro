using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.Logout;

public class LogoutHandler : IRequestHandler<LogoutCommand, ApiResponse<string>>
{
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;


    public LogoutHandler(IMapper mapper,
        ApiResponseHandler responseHandler, UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager, IConfiguration configuration)
    {
        _mapper = mapper;
        _responseHandler = responseHandler;
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }


    public async Task<ApiResponse<string>> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var userClaim = _signInManager.Context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
        var email = userClaim?.Value;
        if (string.IsNullOrEmpty(email))
            return _responseHandler.BadRequest<string>("No user is currently logged in.");

        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return _responseHandler.NotFound<string>("User not found.");

        // Check if refresh token exists in AspNetUserTokens
        var refreshToken = await _userManager.GetAuthenticationTokenAsync(user, "MyApp", "RefreshToken");
        if (string.IsNullOrEmpty(refreshToken))
        {
            // Return response indicating the user is not logged in if no refresh token exists
            return _responseHandler.BadRequest<string>("User is not logged in.");
        }

        // Remove refresh token from AspNetUserTokens
        await _userManager.RemoveAuthenticationTokenAsync(user, "MyApp", "RefreshToken");

        // Optionally, remove JWT token if stored in AspNetUserTokens
        var jwtToken = await _userManager.GetAuthenticationTokenAsync(user, "MyApp", "JwtToken");
        if (!string.IsNullOrEmpty(jwtToken))
        {
            await _userManager.RemoveAuthenticationTokenAsync(user, "MyApp", "JwtToken");
        }

        // Sign out the user
        await _signInManager.SignOutAsync();

        // Return success response
        return _responseHandler.Success<string>("Logout successful.");
    }
}