using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AppConfigUtil
    {
        public static void WriteAppconfig(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(Assembly.GetCallingAssembly().Location);
            config.AppSettings.Settings[key].Value = value;
            config.Save();
        }

        public static string ReadAppconfig(string key)
        {
            var config = ConfigurationManager.OpenExeConfiguration(Assembly.GetCallingAssembly().Location);
            return config.AppSettings.Settings[key].Value;
        }
    }
}
