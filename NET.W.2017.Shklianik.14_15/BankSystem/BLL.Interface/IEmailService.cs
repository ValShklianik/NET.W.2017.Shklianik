using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IEmailService
    {
        void SendMail(MailMessage message);
        Task SendMailAsync(MailMessage message);
    }
}
