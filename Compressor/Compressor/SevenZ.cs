using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compressor
{
    //　参考サイト：http://niyodiary.cocolog-nifty.com/blog/2009/05/c7z-77e2.html#.A20090506_1_1

    class SevenZ
    {
        [DllImport(@"7-zip32.dll", CharSet = CharSet.Ansi)]
        extern static int SevenZip(
            IntPtr hwnd,            // ウィンドウハンドル
            string szCmdLine,       // コマンドライン
            StringBuilder szOutput, // 処理結果文字列
            int dwSize);            // 引数szOutputの文字列サイズ


        /// <summary>
        /// 7z圧縮[フォルダ指定]
        /// </summary>
        /// <param name="sFolderPath">圧縮対象フォルダ(フルパス指定)</param>
        /// <param name="s7zFilePath">7zファイル名</param>
        public void CompressFolder(string sFolderPath, string s7zFileName)
        {
            lock (typeof(SevenZ))
            {
                StringBuilder sbOutput = new StringBuilder(1024);   // 7-zip32.dll出力文字
                                                                    //---------------------------------------------------------------------------------
                                                                    // sFolderPathの最後が\の場合、\を取り払う
                                                                    //---------------------------------------------------------------------------------
                while (sFolderPath[sFolderPath.Length - 1] == '\\')
                {
                    sFolderPath = sFolderPath.Substring(0, sFolderPath.Length - 1);
                }
                //---------------------------------------------------------------------------------
                // コマンドライン文字列の作成
                //---------------------------------------------------------------------------------
                // a:書庫にファイルを追加
                // -t7z:7形式を指定
                // -hide:処理状況ダイアログ表示の抑止
                // -mmt=on:マルチスレッドモードの設定
                // -y:全ての質問に yes を仮定
                // -r:サブディレクトリの再帰的検索
                string sCmdLine = string.Format(
                    "a -t7z -hide -mmt=on -y -r \"{0}\" \"{1}\\*\"", sFolderPath + "\\" + s7zFileName, sFolderPath);
                //---------------------------------------------------------------------------------
                // 圧縮実行
                //---------------------------------------------------------------------------------
                int iSevenZipRtn = SevenZip((IntPtr)0, sCmdLine, sbOutput, sbOutput.Capacity);
                //---------------------------------------------------------------------------------
                // 成功判定
                //---------------------------------------------------------------------------------
                CheckProc(iSevenZipRtn, sbOutput);

                MessageBox.Show("OK");
            }
        }

        /// <summary>
        /// 7z解凍
        /// </summary>
        /// <param name="s7zFilePath">7zファイル名</param>
        public void ExtractFolder(string s7zFilePath)
        {
            lock (typeof(SevenZ))
            {
                StringBuilder sbOutput = new StringBuilder(1024);   // 7-zip32.dll出力文字
                                                                    //---------------------------------------------------------------------------------
                                                                    // sDustFolderの最後が\の場合、\を取り払う
                                                                    //---------------------------------------------------------------------------------
                while (s7zFilePath[s7zFilePath.Length - 1] == '\\')
                {
                    s7zFilePath = s7zFilePath.Substring(0, s7zFilePath.Length - 1);
                }
                ////---------------------------------------------------------------------------------
                //// 出力先フォルダが存在しなければ作成
                ////---------------------------------------------------------------------------------
                //if (!Directory.Exists(sDustFolder))
                //{
                //    Directory.CreateDirectory(sDustFolder);
                //}
                //---------------------------------------------------------------------------------
                // コマンドライン文字列の作成
                //---------------------------------------------------------------------------------
                // x:解凍
                // -aoa:確認なしで上書き
                // -hide:処理状況ダイアログ表示の抑止
                // -y:全ての質問に yes を仮定
                // -r:サブディレクトリの再帰的検索
                // -o{dir_path}:出力先ディレクトリの設定
                string sCmdLine = string.Format(
                    "x -aoa -hide -y -r \"{0}\" -o\"{1}\"\\*", s7zFilePath, s7zFilePath);
                //---------------------------------------------------------------------------------
                // 解凍実行
                //---------------------------------------------------------------------------------
                int iSevenZipRtn = SevenZip((IntPtr)0, sCmdLine, sbOutput, sbOutput.Capacity);
                //---------------------------------------------------------------------------------
                // 成功判定
                //---------------------------------------------------------------------------------
                CheckProc(iSevenZipRtn, sbOutput);

                MessageBox.Show("OK");
            }
        }

        /// <summary>
        /// SevenZipメソッド成功判定
        /// </summary>
        /// <param name="iSevenZipRtn">SevenZipメソッドの戻り値</param>
        /// <param name="sbLzhOutputString">SevenZipメソッドの第3引数</param>
        private void CheckProc(int iSevenZipRtn, StringBuilder sbLzhOutputString)
        {
            //-------------------------------------------------------------------------------------
            // メソッドの戻り値=0なら正常終了
            //-------------------------------------------------------------------------------------
            if (iSevenZipRtn == 0)
                return;

            string sMsg = string.Format(
                "7z圧縮/解凍処理に失敗:\nエラーコード={0}:\n{1}", iSevenZipRtn, sbLzhOutputString);
            throw new ApplicationException(sMsg);
        }



    }
}
