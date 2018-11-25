using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaConverter
{
    public static class MediaMetaNo
    {
        public static readonly int ARTIST = 13;
        public static readonly int ALBUMTITLE = 14;
        public static readonly int YEAR = 15;
        public static readonly int GENRE = 16;
        public static readonly int TITLE = 21;
        public static readonly int COMMENT = 24;
        public static readonly int TRACKNO = 26;
        public static readonly int RELEASE = 209;
    }

    public static class MediaType
    {
        public static readonly int WAV = 0;
        public static readonly int FLAC = 1;
    }

    public static class ConverterType
    {
        public static readonly int WAV2FLAC = 0;
        public static readonly int FLAC2WAV = 1;
    }

}
