using MediatR;
using RoshettaProAPI.Core.Base.ApiResponse;

namespace RoshettaProAPI.Core.MediatrHandlers.Auth.Queries.ConfirmEmail
{
    public class ConfirmEmailQuery : IRequest<ApiResponse<string>>
    {
        public string UserId { get; set; }
        public string Token { get; set; }

        public ConfirmEmailQuery(string userId, string token)
        {
            UserId = userId;
            Token = token;
        }
    }
}