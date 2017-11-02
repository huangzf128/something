using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.IO;

namespace ClipBoardWatcher
{
	/// <summary>
	/// Summary description for ClipBoardItems.
	/// </summary>
	public class ClipBoardItems : System.Collections.CollectionBase
	{
		private readonly Form ParentForm;
        private const string CLIPTEXT = "Text: ";
        public const int MAX_ITEM_COUNT = 10;
        public static bool onWatching = true;

		public ClipBoardItems()
		{			
		}
		public ClipBoardItems(Form mainform)
		{
			ParentForm = mainform;
		}
		public Button this[int Index]
		{
			get
			{
				return (Button)this.List[Index];
			}
		}

        public Button AddNewClipItem(string clipdata, string processpath)
        {
            Button newClipItem = new Button();

            string filename = DateTime.Now.ToString("yyyyMMddHHmmssFFF");
            while (true) {
                try {
                    ShellIcon.GetSmallIcon(processpath).ToBitmap().Save(@"c:\clipboard\" + filename + ".ico");
                    break;
                } catch (Exception ex) {
                    filename = DateTime.Now.ToString("yyyyMMddHHmmssFFF");
                }
            }

            // 直接ロードすると、アププが終了の時に、画像ファイルが削除できない
            // newClipItem.Image = System.Drawing.Image.FromFile(@"c:\clipboard\" + filename + ".ico");
            using (FileStream fs = new FileStream(@"c:\clipboard\" + filename + ".ico", FileMode.Open, FileAccess.Read))
            {
                newClipItem.Image = System.Drawing.Image.FromStream(fs);
            }

            newClipItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            newClipItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            newClipItem.Dock = DockStyle.Top;
            newClipItem.Height = 30;
            newClipItem.BackColor = Color.ForestGreen;
            newClipItem.ForeColor = Color.White;

            newClipItem.Text = clipdata;
            newClipItem.Name = filename;

            this.List.Add(newClipItem);
            ParentForm.Controls.Add(newClipItem);
            newClipItem.ContextMenuStrip = Form1.objclipboard.cxtmnuclip;
            newClipItem.Click += new System.EventHandler(ClipBoardItemClick);
            newClipItem.MouseDown += new MouseEventHandler(this.newClipItem_MouseDown);
            newClipItem.MouseHover += new EventHandler(this.newClipItem_MouseHover);
            if (Form1.formloaded)
            {
                Form1.formloaded = false;
                return newClipItem;
            }

            return newClipItem;
        }

        public void ClipBoardItemClick(Object sender, System.EventArgs e)
		{

            if (Form1.selectedClipItemIndex + 1 == this.Count)
            {
                return;
            }
            string clipdata = sender.ToString().Substring(sender.ToString().IndexOf(CLIPTEXT) + CLIPTEXT.Length);
			if(clipdata.Trim().Length > 0)
			{
                RemoveSelectedClipBoardItem(Form1.selectedClipItemIndex);
                Clipboard.SetDataObject(Form1.selectedClipItemData, true);
            }
        }

		private void newClipItem_MouseDown(object sender, MouseEventArgs e)
		{
            Form1.selectedClipItemData = sender.ToString().Substring(sender.ToString().IndexOf(CLIPTEXT) + CLIPTEXT.Length);
            Form1.selectedClipItemIndex = this.List.IndexOf(sender);
        }

		private void newClipItem_MouseHover(object sender, EventArgs e)
		{
            string clipdata = sender.ToString().Substring(sender.ToString().IndexOf(CLIPTEXT) + CLIPTEXT.Length);

			if(clipdata.Trim().Length > 0)
			{
                string msg = clipdata.Trim();
                Form1.objclipboard.tlpclipboarditem.SetToolTip((Control)sender, msg);
            }
            Form1.objclipboard.Opacity = 1;
		}

        #region Method

        public void RemoveSelectedClipBoardItem(int clipitemindex)
        {
            if (this.Count > 0)
            {
                Control item = (Control)this.List[clipitemindex];
                int index = Form1.objclipboard.Controls.GetChildIndex(this[clipitemindex], false);
                if (index >= 0)
                {
                    this.List.RemoveAt(clipitemindex);
                    ParentForm.Controls.Remove(item);
                }
            }
        }

        public void RemoveAllClipBoardItems()
        {
            try
            {
                int clipitemslength = this.List.Count;
                for (int i = 0; i < clipitemslength; i++)
                {
                    ParentForm.Controls.Remove(this[i]);
                }
                this.List.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
