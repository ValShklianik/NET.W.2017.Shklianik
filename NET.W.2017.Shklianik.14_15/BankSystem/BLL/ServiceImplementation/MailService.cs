using BLL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class MailService : IEmailService
    {

        private string fromEmail;
        private string mailServer;
        private string password;
        private int port;

        public MailService()
        {
            fromEmail = ConfigurationManager.AppSettings["email"];
            password = ConfigurationManager.AppSettings["password"];
            mailServer = ConfigurationManager.AppSettings["mail_server"];
            int.TryParse(ConfigurationManager.AppSettings["port"], out port);
        }

        private SmtpClient PrepareClient()
        {
            SmtpClient client = new SmtpClient(mailServer, port);

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(fromEmail, password);
            client.EnableSsl = true;

            return client;
        }

        public void SendMail(MailMessage message)
        {
            message.From = new MailAddress(fromEmail);

            PrepareClient().Send(message);
        }

        public Task SendMailAsync(MailMessage message)
        {
            message.From = new MailAddress(fromEmail);

            return PrepareClient().SendMailAsync(message);
        }
    }
}
