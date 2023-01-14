using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace subtitleEditor.Control
{
    public partial class RichTextBoxEx : System.Windows.Forms.RichTextBox
    {
        public enum DIRECTION {
            up, down
        }

        private CurrentSelection curSelection = new CurrentSelection();
        public CurrentSelection currentSelection
        {
            get { return curSelection; }
        }

        public RichTextBoxEx()
        {
            InitializeComponent();
        }

        public bool isBlankRow(int lineNum)
        {
            if (lineNum < 0 || lineNum >= this.Lines.Length) return true;
            return this.Lines[lineNum].ToString().Length == 0;
        }

        public int getCurrentRowNo()
        {
            return this.GetLineFromCharIndex(this.SelectionStart);
        }

        #region Select

        public void selectMulitRow(int startLineNum, int endLineNum)
        {
            if (startLineNum < 0 || endLineNum > this.Lines.Length) return;

            this.Focus();
            this.currentSelection.hasSelection = true;
            this.currentSelection.startLineNo = startLineNum;
            this.currentSelection.endLineNo = endLineNum;

            int startIndex = this.GetFirstCharIndexFromLine(startLineNum);
            int strLen = 0;
            while (startLineNum <= endLineNum)
            {
                strLen += this.Lines[startLineNum++].ToString().Length + 1;
            }
            this.Select(startIndex, strLen);
        }

        public void selectOneRow(int lineNum)
        {
            this.Focus();
            int startIndex = this.GetFirstCharIndexFromLine(lineNum);
            this.Select(startIndex, this.Lines[lineNum].ToString().Length);
        }
        #endregion


        #region Search

        public int SearchWordPositionUp(string word, int startLineNo = 0)
        {
            if (startLineNo < 0) return -1;
            return SearchWordPosition(word, startLineNo, DIRECTION.up);
        }
        public int SearchWordPositionDown(string word, int startLineNo = 0)
        {
            if (startLineNo > this.Lines.Length) return -1;
            return SearchWordPosition(word, startLineNo, DIRECTION.down);
        }
        private int SearchWordPosition(string word, int startLineNo = 0, DIRECTION direction = DIRECTION.down)
        {
            if (direction == DIRECTION.down)
            {
                for (int i = startLineNo; i < this.Lines.Length; i++)
                {
                    int index = this.Lines[i].IndexOf(word);
                    if (index >= 0)
                    {
                        return this.GetFirstCharIndexFromLine(i) + index;
                    }
                }
            } 
            else
            {
                for (int i = startLineNo; i >=0; i--)
                {
                    int index = this.Lines[i].IndexOf(word);
                    if (index >= 0)
                    {
                        return this.GetFirstCharIndexFromLine(i) + index;
                    }
                }
            }
            return -1;
        }
        #endregion
    }

    public class CurrentSelection
    {
        public int startLineNo = 0;
        public int endLineNo = 0;
        public bool hasSelection = false;
    }
}
