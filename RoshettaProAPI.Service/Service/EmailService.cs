using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using RoshettaProAPI.Data.Entities.Auth;
using RoshettaProAPI.Service.IService;

namespace RoshettaProAPI.Service.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendAsync(EmailModel emailModel)
        {
            // Get SMTP settings from configuration
            var smtpSettings = _configuration.GetSection("EmailSettings");

            var smtpClient = new SmtpClient(smtpSettings["Host"])
            {
                Port = int.Parse(smtpSettings["Port"]),
                Credentials = new NetworkCredential(smtpSettings["UserName"], smtpSettings["Password"]),
                EnableSsl = true
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpSettings["UserName"]),
                Subject = emailModel.Subject,
                Body = emailModel.Body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(emailModel.To);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new Exception("There was an error sending the email.", ex);
            }
        }
    }
}
