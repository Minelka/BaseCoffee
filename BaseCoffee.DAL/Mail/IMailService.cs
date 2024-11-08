using BaseCoffee.DAL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCoffee.DAL.Mail
{
    public interface IMailService
    {
        Task SendMailAsync(string to, string subject, string body, bool isHtml=true);

        Task SendMailAsync(string[] tos, string subject, string body, bool isHtml = true);

        Task SendConfimationAsync(AppUser user, string code);
    }
}
