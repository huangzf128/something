using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchRepository
{
    interface Repository
    {
        Boolean Init(string serverPath);

        HashSet<string> GetLogByTime(DateTime startDateTime, DateTime endDateTime);

    }
}
