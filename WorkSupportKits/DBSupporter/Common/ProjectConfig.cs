using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSupporter.Common
{
    internal class ProjectConfig
    {
        public string ServerIp { get; set; }
        public string Port { get; set; }
        public string DbName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string CommentTemplate { get; set; }
    }
}
