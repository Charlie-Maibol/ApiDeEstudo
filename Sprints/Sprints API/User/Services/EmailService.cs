using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class EmailService
    {
        IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string[] recipient, string subject, int userId, string code)
        {
            Message message = new Message(recipient, subject, userId, code);

            var emailMessagem = ComposeEmailBody(message);
            SendEmail(emailMessagem);

        }

        private void SendEmail(MimeMessage emailMessagem)
        {
            using(var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"), true);
                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    client.Send(emailMessagem);
                }
                catch 
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        private MimeMessage ComposeEmailBody(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(
                _configuration.GetValue<string>("EmailSettings")));
            emailMessage.To.AddRange(message.Recipient);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text){
                Text = message.Content
            };

            return emailMessage;
        }
    }
}
