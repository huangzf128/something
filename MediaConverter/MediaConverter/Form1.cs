using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shell32;
using MediaConverter;

namespace WindowsFormsApp1
{
    public partial class frmMain : Form
    {
        private string targetFolderPath = null;

        public frmMain()
        {
            InitializeComponent();
            rdoWavToFlac.Checked = true;
        }

        private void btnOpenTarget_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            fbd.Description = "フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;

            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            fbd.SelectedPath = ConfigurationManager.AppSettings["lastOpenTargetPath"]; ;

            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                targetFolderPath = fbd.SelectedPath;
                labTargetPath.Text = targetFolderPath;
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {

            if (targetFolderPath == null)
            {
                MessageBox.Show("フォルダを選択してください。");
                return;
            }

            List<string> targetFiles = getFileList(targetFolderPath);
            Boolean result = true;

            string outputDir = getFolderName();
            if (false == Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(targetFolderPath + "\\" + outputDir);
            }

            foreach (string targetFile in targetFiles)
            {
                Dictionary<int, string> metaInfo = getWavField(targetFile);

                string arguments = " --output-prefix " + outputDir + "\\ " +
                                    @" -T Title=""" + metaInfo[WavMetaNo.TITLE] + @"""" +
                                    @" -T Artist=""" + metaInfo[WavMetaNo.ARTIST] + @"""" +
                                    @" -T Album=""" + metaInfo[WavMetaNo.ALBUMTITLE] + @"""" +
                                    @" -T Genre=""" + metaInfo[WavMetaNo.GENRE] + @"""" +
                                    @" -T Comment=""" + metaInfo[WavMetaNo.COMMENT] + @"""" +
                                    @" -T TrackNumber=""" + metaInfo[WavMetaNo.TRACKNO] + @"""" +
                                    @" -T Year=""" + metaInfo[WavMetaNo.YEAR] + @"""" +
                                    @" -T Date=""" + metaInfo[WavMetaNo.RELEASE] + @"""" +
                                    @" -f --best """ + targetFile + @"""";

                if (false == launchCommandLineApp(arguments))
                {
                    result = false;
                }
            }

            if (result)
            {
                MessageBox.Show("変換に成功しました (≧▽≦)");
            }
            else
            {
                MessageBox.Show("失敗しました　(*´ω｀)");
            }
        }


        private Boolean launchCommandLineApp(string arguments)
        {            
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;

            startInfo.FileName = Environment.CurrentDirectory + @"\lib\flac.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            startInfo.WorkingDirectory = targetFolderPath;
            startInfo.Arguments = arguments;

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private string getFolderName()
        {
            return new DirectoryInfo(targetFolderPath).Name;
        }

        private List<string> getFileList(string folderPath)
        {
            DirectoryInfo d = new DirectoryInfo(targetFolderPath);
            FileInfo[] fileInfos = d.GetFiles("*.wav");
            List<string> files = new List<string>();
            
            foreach (FileInfo file in fileInfos)
            {
                files.Add(file.Name);
            }

            return files;
        }



        private Dictionary<int, string> getWavField(string fileName)
        {

            Dictionary<int, string> metaInfo = new Dictionary<int, string>();

            ShellClass shell = new ShellClass();
            Folder f = shell.NameSpace(targetFolderPath);
            FolderItem item = f.ParseName(fileName);

            //Console.WriteLine(f.GetDetailsOf(item, WavMetaNo.ARTIST)); // 参加アーティスト
            //Console.WriteLine(f.GetDetailsOf(item, WavMetaNo.TITLE)); // タイトル
            //Console.WriteLine(f.GetDetailsOf(item, WavMetaNo.GENRE)); // ジャンル
            //Console.WriteLine(f.GetDetailsOf(item, WavMetaNo.ALBUMTITLE)); // アルバムのタイトル
            //Console.WriteLine(f.GetDetailsOf(item, WavMetaNo.YEAR)); // 年
            //Console.WriteLine(f.GetDetailsOf(item, WavMetaNo.TRACKNO)); // トラック番号
            //Console.WriteLine(f.GetDetailsOf(item, WavMetaNo.COMMENT)); // コメント

            metaInfo.Add(WavMetaNo.ARTIST, f.GetDetailsOf(item, WavMetaNo.ARTIST));
            metaInfo.Add(WavMetaNo.TITLE, f.GetDetailsOf(item, WavMetaNo.TITLE));
            metaInfo.Add(WavMetaNo.GENRE, f.GetDetailsOf(item, WavMetaNo.GENRE));
            metaInfo.Add(WavMetaNo.ALBUMTITLE, f.GetDetailsOf(item, WavMetaNo.ALBUMTITLE));
            metaInfo.Add(WavMetaNo.YEAR, f.GetDetailsOf(item, WavMetaNo.YEAR));
            metaInfo.Add(WavMetaNo.TRACKNO, f.GetDetailsOf(item, WavMetaNo.TRACKNO));
            metaInfo.Add(WavMetaNo.COMMENT, f.GetDetailsOf(item, WavMetaNo.COMMENT));
            metaInfo.Add(WavMetaNo.RELEASE, f.GetDetailsOf(item, WavMetaNo.RELEASE));


            for (int i = 0; i < 10000; i++)
            { // 10000は適当な大きな値
                string name = f.GetDetailsOf(null, i);
                if (!string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("{0} : {1}", i, name);
                }
            }

            return metaInfo;
        }
    }
}
