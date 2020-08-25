using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FetchRepository
{
    class ComUtil
    {
        #region -------------------- appConfig --------------------
        public static void WriteAppconfig(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            config.AppSettings.Settings[key].Value = value;
            config.Save();
        }

        public static string ReadAppconfig(string key)
        {
            var config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            return config.AppSettings.Settings[key].Value;
        }
        #endregion


        #region ============= Path ==============
        public static string RemoveFirstDir(string path)
        {
            return string.Join("/", path.Split('/').Skip(1));
        }

        public static string GetFirstDir(string path)
        {
            return path.Split('/')[0];
        }
        #endregion

    }
}
