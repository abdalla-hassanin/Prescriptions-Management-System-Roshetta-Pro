using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Data.Entities.Auth;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ForgetPassword;

public class ForgetPasswordHandler : IRequestHandler<ForgetPasswordCommand, ApiResponse<string>>
{
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;

    public ForgetPasswordHandler(IMapper mapper,
        ApiResponseHandler responseHandler, UserManager<IdentityUser> userManager, IConfiguration configuration,
        IEmailService emailService)
    {
        _mapper = mapper;
        _responseHandler = responseHandler;
        _userManager = userManager;
        _configuration = configuration;
        _emailService = emailService;
    }


    public async Task<ApiResponse<string>> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return _responseHandler.NotFound<string>("Email not registered.");
        
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var resetLink = GeneratePasswordResetLink(user.Id, token);
        
        await _emailService.SendAsync(new EmailModel
        {
            To = user.Email!,
            Subject = "Password Reset",
            Body = $"Please reset your password by clicking <a href='{resetLink}'>here</a>."
        });

        return _responseHandler.Success("Password reset link has been sent to your email.");
    }
    private string GeneratePasswordResetLink(string userId, string token)
    {
        var baseUrl = _configuration["AppUrl"];
        var encodedToken = Uri.EscapeDataString(token);
        return $"{baseUrl}/api/auth/reset-password?userId={userId}&token={encodedToken}";
    }

}

