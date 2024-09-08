using RoshettaProAPI.Data.Entities.Auth;

namespace RoshettaProAPI.Service.IService
{
    public interface IEmailService
    {
        Task SendAsync(EmailModel emailModel);
    }
}
