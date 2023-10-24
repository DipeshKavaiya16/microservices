using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Models;

namespace Ordering.Infrastructure.Helper
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var sendEmail = new MimeMessage();
            sendEmail.From.Add(MailboxAddress.Parse(_emailSettings.FromAddress));
            sendEmail.To.Add(MailboxAddress.Parse(email.To));
            sendEmail.Subject = email.Subject;
            sendEmail.Body = new BodyBuilder() { TextBody =  email.Body }.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_emailSettings.HostName, Convert.ToInt32(_emailSettings.Port), SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_emailSettings.FromAddress, _emailSettings.Password);
            await smtp.SendAsync(sendEmail);
            await smtp.DisconnectAsync(true);

            return true;
        }
    }
}
