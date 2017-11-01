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

namespace ClipBoardWatcher
{
	/// <summary>
	/// Summary description for ClipBoardItems.
	/// </summary>
	public class ClipBoardItems : System.Collections.CollectionBase
	{
		private readonly Form ParentForm;
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
		public void RemoveSelectedClipBoardItem(int clipitemindex)
		{
			if (this.Count > 0)
			{
				int index = Form1.objclipboard.Controls.GetChildIndex(this[clipitemindex], false);
				if(index >= 0)
				{
					ParentForm.Controls.Remove(this[index]);
					// Form1.clipboardcopytimings.Remove(this[index].Name);
					this.List.RemoveAt(index);
					if(((index != 0) ||(index == 0 && this.Count>0)) && index != this.Count)
					{
						this[index+1].Top -= 20;
						for(int i=index+2;i<=this.Count-1;i++)
						{
							try
							{
								if(this[i] != null)
								{
									this[i].Top -= 20;
								}
							}
							catch(Exception ex)
							{
								MessageBox.Show(ex.Message);
							}
						}
					}
					else
					{
						try
						{
							if(System.IO.Directory.Exists(@"c:\clipboard"))
							{
								System.IO.Directory.Delete(@"c:\clipboard",true);
							}
						}
						catch{}
						System.IO.Directory.CreateDirectory(@"c:\clipboard");
					}
				}
			}
		}

		public void RemoveAllClipBoardItems()
		{
			try
			{
				int clipitemslength = this.List.Count;
				for(int i = 0; i < clipitemslength; i++)
				{
					ParentForm.Controls.Remove(this[i]);
				}
				// Form1.clipboardcopytimings.Clear();
				this.List.Clear();
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void ClipBoardItemClick(Object sender, System.EventArgs e)
		{
            string objTest = "Text: ";

            string clipdata = sender.ToString().Substring(sender.ToString().IndexOf(objTest) + objTest.Length);
			if(clipdata.Trim().Length > 0)
			{
                // RemoveSelectedClipBoardItem(Form1.selectedClipItemIndex);
                Clipboard.SetDataObject(Form1.selectedClipItemData, true);
            }
        }

		public Button AddNewClipItem(string clipdata, string processpath)
		{
			string filename = DateTime.Now.ToLongTimeString().Replace(":", "").Replace("AM", "").Replace("PM", "") + this.Count.ToString();	
			Button newClipItem = new Button();


            ShellIcon.GetSmallIcon(processpath).ToBitmap().Save(@"c:\clipboard\" + filename+".ico");
			newClipItem.Image = System.Drawing.Image.FromFile(@"c:\clipboard\" + filename+".ico");
			newClipItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			newClipItem.TextAlign  = System.Drawing.ContentAlignment.MiddleRight;
            newClipItem.Dock = DockStyle.Top;
            newClipItem.Height = 30;
            newClipItem.BackColor = Color.ForestGreen;
            newClipItem.ForeColor = Color.White;

            newClipItem.Text = clipdata;
			newClipItem.Name = "temp" + DateTime.Now.ToLongTimeString().Replace(":", "").Replace("AM", "").Replace("PM", "");
			this.List.Add(newClipItem);
			ParentForm.Controls.Add(newClipItem);
			newClipItem.ContextMenuStrip = Form1.objclipboard.cxtmnuclip;
			newClipItem.Click += new System.EventHandler(ClipBoardItemClick);
			newClipItem.MouseDown += new MouseEventHandler(this.newClipItem_MouseDown);
            newClipItem.MouseHover +=new EventHandler(this.newClipItem_MouseHover);
			newClipItem.Tag = this.Count;
			if(Form1.formloaded) 
			{
				Form1.formloaded = false;
				return newClipItem;
			}

			//Form1.clipboardcopytimings.Add(newClipItem.Name, DateTime.Now.ToLongTimeString());
			return newClipItem;
		}

		private void newClipItem_MouseDown(object sender, MouseEventArgs e)
		{
            String objTxt = "Text: ";
            Form1.selectedClipItemData = sender.ToString().Substring(sender.ToString().IndexOf(objTxt) + objTxt.Length);
			Form1.selectedClipItemIndex = Form1.objclipboard.Controls.GetChildIndex((Control)sender);
		}

		private void newClipItem_MouseHover(object sender, EventArgs e)
		{
            String objTxt = "Text: ";
            string clipdata = sender.ToString().Substring(sender.ToString().IndexOf(objTxt) + objTxt.Length);

			if(clipdata.Trim().Length > 0)
			{

                int index = Form1.objclipboard.Controls.GetChildIndex((Control)sender);
                Button b = (Button)Form1.objclipboard.Controls[index];

                //if (Form1.clipboardcopytimings.Count > 0)
                //{
                //    System.Collections.IDictionaryEnumerator iclipdata = Form1.clipboardcopytimings.GetEnumerator();
                //    while (iclipdata.MoveNext())
                //    {
                //        if (iclipdata.Key.ToString().Trim() == b.Name.Trim())
                //        {
                //            string msg = clipdata.Trim() + Environment.NewLine + Environment.NewLine + " copied to clipboard at " + iclipdata.Value.ToString();
                //            Form1.objclipboard.tlpclipboarditem.SetToolTip((Control)sender, msg);
                //            break;
                //        }
                //    }
                //}
                //else
                //{
                //    string msg = clipdata.Trim();
                //    Form1.objclipboard.tlpclipboarditem.SetToolTip((Control)sender, msg);
                //}
                string msg = clipdata.Trim();
                Form1.objclipboard.tlpclipboarditem.SetToolTip((Control)sender, msg);
            }
            Form1.objclipboard.Opacity = 1;
		}
	}
}
