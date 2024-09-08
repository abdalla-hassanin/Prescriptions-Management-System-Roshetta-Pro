using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.RefreshToken;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.RevokeToken;

public class RefreshTokenHandler: IRequestHandler<RefreshTokenCommand, ApiResponse<string>>
{
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;


    public RefreshTokenHandler(IMapper mapper,
        ApiResponseHandler responseHandler, UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager, IConfiguration configuration)
    {
        _mapper = mapper;
        _responseHandler = responseHandler;
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }


    public async Task<ApiResponse<string>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        // Find the user by refresh token from AspNetUserTokens
        var user = await _userManager.Users
            .SingleOrDefaultAsync(u => _userManager.GetAuthenticationTokenAsync(u, "MyApp", "RefreshToken").Result == request.Token);
       
        if (user == null)
            return _responseHandler.BadRequest<string>("Invalid refresh token.");
        
        // Retrieve the existing refresh token
        var refreshToken = await _userManager.GetAuthenticationTokenAsync(user, "MyApp", "RefreshToken");

        // Check if refresh token is valid
        if (refreshToken != request.Token)
            return _responseHandler.BadRequest<string>("Invalid refresh token.");
        // Generate new JWT token
        var jwtToken = GenerateJwtToken(user, (await _userManager.GetRolesAsync(user)).FirstOrDefault()!);

        // Generate new refresh token
        var newRefreshToken = GenerateRefreshToken(jwtToken);

        // Store the new tokens in AspNetUserTokens
        await _userManager.SetAuthenticationTokenAsync(user, "MyApp", "JwtToken", jwtToken);
        await _userManager.SetAuthenticationTokenAsync(user, "MyApp", "RefreshToken", newRefreshToken.Token);

        // Return the new JWT token to the client
        return _responseHandler.Success(jwtToken, "Token refreshed successfully.");

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
            expires: DateTime.UtcNow.AddMinutes(30), // Token validity period
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
