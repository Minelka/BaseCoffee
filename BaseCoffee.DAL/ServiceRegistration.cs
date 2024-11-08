using BaseCoffee.DAL.Context;
using BaseCoffee.DAL.Mail;
using BaseCoffee.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCoffee.DAL
{
    public static class ServiceRegistration
    {
        //servis oluşturduk
        public static void AddDalService(this IServiceCollection services) 
        {
            services.AddDbContext<MyDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddTransient<IMailService, MailService>();
        }
    }
}
