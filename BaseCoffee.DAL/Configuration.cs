using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCoffee.DAL
{
    //mvc de daldan nasıl json ile bağlanıyor başka nasıl bağlanabilir araştır.
    public static class Configuration
    {
        public static string ConnectionString 
        {
            get 
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.AddJsonFile("appsettings.json"); //UInt128 bulunan json dosyasına ulaşıp 
                return configurationManager.GetConnectionString("conn");//database yolu sayesinde database ulaştık
            }
        }
    }
}
