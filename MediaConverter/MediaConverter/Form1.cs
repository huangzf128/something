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
using MediaConverter;

namespace WindowsFormsApp1
{
    public partial class frmMain : Form
    {
        private string targetFolderPath = null;

        public frmMain()
        {
            InitializeComponent();
            rdoWav2Flac.Checked = true;
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

        private int targetMediaType()
        {
            if (rdoWav2Flac.Checked)
            {
                return MediaType.WAV;
            }
            else if (rdoFlac2Wav.Checked)
            {
                return MediaType.FLAC;
            }
            return -1;

        }

        private void btnExecute_Click(object sender, EventArgs e)
        {

            //string file = @"F:\temp\temp\03 Awadama Fever.wav";
            //file = @"F:\temp\temp\04. ヤバッ!.wav";
            //FileUtil.setWavMetaDate(file, null);


            if (targetFolderPath == null)
            {
                MessageBox.Show("フォルダを選択してください。");
                return;
            }

            List<string> targetFiles = FileUtil.getFileList(targetFolderPath, targetMediaType());
            Boolean result = true;

            string outputDir = FileUtil.getOutputFolderName(targetFolderPath);

            foreach (string targetFile in targetFiles)
            {
                Dictionary<int, string> metaInfo = null;

                if (FileUtil.isMetadataFileExists(targetFolderPath))
                {
                    metaInfo = FileUtil.getMetaDataFromFile(targetFolderPath + "\\" + targetFile);
                }
                else
                {
                    metaInfo = FileUtil.getMediaField(targetFolderPath, targetFile);
                }

                string arguments = null;
                if (rdoWav2Flac.Checked)
                {
                    arguments = Converter.createArguements(outputDir, targetFile, metaInfo, ConverterType.WAV2FLAC);
                }
                else if (rdoFlac2Wav.Checked)
                {
                    arguments = Converter.createArguements(outputDir, targetFile, metaInfo, ConverterType.FLAC2WAV);
                }

                if (false == launchCommandLineApp(arguments))
                {
                    result = false;
                }


                if (chkCreateMetaFile.Checked)
                {
                    FileUtil.createMetaDataFile(metaInfo, targetFile, targetFolderPath + "\\" + outputDir);
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


    }
}
