using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SyncFolder
{
    public class NetworkServerInfo
    {
        public string Name { get; set; }
        public string Ip { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SharePath { get; set; }
        public string DriveLetter { get; set; }
    }

    class Common
    {
        public static NetworkServerInfo GetServer(string serverName)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var xml = XDocument.Load(config.FilePath);

            var server = xml.Descendants("add")
                .FirstOrDefault(x => (string)x.Attribute("name") == serverName);

            if (server == null) return null;

            return new NetworkServerInfo
            {
                Name = (string)server.Attribute("name"),
                Ip = (string)server.Attribute("ip"),
                Username = (string)server.Attribute("username"),
                Password = (string)server.Attribute("password"),
                SharePath = (string)server.Attribute("sharePath"),
                DriveLetter = (string)server.Attribute("driveLetter")
            };
        }
    }
}
