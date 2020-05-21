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

namespace Clickonce
{
    public partial class Form1 : Form
    {
        private FileMover fMover = new FileMover();

        public Form1()
        {
            InitializeComponent();
            chkDll.Checked = true;
            chkRemoveDeploy.Checked = true;

            lblBuildExplain.Text = "Projectを選択。 \n例 : " + @"...\ClickonceDeploy\work\S99\";
            lblSelTargetExplain.Text = "最後の保存先を選択。\n例 :  " + @"...\Deploy\S99\S99T00F00_19_04_19_1\\n";
            lblCreateFolderExplain.Text = "最新のフォルダは自動作成する。例 : S99T00F00_年_月_日_連番";
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (fMover.sourceDir == null || fMover.targetDir == null)
            {
                MessageBox.Show("select path first");
                return;
            }
            List<String> sourceFiles = new List<string>();
            String fileFilter = ".*";
            if (!chkAll.Checked)
            {
                fileFilter = "S..T..F.*";
            }

            String ext = null;
            if (chkDll.Checked)
            {
                sourceFiles.AddRange(fMover.getSourceFileListByExt(Extension.DLL, fileFilter));
            }
            if (chkXls.Checked)
            {
                sourceFiles.AddRange(fMover.getSourceFileListByExt(Extension.XLS, fileFilter));
                sourceFiles.AddRange(fMover.getSourceFileListByExt(Extension.XLSX, fileFilter));
            }


            // remove deploy file
            if (chkRemoveDeploy.Checked)
            {
                fMover.removeDeployFile(sourceFiles);
            }

            // copy
            fMover.copyFile(sourceFiles);
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            txtSource.Text = fMover.selectFolder(ConfigurationManager.AppSettings["sourceDir"]);
            fMover.sourceDir = txtSource.Text;

            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove("sourceDir");
            config.AppSettings.Settings.Add("sourceDir", fMover.sourceDir);
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void btnTarget_Click(object sender, EventArgs e)
        {
            txtLastTarget.Text = fMover.selectFolder(ConfigurationManager.AppSettings["targetDir"]);

            fMover.lastTargetDir = txtLastTarget.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(@"ProjectBuilder\ProjectBuilder.exe");
        }

        private void btnCreateDeployFolder_Click(object sender, EventArgs e)
        {
            fMover.createTargetFolder();

            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove("targetDir");
            config.AppSettings.Settings.Add("targetDir", fMover.targetDir);
            config.Save(ConfigurationSaveMode.Minimal);

            fMover.CopyDirectory(fMover.lastTargetDir, fMover.targetDir);

            fMover.targetDir = Path.Combine(fMover.targetDir, getFirstSubFolderName(fMover.targetDir));
            txtTarget.Text = fMover.targetDir;
        }

        private String getFirstSubFolderName(String dir)
        {
            DirectoryInfo directory = new DirectoryInfo(dir);
            DirectoryInfo[] directories = directory.GetDirectories();
            if (directories.Length == 0)
            {
                return "";
            }
            return directories[0].Name;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtTarget.Text = fMover.selectFolder(txtTarget.Text);

            fMover.targetDir = txtTarget.Text;

        }
    }
}
