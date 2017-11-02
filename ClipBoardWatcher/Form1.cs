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
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components;
        public System.Threading.Timer t = null;
        public System.Windows.Forms.ToolTip tlpclipboarditem;
        public static Form1 objclipboard = null;
        public static string selectedClipItemData = "";
        public static int selectedClipItemIndex = 0;
        public static bool formloaded = false;
        public static ClipBoardItems MyClipItems = null;
        public System.Windows.Forms.ContextMenuStrip cxtmnuclip;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy2ClipBoard;
        public static string prevclipboardcontents = "";

        // public static Hashtable clipboardcopytimings = null;
        private System.Windows.Forms.ToolStripMenuItem mnuDelClipBoard;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip cxttaskbar;
        private System.Windows.Forms.ToolStripMenuItem mnuShowHideForm;
        private System.Windows.Forms.ToolStripMenuItem mnuOnTop;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelClipBoardAll;
        private Button btnSwitch;
        public DelegateGetAndDisplayClipData m_DelegateGetAndDisplayClipData;
        public delegate void DelegateGetAndDisplayClipData();

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top + 20);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                notifyIcon1.Dispose();

            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tlpclipboarditem = new System.Windows.Forms.ToolTip(this.components);
            this.cxtmnuclip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopy2ClipBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelClipBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelClipBoardAll = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cxttaskbar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuShowHideForm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.cxtmnuclip.SuspendLayout();
            this.cxttaskbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpclipboarditem
            // 
            this.tlpclipboarditem.AutoPopDelay = 5000;
            this.tlpclipboarditem.InitialDelay = 200;
            this.tlpclipboarditem.ReshowDelay = 100;
            // 
            // cxtmnuclip
            // 
            this.cxtmnuclip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopy2ClipBoard,
            this.mnuDelClipBoard,
            this.mnuDelClipBoardAll});
            this.cxtmnuclip.Name = "cxtmnuclip";
            this.cxtmnuclip.Size = new System.Drawing.Size(222, 70);
            // 
            // mnuCopy2ClipBoard
            // 
            this.mnuCopy2ClipBoard.Name = "mnuCopy2ClipBoard";
            this.mnuCopy2ClipBoard.Size = new System.Drawing.Size(221, 22);
            this.mnuCopy2ClipBoard.Text = "Copy To ClipBoard";
            this.mnuCopy2ClipBoard.Click += new System.EventHandler(this.mnuCopy2ClipBoard_Click);
            // 
            // mnuDelClipBoard
            // 
            this.mnuDelClipBoard.Name = "mnuDelClipBoard";
            this.mnuDelClipBoard.Size = new System.Drawing.Size(221, 22);
            this.mnuDelClipBoard.Text = "Remove This ClipBoard Data";
            this.mnuDelClipBoard.Click += new System.EventHandler(this.mnuDelClipBoard_Click);
            // 
            // mnuDelClipBoardAll
            // 
            this.mnuDelClipBoardAll.Name = "mnuDelClipBoardAll";
            this.mnuDelClipBoardAll.Size = new System.Drawing.Size(221, 22);
            this.mnuDelClipBoardAll.Text = "Remove All ClipBoard items";
            this.mnuDelClipBoardAll.Click += new System.EventHandler(this.mnuDelClipBoardAll_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cxttaskbar;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ClipBoard Watcher is in Visible Mode";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // cxttaskbar
            // 
            this.cxttaskbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowHideForm,
            this.mnuOnTop,
            this.mnuExit});
            this.cxttaskbar.Name = "cxttaskbar";
            this.cxttaskbar.Size = new System.Drawing.Size(143, 70);
            // 
            // mnuShowHideForm
            // 
            this.mnuShowHideForm.Name = "mnuShowHideForm";
            this.mnuShowHideForm.Size = new System.Drawing.Size(142, 22);
            this.mnuShowHideForm.Text = "&Hide";
            this.mnuShowHideForm.Click += new System.EventHandler(this.mnuShowHideForm_Click);
            // 
            // mnuOnTop
            // 
            this.mnuOnTop.Checked = true;
            this.mnuOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuOnTop.Name = "mnuOnTop";
            this.mnuOnTop.Size = new System.Drawing.Size(142, 22);
            this.mnuOnTop.Text = "Show on Top";
            this.mnuOnTop.Click += new System.EventHandler(this.mnuOnTop_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(142, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // btnSwitch
            // 
            this.btnSwitch.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSwitch.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSwitch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSwitch.Location = new System.Drawing.Point(12, 351);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(94, 28);
            this.btnSwitch.TabIndex = 2;
            this.btnSwitch.Text = "Watching...";
            this.btnSwitch.UseVisualStyleBackColor = false;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(184, 386);
            this.Controls.Add(this.btnSwitch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(850, 0);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            this.cxtmnuclip.ResumeLayout(false);
            this.cxttaskbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            objclipboard = new Form1();
            objclipboard.Show();
            Application.Run();
        }

        private void Form1_Deactivate(object sender, System.EventArgs e)
        {
            try
            {
                objclipboard.Opacity = 0.4;
            }
            catch { }
        }

        private void LoadClipBoardData(object temp)
        {
            try
            {
                objclipboard.Invoke(m_DelegateGetAndDisplayClipData);
            }
            catch { }
        }

        private void GetAndDisplayClipData()
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData != null)
            {
                string currentclipboardcontents = "";
                try
                {
                    currentclipboardcontents = iData.GetData(DataFormats.StringFormat).ToString();
                    if (currentclipboardcontents.ToString().Trim() == "") return;
                }
                catch { return; }

                if (prevclipboardcontents != currentclipboardcontents)
                {
                    IntPtr hwnd = APIFuncs.getforegroundWindow();
                    Int32 pid = APIFuncs.GetWindowProcessID(hwnd);
                    Process p = Process.GetProcessById(pid);
                    prevclipboardcontents = currentclipboardcontents;
                    MyClipItems.AddNewClipItem(currentclipboardcontents, p.MainModule.FileName);
                }
            }
        }


        #region ============================ Event ==================================

        #region ★★★★★ Form ★★★★★

        private void Form1_Load(object sender, System.EventArgs e)
        {
            if (System.IO.Directory.Exists(@"c:\clipboard"))
            {
                System.IO.Directory.Delete(@"c:\clipboard", true);
            }
            System.IO.Directory.CreateDirectory(@"c:\clipboard");

            // clipboardcopytimings = new Hashtable();
            formloaded = true;

            MyClipItems = new ClipBoardItems(this);

            //m_DelegateGetAndDisplayClipData = new DelegateGetAndDisplayClipData(this.GetAndDisplayClipData);
            //System.Threading.TimerCallback timerDelegate = new System.Threading.TimerCallback(this.LoadClipBoardData);
            //t = new System.Threading.Timer(timerDelegate, null, 0, 1000);

            APIFuncs.AddClipboardListener(this.Handle);
        }

        private void Form1_Closed(object sender, System.EventArgs e)
        {
            try
            {
                APIFuncs.RemoveClipboardListener(this.Handle);
                if (System.IO.Directory.Exists(@"c:\clipboard"))
                {
                    System.IO.Directory.Delete(@"c:\clipboard", true);
                }
                Application.Exit();
            }
            catch(Exception ex)
            {
                Application.Exit();
            }
        }

        private void Form1_Activated(object sender, System.EventArgs e)
        {
            objclipboard.Opacity = 1;
        }

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.U)
            {
                try
                {
                    if (Form1.objclipboard.Opacity < 1)
                        Form1.objclipboard.Opacity += 0.1;
                }
                catch { }
            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                try
                {
                    if (Form1.objclipboard.Opacity > 0.1)
                        Form1.objclipboard.Opacity -= 0.1;
                }
                catch { }
            }
        }

        private void Form1_MouseLeave(object sender, System.EventArgs e)
        {
        }

        private void Form1_MouseEnter(object sender, System.EventArgs e)
        {
            objclipboard.Opacity = 1;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == APIFuncs.WM_CLIPBOARDUPDATE)
            {
                IDataObject iData = Clipboard.GetDataObject();      // Clipboard's data.

                /* Depending on the clipboard's current data format we can process the data differently. 
                 * Feel free to add more checks if you want to process more formats. */
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    string text = (string)iData.GetData(DataFormats.Text);

                    //try
                    //{
                    //    objclipboard.Invoke(m_DelegateGetAndDisplayClipData);
                    //}
                    //catch { }

                    if (!ClipBoardItems.onWatching || ClipBoardItems.MAX_ITEM_COUNT <= MyClipItems.Count)
                    {
                        return;
                    }
                    GetAndDisplayClipData();
                }
                else if (iData.GetDataPresent(DataFormats.Bitmap))
                {
                    // Bitmap image = (Bitmap)iData.GetData(DataFormats.Bitmap);
                    // do something with it
                }
            }
        }

        #endregion


        #region ★★★★★ Menu Item ★★★★★

        private void mnuCopy2ClipBoard_Click(object sender, System.EventArgs e)
        {

            Clipboard.SetDataObject(selectedClipItemData, true);
        }

        private void mnuDelClipBoard_Click(object sender, System.EventArgs e)
        {
            MyClipItems.RemoveSelectedClipBoardItem(selectedClipItemIndex);
        }

        private void mnuExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void mnuDelClipBoardAll_Click(object sender, System.EventArgs e)
        {
            MyClipItems.RemoveAllClipBoardItems();
        }

        private void mnuShowHideForm_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (Form1.objclipboard.Visible == true)
                {
                    Form1.objclipboard.Visible = false;
                    mnuShowHideForm.Text = "Show";
                    notifyIcon1.Text = "ClipBoard Watcher is in Invisible Mode";
                }
                else
                {
                    Form1.objclipboard.Visible = true;
                    mnuShowHideForm.Text = "Hide";
                    notifyIcon1.Text = "ClipBoard Watcher is in Visible Mode";
                }
            }
            catch { }
        }

        private void mnuOnTop_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (mnuOnTop.Checked)
                {
                    mnuOnTop.Checked = false;
                    Form1.objclipboard.TopMost = false;
                }
                else
                {
                    mnuOnTop.Checked = true;
                    Form1.objclipboard.TopMost = true;
                }
            }
            catch { }
        }

        private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
        {
            if (Form1.objclipboard.Visible)
            {
                Form1.objclipboard.Visible = false;
                notifyIcon1.Text = "ClipBoard Watcher is in Invisible Mode";
            }
            else
            {
                Form1.objclipboard.Visible = true;
                notifyIcon1.Text = "ClipBoard Watcher is in Visible Mode";
            }
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            ClipBoardItems.onWatching = !ClipBoardItems.onWatching;

            if (ClipBoardItems.onWatching)
            {
                btnSwitch.Text = "Watching...";
            } else
            {
                btnSwitch.Text = "Pause";
            }
        }

        #endregion

        #endregion

        #region no use
        /*
            タスクバーに表示
            objclipboard.ShowInTaskbar = true;
            タイトルバー表示
            objclipboard.ControlBox = false;

            clipboard 公開
			BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
			provider.TypeFilterLevel = TypeFilterLevel.Full;

            TcpChannel channel;
            IDictionary props = new Hashtable();
			props["port"] = 4820;
			channel = new TcpChannel(props, null, provider);
			//TcpChannel channel = new TcpChannel(4820);
			ChannelServices.RegisterChannel(channel);
			RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteClipboard), "ClipShare",
				WellKnownObjectMode.Singleton);
			// set the callback for when an incoming clipboard event comes in
			RemoteClipboard.SetOnClipReceive(this, new ClipEventHandler(this.AddToClip));


         */
        #endregion

    }
}
