using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncFolder
{
    public partial class Form1 : Form
    {
        private string leftRootPath = null;
        private string rightRootPath = null;
        

        public Form1()
        {
            InitializeComponent();
        }

        #region "Event"

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            if (leftTree.Nodes.Count > 0) return;

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            fbd.Description = "フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            

            fbd.SelectedPath = System.Configuration.ConfigurationManager.AppSettings.Get("DefaultLocalProjectPath");
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                leftRootPath = fbd.SelectedPath + "\\";
                List<string[]> fileNameList = FolderSupport.getFileNameList(leftRootPath, leftRootPath);
                NodeSupport.addRootNode(fileNameList, leftTree);
            }
        }

        private void executeCommand()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;

            process.StartInfo = startInfo;
            process.Start();

            using (StreamWriter sw = process.StandardInput)
            {
                sw.WriteLine(@"net use \\192.168.255.201\C$ amc4715116 /user:administrator");
                //sw.WriteLine(@"pushd \\192.168.255.201\C$");
            }
            process.Close();
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            if (rightTree.Nodes.Count > 0) return;

            executeCommand();
            System.Threading.Thread.Sleep(200);

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            fbd.Description = "フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            //fbd.SelectedPath = @"Z:\Interstage\J2EE\var\deployment\ijserver\Cloud11\apps\Cloud11.war\WEB-INF\classes\jp\fujitsu\saas";

            fbd.SelectedPath = System.Configuration.ConfigurationManager.AppSettings.Get("DefaultServerProjectPath");
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                rightRootPath = fbd.SelectedPath + "\\";
                List<string[]> fileNameList = FolderSupport.getFileNameList(rightRootPath, rightRootPath);
                NodeSupport.addRootNode(fileNameList, rightTree);
            }

        }


        private void leftTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.Nodes.Clear();

            string nodePath = leftRootPath + NodeSupport.getNodePath(e.Node);
            List<string[]> subFileNameList = FolderSupport.getFileNameList(nodePath, nodePath);
            NodeSupport.addSubNode(subFileNameList, e.Node, leftTree );

            // フォルダの同期展開
            TreeNode[] rightNodes = rightTree.Nodes.Find(e.Node.Name, true);
            if(rightNodes .Length > 0)
            {
                TreeNode  rightNode = rightNodes[0];
                rightNode.Nodes .Clear();
                string rightNodePath = rightRootPath + NodeSupport.getNodePath(rightNode);
                List<string[]> rightSubFileNameList = FolderSupport.getFileNameList(rightNodePath, rightNodePath);
                NodeSupport.addSubNode(rightSubFileNameList, rightNode);
            }
        }

        private void rightTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.Nodes.Clear();

            string nodePath = rightRootPath + NodeSupport.getNodePath(e.Node);
            List<string[]> subFileNameList = FolderSupport.getFileNameList(nodePath, nodePath);
            NodeSupport.addSubNode(subFileNameList, e.Node);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            leftTree.Nodes.Clear();
            rightTree.Nodes.Clear();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            List<TreeNode> checkedNodes = NodeSupport.getCheckedNode(leftTree.Nodes);
            foreach(TreeNode selectedNode in checkedNodes)
            {
                //TreeNode selectedNode = leftTree.SelectedNode;
                string selectedNodePath = FolderSupport.removeLastSlash(NodeSupport.getNodePath(selectedNode));

                string leftFilePath = leftRootPath + selectedNodePath;

                if (File.Exists(leftFilePath))
                {
                    string rightDirectoryPath = rightRootPath + selectedNodePath;

                    DialogResult result = MessageBox.Show("from:" + leftFilePath + ";\n to:" + rightDirectoryPath, "warning", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        try
                        {
                            System.IO.File.Copy(leftFilePath, rightDirectoryPath, true);
                        }
                        catch(DirectoryNotFoundException ed)
                        {
                            // if folder not exists, create it first
                            string folderPath = Path.GetDirectoryName(rightDirectoryPath);
                            result = MessageBox.Show("Remote Server にフォルダを作成する　: " + folderPath, "warning", MessageBoxButtons.OKCancel);

                            if (result == DialogResult.OK)
                            {
                                Directory.CreateDirectory(folderPath);
                                System.IO.File.Copy(leftFilePath, rightDirectoryPath, true);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("folder selected !!!");
                }

            }

        }

        #endregion
             
    }
}
