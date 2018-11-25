using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shell32;
using System.IO;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using TagLib;

namespace MediaConverter
{
    class FileUtil
    {
        public static Dictionary<int, string> getMediaField(string targetFolderPath, string fileName)
        {

            Dictionary<int, string> metaInfo = new Dictionary<int, string>();

            ShellClass shell = new ShellClass();
            Folder f = shell.NameSpace(targetFolderPath);
            FolderItem item = f.ParseName(fileName);

            //Console.WriteLine(f.GetDetailsOf(item, MediaMetaNo.ARTIST)); // 参加アーティスト
            //Console.WriteLine(f.GetDetailsOf(item, MediaMetaNo.TITLE)); // タイトル
            //Console.WriteLine(f.GetDetailsOf(item, MediaMetaNo.GENRE)); // ジャンル
            //Console.WriteLine(f.GetDetailsOf(item, MediaMetaNo.ALBUMTITLE)); // アルバムのタイトル
            //Console.WriteLine(f.GetDetailsOf(item, MediaMetaNo.YEAR)); // 年
            //Console.WriteLine(f.GetDetailsOf(item, MediaMetaNo.TRACKNO)); // トラック番号
            //Console.WriteLine(f.GetDetailsOf(item, MediaMetaNo.COMMENT)); // コメント

            metaInfo.Add(MediaMetaNo.ARTIST, f.GetDetailsOf(item, MediaMetaNo.ARTIST));
            metaInfo.Add(MediaMetaNo.TITLE, f.GetDetailsOf(item, MediaMetaNo.TITLE));
            metaInfo.Add(MediaMetaNo.GENRE, f.GetDetailsOf(item, MediaMetaNo.GENRE));
            metaInfo.Add(MediaMetaNo.ALBUMTITLE, f.GetDetailsOf(item, MediaMetaNo.ALBUMTITLE));
            metaInfo.Add(MediaMetaNo.YEAR, f.GetDetailsOf(item, MediaMetaNo.YEAR));
            metaInfo.Add(MediaMetaNo.TRACKNO, f.GetDetailsOf(item, MediaMetaNo.TRACKNO));
            metaInfo.Add(MediaMetaNo.COMMENT, f.GetDetailsOf(item, MediaMetaNo.COMMENT));
            metaInfo.Add(MediaMetaNo.RELEASE, f.GetDetailsOf(item, MediaMetaNo.RELEASE));

            //for (int i = 0; i < 10000; i++)
            //{ // 10000は適当な大きな値
            //    string name = f.GetDetailsOf(null, i);
            //    if (!string.IsNullOrEmpty(name))
            //    {
            //        Console.WriteLine("{0} : {1}", i, name);
            //    }
            //}

            return metaInfo;
        }
        public static string getOutputFolderName(string targetFolderPath)
        {
            string outputDir = new DirectoryInfo(targetFolderPath).Name;
            if (false == Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(targetFolderPath + "\\" + outputDir);
            }
            return outputDir;
        }
        public static List<string> getFileList(string targetFolderPath, int mediaType)
        {
            DirectoryInfo d = new DirectoryInfo(targetFolderPath);
            FileInfo[] fileInfos = null;
            if (mediaType == MediaType.WAV)
            {
                fileInfos = d.GetFiles("*.wav");
            }
            else
            {
                fileInfos = d.GetFiles("*.flac");
            }

            List<string> files = new List<string>();
            foreach (FileInfo file in fileInfos)
            {
                files.Add(file.Name);
            }
            return files;
        }

        public static void setWavMetaDate(string filePath, Dictionary<int, string> metaInfo)
        {
            var tfile = TagLib.WavPack.File.Create(filePath);
            //tfile.Tag.AlbumArtists = new string[] {"hzf"};
            //tfile.Tag.Title = "title";
            //tfile.Tag.Year = 2018;

            Tag t2 = tfile.GetTag(TagLib.TagTypes.Id3v2);
            t2.Album = "albummm2";

            //((TagLib.CombinedTag)((TagLib.Riff.File)tfile).Tag).Tags[0].Album = "albumm";
            //tfile.Tag.Album = "albumm";
            //((TagLib.Id3v2.Tag)((TagLib.CombinedTag)((TagLib.Riff.File)tfile).Tag).Tags[0]).Album = "albumm";
            //((TagLib.Riff.InfoTag)((TagLib.CombinedTag)((TagLib.Riff.File)tfile).Tag).Tags[1]).Album = "albumm";
            //((TagLib.CombinedTag)((TagLib.Riff.File)tfile).Tag).Tags[2].Album = null;
            //((TagLib.CombinedTag)((TagLib.Riff.File)tfile).Tag).Tags[3].Album = null;



            //tfile.Tag.Description = "des";

            //tfile.Tag.MusicBrainzTrackId = "trackid";
            //tfile.Tag.AlbumSort = "albumsort";
            //tfile.Tag.Disc = 1;
            //tfile.Tag.DiscCount = 11;
            //tfile.Tag.Track = 2;
            //tfile.Tag.TrackCount = 22;
            //tfile.Tag.Comment  = "comments";

            // Write
            tfile.Save();


            var shellFile = ShellFile.FromFilePath(filePath);

            ShellPropertyWriter propertyWriter = shellFile.Properties.GetPropertyWriter();
            //((Microsoft.WindowsAPICodePack.Shell.PropertySystem.ShellProperty<string>)new System.Collections.Generic.Mscorlib_CollectionDebugView<IShellProperty>(shellFile.Properties.DefaultPropertyCollection).Items[31]).Value = "meta";

            shellFile.Properties.System.Music.AlbumTitle.Value = "meta";

            //propertyWriter.WriteProperty(SystemProperties.System.Music.Artist, new string[] { metaInfo[MediaMetaNo.ARTIST] });
            //propertyWriter.Close();

            //shellFile.Properties.System.Music.Artist.Value = new string[] { metaInfo[MediaMetaNo.ARTIST] };
            //shellFile.Properties.System.Music.AlbumTitle.Value = metaInfo[MediaMetaNo.ALBUMTITLE];

            //shellFile.Properties.System.Title.Value = metaInfo[MediaMetaNo.TITLE];
            //shellFile.Properties.System.Music.TrackNumber.Value = (uint)Int32.Parse(metaInfo[MediaMetaNo.TRACKNO]);
            //shellFile.Properties.System.Media.DateReleased.Value = metaInfo[MediaMetaNo.RELEASE];
        }

    }
}
