namespace RoshettaProAPI.Data.Entities.Auth;

public class ResetPasswordModel
{
    public string UserId { get; set; }
    public string Token { get; set; }
    public string NewPassword { get; set; }
}
