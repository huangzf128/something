using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compressor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            SevenZ s7z = new SevenZ();
            RemoveSvnFolder(txtFolder.Text);
            string zipName = Path.GetFileName(txtFolder.Text);
            s7z.CompressFolder(txtFolder.Text, zipName);
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            SelectFolder();
        }

        private void btnUnCompress_Click(object sender, EventArgs e)
        {
            SevenZ s7z = new SevenZ();
            s7z.ExtractFolder(txtFolder.Text);
        }

        private void SelectFolder()
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
            fbd.SelectedPath = @"C:\Windows";
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            fbd.SelectedPath = Properties.Settings.Default.Folder_Path;

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                txtFolder.Text = fbd.SelectedPath;

                if (!String.IsNullOrEmpty(Properties.Settings.Default.Folder_Path))
                    Properties.Settings.Default.Folder_Path = fbd.SelectedPath;

                Properties.Settings.Default.Folder_Path = fbd.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void RemoveSvnFolder(string path)
        {
            string svnFolderPath = Path.Combine( new String[] { path, ".svn" });
            if (Directory.Exists(svnFolderPath)) {
                Directory.Delete(svnFolderPath, true);
                // processDirectory(svnFolderPath);
            }
        }

        private static void processDirectory(string startLocation)
        {
            foreach (var directory in Directory.GetDirectories(startLocation))
            {
                processDirectory(directory);
                if (Directory.GetFiles(directory).Length == 0 &&
                    Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                }
            }
        }
    }
}
