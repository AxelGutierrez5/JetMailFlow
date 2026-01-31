using MailFlow.BLL.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.Services
{
    public class GmailService : IMailService
    {
        private IConfiguration _config;

        public GmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmail(string to, string subject, string body)
        {
			try
			{
                var message = new MimeMessage();
                message.From.Add(MailboxAddress.Parse(_config["Smtp:From"] ?? throw new Exception("Error al definir el  smpt")));
                message.To.Add(MailboxAddress.Parse(to)); 
                message.Subject = subject;

                message.Body = new BodyBuilder
                {
                    HtmlBody = body
                }.ToMessageBody();

                using var client = new SmtpClient();
                await client.ConnectAsync(
                    _config["Smtp:Host"],
                    int.Parse(_config["Smtp:Port"] ?? throw new Exception("Error al definir el puerto smpt")),
                    SecureSocketOptions.StartTls);

                await client.AuthenticateAsync(
                    _config["Smtp:User"] ?? throw new Exception("Error al definir el usuario smpt"),
                    _config["Smtp:Password"] ?? throw new Exception("Error al definir el password smpt"));

                await client.SendAsync(message);
                await client.DisconnectAsync(true);

            }
			catch (Exception ex)
			{

				throw;
			}
        }
    }
}
