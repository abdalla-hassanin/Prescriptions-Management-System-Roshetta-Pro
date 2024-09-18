using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoshettaProAPI.Api.Base;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ChangePassword;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ForgetPassword;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.Login;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.Logout;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.RefreshToken;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.RevokeToken;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ResetPassword;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Commands.ResendEmailConfirmation;
using RoshettaProAPI.Core.MediatrHandlers.Auth.Queries.ConfirmEmail;

namespace RoshettaProAPI.Api.Controllers
{
    /// <summary>
    /// Handles API endpoints related to user authentication and management.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : AppControllerBase
    {
        /// <summary>
        /// Confirms a user's email address.
        /// </summary>
        /// <remarks>
        /// This endpoint does not require any specific roles.
        /// </remarks>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="token">The confirmation token.</param>
        /// <returns>Confirmation of email address.</returns>
        /// <response code="200">Returns success message if the email is confirmed.</response>
        /// <response code="400">If the email confirmation fails.</response>
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var response = await Mediator.Send(new ConfirmEmailQuery(userId, token));
            return CreateResponse(response);
        }

        /// <summary>
        /// Resends the email confirmation link.
        /// </summary>
        /// <remarks>
        /// This endpoint does not require any specific roles.
        /// </remarks>
        /// <param name="command">The command containing user email.</param>
        /// <returns>Confirmation of the email confirmation resend.</returns>
        /// <response code="200">Returns success message if the email confirmation link is sent.</response>
        /// <response code="400">If the email is already confirmed or invalid.</response>
        [HttpPost("resend-email-confirmation")]
        public async Task<IActionResult> ResendEmailConfirmation([FromBody] ResendEmailConfirmationCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }

        /// <summary>
        /// Logs in a user and provides a JWT token.
        /// </summary>
        /// <remarks>
        /// This endpoint does not require any specific roles.
        /// </remarks>
        /// <param name="command">The command containing login credentials.</param>
        /// <returns>JWT token if login is successful.</returns>
        /// <response code="200">Returns JWT token if login is successful.</response>
        /// <response code="400">If the login credentials are invalid or email is not confirmed.</response>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }

        /// <summary>
        /// Logs out a user by removing their refresh token.
        /// </summary>
        /// <remarks>
        /// Requires the role <c>User</c>.
        /// </remarks>
        /// <returns>Confirmation of logout.</returns>
        /// <response code="200">Returns success message if logout is successful.</response>
        /// <response code="400">If no user is currently logged in.</response>
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var response = await Mediator.Send(new LogoutCommand());
            return CreateResponse(response);
        }

        /// <summary>
        /// Initiates a password reset process by sending a reset link to the user.
        /// </summary>
        /// <remarks>
        /// This endpoint does not require any specific roles.
        /// </remarks>
        /// <param name="command">The command containing user email.</param>
        /// <returns>Confirmation of password reset initiation.</returns>
        /// <response code="200">Returns success message if the password reset link is sent.</response>
        /// <response code="400">If the email is not registered.</response>
        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }

        /// <summary>
        /// Resets the user's password using a reset token.
        /// </summary>
        /// <remarks>
        /// This endpoint does not require any specific roles.
        /// </remarks>
        /// <param name="command">The command containing user ID, reset token, and new password.</param>
        /// <returns>Confirmation of password reset.</returns>
        /// <response code="200">Returns success message if the password is reset successfully.</response>
        /// <response code="400">If the reset token is invalid or the user ID does not match.</response>
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }

        /// <summary>
        /// Changes the user's password.
        /// </summary>
        /// <remarks>
        /// Requires the role <c>User</c>.
        /// </remarks>
        /// <param name="command">The command containing current and new passwords.</param>
        /// <returns>Confirmation of password change.</returns>
        /// <response code="200">Returns success message if the password is changed successfully.</response>
        /// <response code="400">If the current password is incorrect or the new password is invalid.</response>
        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }

        /// <summary>
        /// Refreshes the user's JWT token using a refresh token.
        /// </summary>
        /// <remarks>
        /// This endpoint does not require any specific roles.
        /// </remarks>
        /// <param name="command">The command containing refresh token.</param>
        /// <returns>New JWT token if refresh is successful.</returns>
        /// <response code="200">Returns new JWT token if refresh is successful.</response>
        /// <response code="400">If the refresh token is invalid or expired.</response>
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }

        /// <summary>
        /// Revokes the user's refresh token.
        /// </summary>
        /// <remarks>
        /// Requires the role <c>User</c>.
        /// </remarks>
        /// <param name="command">The command containing refresh token to revoke.</param>
        /// <returns>Confirmation of token revocation.</returns>
        /// <response code="200">Returns success message if the token is revoked successfully.</response>
        /// <response code="400">If the refresh token is invalid or does not exist.</response>
        [HttpPost("revoke-token")]
        [Authorize]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenCommand command)
        {
            var response = await Mediator.Send(command);
            return CreateResponse(response);
        }
    }
}
