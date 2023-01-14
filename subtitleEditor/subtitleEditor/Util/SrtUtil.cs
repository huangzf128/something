using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace subtitleEditor.Util
{
    class SrtUtil
    {
        public const string TIME_FORMART = "HH:mm:ss,fff";
        public const string TIME_REGEX = "[0-9]{2}:[0-9]{2}:[0-9]{2},[0-9]{3}.*?";
        public static DateTime str2DateTime(string str, string format)
        {
            return DateTime.ParseExact(str, format,
                        System.Globalization.CultureInfo.InvariantCulture);
        }

        public static bool isTimeLine(string line)
        {
            return Regex.IsMatch(line, TIME_REGEX);
        }

        public static MatchCollection parseTime(string line)
        {
            return Regex.Matches(line, TIME_REGEX);
        }

        public static string shifeTimeLine(string line, TimeSpan ts)
        {
            MatchCollection match = SrtUtil.parseTime(line);
            if (match.Count == 2)
            {
                DateTime dtStr = SrtUtil.str2DateTime(match[0].Value, TIME_FORMART);
                DateTime dtEnd = SrtUtil.str2DateTime(match[1].Value, TIME_FORMART);

                dtStr += ts;
                dtEnd += ts;

                line = line.Replace(match[0].Value, dtStr.ToString(TIME_FORMART));
                line = line.Replace(match[1].Value, dtEnd.ToString(TIME_FORMART));
            }
            return line;
        }
    }
}
