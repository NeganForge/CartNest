using CartNest.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace CartNest.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            using var message = new MailMessage
            {
                From = new MailAddress(_emailSettings.Email),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            message.To.Add(toEmail);

            using var smtp = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
            {
                Credentials = new NetworkCredential(
                    _emailSettings.Email,
                    _emailSettings.Password),
                EnableSsl = true
            };

            await smtp.SendMailAsync(message);
        }
    }
}