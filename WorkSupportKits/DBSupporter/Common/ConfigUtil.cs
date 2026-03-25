using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBSupporter.Common
{
    internal class ConfigUtil
    {
        public static ProjectConfig Current { get; private set; }

        static ConfigUtil()
        {
            LoadConfig();
        }

        public static void LoadConfig()
        {
            string configPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            XDocument doc = XDocument.Load(configPath);

            // 1. 获取当前激活的项目名称 (如 "shinsei")
            var root = doc.Descendants("Templates").First();
            string activeName = root.Attribute("name")?.Value;

            // 2. 查找对应的 Server 信息
            var s = root.Descendants("server")
                        .FirstOrDefault(x => x.Attribute("name")?.Value == activeName);

            // 3. 查找对应的 Comment 模板
            var c = root.Descendants("comment")
                        .FirstOrDefault(x => x.Attribute("name")?.Value == activeName);

            // 4. 填充到变量里
            Current = new ProjectConfig
            {
                ServerIp = s?.Attribute("ip")?.Value,
                Port = s?.Attribute("port")?.Value,
                DbName = s?.Attribute("dbname")?.Value,
                UserId = s?.Attribute("userid")?.Value,
                Password = s?.Attribute("password")?.Value,
                CommentTemplate = c?.Value.Trim()
            };
        }
    }
}
