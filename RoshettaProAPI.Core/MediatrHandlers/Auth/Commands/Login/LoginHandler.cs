using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.Login;

public class LoginHandler : IRequestHandler<LoginCommand, ApiResponse<string>>
{
    private readonly ApiResponseHandler _responseHandler;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;


    public LoginHandler(
        ApiResponseHandler responseHandler, UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager, IConfiguration configuration)
    {
        _responseHandler = responseHandler;
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<ApiResponse<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return _responseHandler.BadRequest<string>("Invalid email or password.");

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        var isSignedInSuccess = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
        if (!isPasswordValid && !isSignedInSuccess.Succeeded)
            return _responseHandler.BadRequest<string>("Invalid email or password.");

        if (!await _userManager.IsEmailConfirmedAsync(user))
            return _responseHandler.BadRequest<string>("Email not confirmed.");

        // Check if the user already has an active refresh token
        var existingJwtToken = await _userManager.GetAuthenticationTokenAsync(user, "MyApp", "JwtToken");
        if (!string.IsNullOrEmpty(existingJwtToken))
            return _responseHandler.Success(existingJwtToken, "User is already logged in.");

        // Generate JWT token and refresh token
        var jwtToken = GenerateJwtToken(user,_userManager.GetRolesAsync(user).Result.FirstOrDefault()!); // Assuming you have a JWT service
        var refreshToken = GenerateRefreshToken(jwtToken); // Generate refresh token
        
        // Save the refresh token in AspNetUserTokens table
        await _userManager.SetAuthenticationTokenAsync(user, "MyApp", "RefreshToken", refreshToken.Token);
        // Save the JWT token in AspNetUserTokens table (optional if needed)
        await _userManager.SetAuthenticationTokenAsync(user, "MyApp", "JwtToken", jwtToken);

        return _responseHandler.Success(jwtToken, "User logged in successfully.");
    }

    private string GenerateJwtToken(IdentityUser user, string role)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.UserName!),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Name, user.UserName!),
            new(ClaimTypes.Role, role)
        };


        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(5), // Token validity period
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private Data.Entities.Auth.RefreshToken GenerateRefreshToken(string jwtToken)
    {
        return new Data.Entities.Auth.RefreshToken
        {
            Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
            JwtToken = jwtToken, // Store the generated JWT token
            ExpiresOn = DateTime.UtcNow.AddDays(7), // Refresh token validity period
            CreatedOn = DateTime.UtcNow
        };
    }
}

