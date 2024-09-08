using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoshettaProAPI.Api.Base;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ChangePassword;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ForgetPassword;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.Login;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.Logout;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.RefreshToken;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ResendEmailConfirmation;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ResetPassword;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.RevokeToken;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Queries.ConfirmEmail;

namespace RoshettaProAPI.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : AppControllerBase
    {
  

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var response = await Mediator.Send(new ConfirmEmailQuery(userId, token));
            return CreateResponse(response);
        }

        [HttpPost("resend-email-confirmation")]
        public async Task<IActionResult> ResendEmailConfirmation([FromBody] ResendEmailConfirmationCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }
        
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var response = await Mediator.Send(new LogoutCommand());
            return CreateResponse(response);
        }
        
        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }
        
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }
        
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }
        
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }
        
        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }
        
    }
}