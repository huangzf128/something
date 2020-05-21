using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clickonce
{
    class FileMover
    {
        public String sourceDir { get; set; }
        public String lastTargetDir { get; set; }
        public String targetDir { get; set; }

        public string openFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            
            ofd.FilterIndex = 2;
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;
            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                return ofd.FileName;
            }

            return null;
        }

        public string selectFolder(String defaultDir)
        {
            FolderBrowserDialog fbDialog = new FolderBrowserDialog();

            // ダイアログの説明文を指定する
            fbDialog.Description = "ダイアログの説明文";

            // デフォルトのフォルダを指定する
            fbDialog.SelectedPath = defaultDir;

            // 「新しいフォルダーの作成する」ボタンを表示する
            fbDialog.ShowNewFolderButton = true;

            //フォルダを選択するダイアログを表示する
            if (fbDialog.ShowDialog() == DialogResult.OK)
            {
                return fbDialog.SelectedPath;
            }
            else
            {
                Console.WriteLine("キャンセルされました");
            }
            return null;
        }

        public  void copyFile(List<String> files)
        {
            foreach (String file in files)
            {
                File.Copy(Path.Combine(this.sourceDir, file), Path.Combine(this.targetDir, file), true);
            }
        }

        public  void removeDeployFile(List<String> files)
        {
            foreach (String file in files)
            {
                String filePath = Path.Combine(this.targetDir, file) + ".deploy";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);

                }
            }
        }

        public  List<string> getSourceFileListByExt(String ext, String filter)
        {
            DirectoryInfo d = new DirectoryInfo(sourceDir);
            FileInfo[] Files = d.GetFiles("*." + ext);
            List<String> files = new List<String>();
            foreach (FileInfo file in Files)
            {
                if (Regex.IsMatch(file.Name, filter)) {
                    files.Add(file.Name);
                }
            }
            return files;
        }

        public void createTargetFolder()
        {
            String lastFolderName = new DirectoryInfo(this.lastTargetDir).Name;
            String lastFolderPath = new DirectoryInfo(this.lastTargetDir).Parent.FullName;
            DateTime now = DateTime.Now;

            GroupCollection gc = Regex.Match(lastFolderName, @"(S.+?)_.+?_.+?_(.+?)_(.+?)").Groups;

            String newFolder = gc[1] + "_" + now.ToString("yy") + "_" + now.ToString("MM") + "_" + now.ToString("dd") + "_";
            if (Int32.Parse(gc[2].ToString()) == now.Day)
            {
                newFolder += (Int32.Parse(gc[3].ToString()) + 1);
            } else
            {
                newFolder += 1;
            }


            this.targetDir = Path.Combine(lastFolderPath, newFolder);

            if (!Directory.Exists(targetDir)) {
                Directory.CreateDirectory(targetDir);
            }            
        }

        public void CopyDirectory(string sourceDirName, string destDirName) {
            //コピー先のディレクトリがないときは作る
            if (!System.IO.Directory.Exists(destDirName)) {
                System.IO.Directory.CreateDirectory(destDirName);
                //属性もコピー
                System.IO.File.SetAttributes(destDirName, System.IO.File.GetAttributes(sourceDirName));
            }

            //コピー先のディレクトリ名の末尾に"\"をつける
            if (destDirName[destDirName.Length - 1] !=
                    System.IO.Path.DirectorySeparatorChar)
                destDirName = destDirName + System.IO.Path.DirectorySeparatorChar;

            //コピー元のディレクトリにあるファイルをコピー
            string[] files = System.IO.Directory.GetFiles(sourceDirName);
            foreach (string file in files)
                System.IO.File.Copy(file,
                    destDirName + System.IO.Path.GetFileName(file), true);

            //コピー元のディレクトリにあるディレクトリについて、再帰的に呼び出す
            string[] dirs = System.IO.Directory.GetDirectories(sourceDirName);
            foreach (string dir in dirs)
                CopyDirectory(dir, destDirName + System.IO.Path.GetFileName(dir));
        }
    }
}
