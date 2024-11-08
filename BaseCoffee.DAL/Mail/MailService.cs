using BaseCoffee.DAL.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BaseCoffee.DAL.Mail
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        public MailService(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration= configuration;
            _userManager = userManager;
        }

        public async Task SendConfimationAsync(AppUser user, string code)
        {
            var mailConcent = new StringBuilder();
            mailConcent.Append(@$"Merhaba<b>{user.UserName} </b> Uygulammıza hoşgeldiniz");
            mailConcent.Append("maileli onyla");
            mailConcent.Append(@$"<a href='http://localhost:5043/home/deneme/?email={user.Email}&code={code}'>Onayla</a>");

            await SendMailAsync(user.Email, "ONAYLAMA İŞLEMİ", mailConcent.ToString());

        }

        public async Task SendMailAsync(string to, string subject, string body, bool isHtml = true)
        {
            await SendMailAsync(new[] {to}, subject, body, isHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isHtml;
            foreach (var to in tos)
            {
                mail.To.Add(to);
            }

            mail.Subject = subject;
            mail.Body = body;

            var a = _configuration["SmtpSettings:Email"];
            var b = _configuration["SmtpSettings:Password"];
            var c = _configuration["SmtpSettings:Host"];

            mail.From = new(a, "BaseCoffee", Encoding.UTF8);

            SmtpClient smtp = new SmtpClient
            {
                Credentials = new NetworkCredential(a, b),
                Port = 587,  // STARTTLS için yaygın port
                Host = c,    // SMTP sunucusu
                EnableSsl = true  // SSL/TLS bağlantısını etkinleştiriyoruz
            };
            await smtp.SendMailAsync(mail);

        }

    }
}
