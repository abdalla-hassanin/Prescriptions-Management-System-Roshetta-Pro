using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Data.Entities.Auth;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ResendEmailConfirmation;

public class ResendEmailConfirmationHandler : IRequestHandler<ResendEmailConfirmationCommand, ApiResponse<string>>
{
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;

    public ResendEmailConfirmationHandler(IMapper mapper,
        ApiResponseHandler responseHandler, UserManager<IdentityUser> userManager, IConfiguration configuration,
        IEmailService emailService)
    {
        _mapper = mapper;
        _responseHandler = responseHandler;
        _userManager = userManager;
        _configuration = configuration;
        _emailService = emailService;
    }

    public async Task<ApiResponse<string>> Handle(ResendEmailConfirmationCommand request,
        CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null || user.EmailConfirmed)
            return _responseHandler.BadRequest<string>("Invalid email or email already confirmed.");

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var confirmationLink = GenerateEmailConfirmationLink(user.Id, token);

        await _emailService.SendAsync(new EmailModel
        {
            To = user.Email!,
            Subject = "Email Confirmation",
            Body = $"Please confirm your email by clicking here: {confirmationLink}"
        });
        return _responseHandler.Success("Email confirmation link sent. Please check your email.");
    }

    private string GenerateEmailConfirmationLink(string userId, string token)
    {
        var baseUrl = _configuration["AppUrl"];
        var encodedToken = Uri.EscapeDataString(token); // Encode the token
        return $"{baseUrl}/api/auth/confirm-email?userId={userId}&token={encodedToken}";
    }
}