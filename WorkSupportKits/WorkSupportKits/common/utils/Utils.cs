using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSupportKits.common.utils
{
    class Utils
    {


        public static string Obj2Str(Object obj, String defaultValue = "")
        {
            if (obj == null) return defaultValue;
            return obj.ToString();
        }
    }
}
