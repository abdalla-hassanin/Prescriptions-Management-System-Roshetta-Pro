using Microsoft.EntityFrameworkCore;

namespace RoshettaProAPI.Data.Entities.Auth
{
    [Owned]
    // Represents a refresh token used for extending user sessions securely.
    public class RefreshToken
    {
        // The token value.
        public string Token { get; set; }

        public string JwtToken { get; set; } // Store the JWT token

        // Expiration time of the token.
        public DateTime ExpiresOn { get; set; }

        // Indicates if the token is expired.
        public bool IsExpired => DateTime.UtcNow >= ExpiresOn;

        // Time when the token was created.
        public DateTime CreatedOn { get; set; }

        // Time when the token was revoked. Nullable.
        public DateTime? RevokedOn { get; set; }

        // Indicates if the token is active (not revoked and not expired).
        public bool IsActive => RevokedOn == null && !IsExpired;
    }
}