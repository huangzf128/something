using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaConverter
{
    class Converter
    {
        public static string createArguements(string outputDir, string targetFile, Dictionary<int, string> metaInfo, int converterType)
        {
            string arguments = null;

            if (converterType == ConverterType.WAV2FLAC)
            {
                arguments = " --output-prefix " + outputDir + "\\ " +
                        @" -T Title=""" + metaInfo[MediaMetaNo.TITLE] + @"""" +
                        @" -T Artist=""" + metaInfo[MediaMetaNo.ARTIST] + @"""" +
                        @" -T Album=""" + metaInfo[MediaMetaNo.ALBUMTITLE] + @"""" +
                        @" -T Genre=""" + metaInfo[MediaMetaNo.GENRE] + @"""" +
                        @" -T Comment=""" + metaInfo[MediaMetaNo.COMMENT] + @"""" +
                        @" -T TrackNumber=""" + metaInfo[MediaMetaNo.TRACKNO] + @"""" +
                        @" -T Year=""" + metaInfo[MediaMetaNo.YEAR] + @"""" +
                        @" -T Date=""" + metaInfo[MediaMetaNo.RELEASE] + @"""" +
                        @" -f --best --keep-foreign-metadata """ + targetFile + @"""";
            }
            else if (converterType == ConverterType.FLAC2WAV)
            {
                arguments = " --output-prefix " + outputDir + "\\ " +
                        //@" -T Title=""" + metaInfo[MediaMetaNo.TITLE] + @"""" +
                        //@" -T Artist=""" + metaInfo[MediaMetaNo.ARTIST] + @"""" +
                        //@" -T Album=""" + metaInfo[MediaMetaNo.ALBUMTITLE] + @"""" +
                        //@" -T Genre=""" + metaInfo[MediaMetaNo.GENRE] + @"""" +
                        //@" -T Comment=""" + metaInfo[MediaMetaNo.COMMENT] + @"""" +
                        //@" -T TrackNumber=""" + metaInfo[MediaMetaNo.TRACKNO] + @"""" +
                        //@" -T Year=""" + metaInfo[MediaMetaNo.YEAR] + @"""" +
                        //@" -T Date=""" + metaInfo[MediaMetaNo.RELEASE] + @"""" +
                        @" -f --best -d --keep-foreign-metadata """ + targetFile + @"""";
            }


            return arguments;
        }
    }
}
