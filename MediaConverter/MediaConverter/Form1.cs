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

            List<string> targetFiles = getFileList(targetFolderPath);
            Boolean result = true;

            foreach (string targetFile in targetFiles)
            {

                string arguments = "  --output-name " + getSaveFolder() + targetFile.Replace("wav", "flac") + " " + targetFolderPath + "\\" + targetFile;

                MessageBox.Show(arguments);

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

        private string getSaveFolder()
        {
            return targetFolderPath + "\\" + getLastFolder() + "\\";
        }

        private Boolean launchCommandLineApp(string arguments)
        {            
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;


            startInfo.FileName = Environment.CurrentDirectory + @"\lib\flac.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
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

        private string getLastFolder()
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
    }
}
