using SharpSvn;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;　
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FetchRepository
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            txtLocalPath.Text = ComUtil.ReadAppconfig("LocalPath");
            txtServerPath.Text = ComUtil.ReadAppconfig("ServerPath");
        }

        #region ----------------- Event ------------------------
        private void button1_Click(object sender, EventArgs e)
        {

            if (false == check()) return;

            SVN svn = new SVN();
            string serverPath = txtServerPath.Text;
            string outputPath = AppDomain.CurrentDomain.BaseDirectory;

            svn.Init(serverPath);
            HashSet<string> fetchFiles = svn.GetLogByTime(dtPickerFrom.Value.Date, dtPickerTo.Value.Date);

            if (fetchFiles == null)
            {
                MessageBox.Show("Nothing to fetch");
                return;
            }
            foreach(string file in fetchFiles)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath + file));
                File.Copy(Path.Combine(txtLocalPath.Text, ComUtil.RemoveFirstDir(file)), 
                            Path.Combine(outputPath, file), true);

                if (chkJavaClass.Checked && file.IndexOf(".java", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    string pkgPath = GetPackagePath(file, "com");
                    string copyTop = Path.Combine(outputPath, ComUtil.GetFirstDir(file)) + @"/classes";

                    Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(copyTop, pkgPath)));
                    File.Copy(Path.Combine(txtLocalClassPath.Text, pkgPath),
                                Path.Combine(copyTop, pkgPath), true);
                }
            }

            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //config.AppSettings.Settings["LocalPath"].Value = txtLocalPath.Text;
            //config.AppSettings.Settings["ServerPath"].Value = txtServerPath.Text;
            //config.Save();

            MessageBox.Show("finish");
        }

        private string GetPackagePath(string path, string topPkgName)
        {
            string[] folders = path.Split('/');
            int pos = 0;
            for(int i = 0; i < folders.Length; i++)
            {
                if (topPkgName.Equals(folders[i]))
                {
                    pos = i;
                    break;
                }
            }

            string pkgPath = string.Join("/", folders.Skip(pos));
            return Regex.Replace(pkgPath, "\\.java$", ".class", RegexOptions.IgnoreCase);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            fbd.SelectedPath = txtLocalPath.Text;
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                txtLocalPath.Text = fbd.SelectedPath;
                ComUtil.WriteAppconfig("LocalPath", txtLocalPath.Text);
            }
        }

        private void btnFindSrvPath_Click(object sender, EventArgs e)
        {
            if (txtLocalPath.Text.Length == 0) return;

            string cmd = "/C svn info \"" + txtLocalPath.Text + "\"";
            txtServerPath.Text = ParseSvnInfo(ExecuteCmd(cmd));
            if (txtServerPath.Text.Length > 0)
            {
                ComUtil.WriteAppconfig("ServerPath", txtServerPath.Text);
            }
        }

        private void btnOpenOutput_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory);
        }

        private void btnSelClassPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "フォルダを指定してください。";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.SelectedPath = txtLocalPath.Text;
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                txtLocalClassPath.Text = fbd.SelectedPath;
            }
        }
        #endregion 

        private Boolean check()
        {
            if (txtLocalPath.Text == "")
            {
                MessageBox.Show("プロジェクトフォルダを選択してください。");
                return false;
            }
            if (dtPickerFrom.Value.Date > dtPickerTo.Value.Date)
            {
                MessageBox.Show("From Date > To Date ??");
                return false;
            }
            return true;
        }

        private string GetParentPath(string folderPath)
        {
            DirectoryInfo parentDir = Directory.GetParent(folderPath.EndsWith("\\") ? folderPath : string.Concat(folderPath, "\\"));

            // The result is available here
            var myParentDir = parentDir.Parent.FullName;
            return myParentDir + "\\";
        }


        private string ParseSvnInfo(string svnInfo)
        {
            Regex reg = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            Match match = reg.Match(svnInfo);
            return match.Value;
        }

        private string ExecuteCmd(string command)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo()
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = command,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };
            process.Start();
            // Now read the value, parse to int and add 1 (from the original script)
            string message = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return message;
        }

    }
}
