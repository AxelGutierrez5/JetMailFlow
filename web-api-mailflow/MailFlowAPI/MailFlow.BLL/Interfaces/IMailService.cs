using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.Interfaces
{
    public interface IMailService
    {
        Task SendEmail(string to, string subject, string body);

    }
}
