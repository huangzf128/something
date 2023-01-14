using subtitleEditor.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace subtitleEditor
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }


        #region Event
        private void btnSelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ofd.InitialDirectory = @"E:\";
            ofd.Filter = "字幕文件|*.srt|所有文件|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "開くファイルを選択してください";
            ofd.RestoreDirectory = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.RestoreDirectory = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtSelFile.Text = ofd.FileName;

                if (!System.IO.File.Exists(txtSelFile.Text)) return;

                string text = System.IO.File.ReadAllText(txtSelFile.Text);
                txtFile.Text = text;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(txtSelFile.Text)) return;

            string text = System.IO.File.ReadAllText(txtSelFile.Text);
            txtFile.Text = text;
        }

        private void txtFile_MouseMove(object sender, MouseEventArgs e)
        {
            return;
            if (txtFile.TextLength == 0) return;
            txtFile.Focus();

            //Point pt = new Point(Cursor.Position.X, Cursor.Position.Y);
            //pt = txtFile.PointToClient(pt);
            Point pt = new Point(e.X, e.Y);
            int lineNum = txtFile.GetLineFromCharIndex(txtFile.GetCharIndexFromPosition(pt));
            if (txtFile.isBlankRow(lineNum)) return;

            int selStartLineNum = lineNum;
            int selEndLineNum = lineNum;
            while (!txtFile.isBlankRow(selStartLineNum - 1))
            {
                selStartLineNum--;
            }
            while (!txtFile.isBlankRow(selEndLineNum + 1))
            {
                selEndLineNum++;
            }
            txtFile.selectMulitRow(selStartLineNum, selEndLineNum);
        }

        #endregion

#region Search
        private void btnSrch_Click(object sender, EventArgs e)
        {
            if (txtSrch.Text.Length == 0) return;

            txtFile.Focus();
            int pos = txtFile.SearchWordPositionDown(txtSrch.Text, 0);
            if (pos == -1) return;

            txtFile.Select(pos, txtSrch.Text.Length);
            txtFile.SelectionColor = Color.Blue;

        }

        private void btnSrchDown_Click(object sender, EventArgs e)
        {
            if (txtSrch.Text.Length == 0) return;

            txtFile.Focus();
            int pos = txtFile.SearchWordPositionDown(txtSrch.Text, txtFile.getCurrentRowNo() + 1);
            if (pos >= 0)
            {
                txtFile.Select(pos, txtSrch.Text.Length);
                txtFile.SelectionColor = Color.Blue;
            }
        }

        private void btnSrchUp_Click(object sender, EventArgs e)
        {
            if (txtSrch.Text.Length == 0) return;

            txtFile.Focus();
            int currentLine = txtFile.getCurrentRowNo();

            int pos = txtFile.SearchWordPositionUp(txtSrch.Text, txtFile.getCurrentRowNo() - 1);
            if (pos >= 0)
            {
                txtFile.Select(pos, txtSrch.Text.Length);
                txtFile.SelectionColor = Color.Blue;
            }
        }
#endregion


        private void txtFile_DoubleClick(object sender, EventArgs e)
        {
            int rowNo = txtFile.getCurrentRowNo();
            if (rowNo == 0) return;

            for (; rowNo >= 0; rowNo--)
            {
                if (rowNo < 1 || txtFile.isBlankRow(rowNo)) return;
                if (SrtUtil.isTimeLine(txtFile.Lines[rowNo]))
                {
                    break;
                }
            }
            MatchCollection match = SrtUtil.parseTime(txtFile.Lines[rowNo]);
            if (match.Count == 2)
            {
                txtTimeSrtS.Text = match[0].Value;
                txtRowNo.Text = rowNo.ToString();
            }
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            if (txtTimeSrtS.Text.Length == 0 || txtTimeMovieS.Text.Length == 0) return;
            // time
            DateTime srtTime = SrtUtil.str2DateTime(txtTimeSrtS.Text, SrtUtil.TIME_FORMART);
            DateTime movieTime = SrtUtil.str2DateTime(txtTimeMovieS.Text, SrtUtil.TIME_FORMART);

            TimeSpan ts = movieTime.Subtract(srtTime);
            txtShiftTime.Text = ts.ToString("c");

            // file
            //if (File.Exists(txtSelFile.Text + ".bak"))
            //{
            //    File.Delete(txtSelFile.Text + ".bak");
            //}
            File.Copy(txtSelFile.Text, txtSelFile.Text + "_" + DateTime.Now.ToString("HHmmss"));
            string[] lines = File.ReadAllLines(txtSelFile.Text);
            for (int i = int.Parse(txtRowNo.Text); i < lines.Length; i++)
            {
                string line = lines[i];
                if (SrtUtil.isTimeLine(line))
                {
                    lines[i] = SrtUtil.shifeTimeLine(line, ts);
                }
            }
            //txtFile.Clear();
            txtFile.Lines = lines;
            txtTimeSrtS.Text = txtTimeMovieS.Text;
            txtShiftTime.Text = "";
            //File.WriteAllLines(txtSelFile.Text, lines);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtDelLineNoS.Text.Length == 0 || txtDelLineNoT.Text.Length == 0) return;

            int lineNoStart = int.Parse(txtDelLineNoS.Text);
            int lineNoEnd = int.Parse(txtDelLineNoT.Text);

            List<string> list = txtFile.Lines.ToList<string>();

            for (int i = lineNoEnd; i >= lineNoStart ; i--)
            {
                list.RemoveAt(i);
            }

            txtFile.Lines = list.ToArray();
        }

        private void btnWriteFile_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(txtSelFile.Text, txtFile.Lines);
        }
    }
}
