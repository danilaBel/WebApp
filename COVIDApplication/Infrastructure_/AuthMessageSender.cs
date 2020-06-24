using Application.Services;
using Infrastructure_.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;
using System.Net.Mail;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure_
{
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public AuthMessageSender(IOptions<AuthMessageSenderOptions> options)
        {
            Options = options.Value;
        }

        public AuthMessageSenderOptions Options { get; }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            MailAddress myAdress = new MailAddress("belozarovichdanila08@gmail.com", "Covid Web Application");
            MailAddress toMyAdress = new MailAddress(email);

            MailMessage mailMessage = new MailMessage(myAdress, toMyAdress);

            mailMessage.Subject = "Confirm";

            mailMessage.Body = "<h1>" + "Confirm password" + "</h1>";
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            
            smtp.Credentials = new NetworkCredential("belozarovichdanila08@gmail.com", "belazlol123");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(mailMessage);

        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
