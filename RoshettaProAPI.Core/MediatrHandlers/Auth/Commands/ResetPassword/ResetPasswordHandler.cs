using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RoshettaProAPI.Core.Base.ApiResponse;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ResetPassword;

public class ResetPasswordHandler: IRequestHandler<ResetPasswordCommand, ApiResponse<string>>
{
    private readonly IMapper _mapper;
    private readonly ApiResponseHandler _responseHandler;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;

    public ResetPasswordHandler(IMapper mapper,
        ApiResponseHandler responseHandler, UserManager<IdentityUser> userManager, IConfiguration configuration,
        IEmailService emailService)
    {
        _mapper = mapper;
        _responseHandler = responseHandler;
        _userManager = userManager;
        _configuration = configuration;
        _emailService = emailService;
    }


    public async Task<ApiResponse<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
            return _responseHandler.BadRequest<string>("Invalid user ID.");
      
        var decodedToken = Uri.UnescapeDataString(request.Token);
        var result = await _userManager.ResetPasswordAsync(user, decodedToken, request.NewPassword);
        if (!result.Succeeded)
            return _responseHandler.BadRequest<string>(string.Join(", ", result.Errors.Select(e => e.Description)));
        
        return _responseHandler.Success("Password has been reset successfully.");
        
    }
}
