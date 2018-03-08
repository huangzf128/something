using Microsoft.Win32;
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
using static System.Windows.Forms.ListViewItem;

namespace SnapForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private const string STORAGE = "\\Storage\\";
        private const int COL_COUNT = 3;
        private int frmHeigh = 0;
        private int frmWidth = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            frmHeigh = this.Height;
            frmWidth = this.Width;
            initGrid();

            // hide form
            this.Location = new Point(200, SnapDist - 1);
            pnl_MouseUp(null, null);
            HideForm();
        }

        #region "ボタン"

        private void button1_Click(object sender, EventArgs e)
        {
            String storagePath = Path.GetDirectoryName(Application.ExecutablePath) + STORAGE;
            Process.Start(storagePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grd.Rows.Clear();
            ShowFileList();
        }
        #endregion


        #region "フォームSnap"

        private bool isInSnap = false;
        private const int SnapDist = 30;
        private bool DoSnap(int pos, int edge)
        {
            int delta = pos - edge;
            return delta <= SnapDist;
        }

        private void HideForm()
        {
            this.Height = 3;
            this.Width = 150;
            //this.BackColor = Color.Blue;
        }

        private void ResetForm()
        {
            this.Height = frmHeigh;
            this.Width = frmWidth;
            //this.BackColor = Color.Gray;
        }

        #endregion


        #region ごみ箱

        private const int WM_NCHITTEST = 0x84;      // マウスイベントが発生した
        private const int WM_HTCLIENT = 0x1;           // クライアントからマウスイベントがあった
        private const int WM_HTCAPTION = 0x2;          // タイトルからマウスイベントがあった
        private const int WM_MOUSEHOVER = 0x02A1;
        private const int WM_MOUSELEAVE = 0x02A3;

        //protected override void WndProc(ref Message m)
        //{
        //    switch (m.Msg)
        //    {
        //        // マウスイベントが発生するとWM_NCHITTESTメッセージがWindowsからフォームに投げられる
        //        // クライアント領域をクリックされた場合、HTCAPTIONを返す
        //        case WM_MOUSEHOVER:

        //            ResetForm();
        //            return;

        //        case WM_MOUSELEAVE:

        //            if (isInSnap)
        //            {
        //                HideForm();
        //            }
        //            return;

        //        case WM_NCHITTEST:

        //            base.WndProc(ref m);
        //            int result = (int)m.Result;

        //            if (result == WM_HTCLIENT)
        //            {
        //                //m.Result = (IntPtr)WM_HTCAPTION;
        //            }

        //            return;

        //    }

        //    base.WndProc(ref m);
        //}


        //protected override void OnResizeEnd(EventArgs e)
        //{
        //    base.OnResizeEnd(e);
        //    Screen scn = Screen.FromPoint(this.Location);

        //    if (DoSnap(this.Left, scn.WorkingArea.Left))
        //    {
        //        //this.Left = scn.WorkingArea.Left;
        //    }
        //    if (DoSnap(this.Top, scn.WorkingArea.Top))
        //    {
        //        this.Top = scn.WorkingArea.Top;
        //        HideForm();
        //        isInSnap = true;
        //        return;
        //    }
        //    if (DoSnap(scn.WorkingArea.Right, this.Right))
        //    {
        //        //this.Left = scn.WorkingArea.Right - this.Width;
        //    }
        //    if (DoSnap(scn.WorkingArea.Bottom, this.Bottom))
        //    {
        //        //this.Top = scn.WorkingArea.Bottom - this.Height;
        //    }

        //    isInSnap = false;
        //}

        #endregion


        #region "Grid"

        private bool IsFolder(String path)
        {
            FileAttributes attr = File.GetAttributes(path);
            return attr.HasFlag(FileAttributes.Directory);
        }

        private void AddFile(String file)
        {
            int rowIndex = grd.Rows.Count - 1;
            if (rowIndex < 0)
            {
                grd.Rows.Add();
                rowIndex = 0;
            }

            try
            {
                Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(file);
                Bitmap bmp = new Bitmap(icon.Size.Width + 60, icon.Size.Height + 30);

                //Bitmap bmp = FileInfoHelper.GetFileIconAsBitmap(file);

                Graphics grp = Graphics.FromImage(bmp);
                grp.DrawIcon(icon, 30, 0);
                grp.DrawString(Path.GetFileName(file), this.Font, Brushes.Black, 2, icon.Size.Height + 5);

                for (int i = 0; i < COL_COUNT; i++)
                {
                    DataGridViewCell c = grd[i, rowIndex];
                    if (c.Value == null)
                    {
                        c.Value = bmp;
                        c.Tag = file;
                        c.ToolTipText = Path.GetFileName(file);
                        RegistContextMenuToCell(file, c);
                        return;
                    }
                }

                grd.Rows.Add();
                DataGridViewCell cell = grd[0, rowIndex + 1];
                cell.Value = bmp;
                cell.Tag = file;
                cell.ToolTipText = Path.GetFileName(file);
                RegistContextMenuToCell(file, cell);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void initGrid()
        {
            for (int i = 0; i < COL_COUNT; i++)
            {
                DataGridViewImageColumn col = new DataGridViewImageColumn();
                col.Name = i.ToString();
                col.ImageLayout = DataGridViewImageCellLayout.Zoom;
                col.DefaultCellStyle.NullValue = null;
                col.CellTemplate = new DataGridViewImageCellEx();

                grd.Columns.Add(col);
            }

            ShowFileList();
        }

        private void RegistContextMenuToCell(string file, DataGridViewCell cell)
        {
            RegistSupporter rs = new RegistSupporter();
            List<string> appList = rs.RecommendedPrograms(Path.GetExtension(file).TrimStart('.'));

            ContextMenuStrip cm = new ContextMenuStrip();

            cm.Items.Add("Open With 秀丸", Icon.ExtractAssociatedIcon(config.AppSettings.Settings["hidemaru"].Value).ToBitmap(), new System.EventHandler(ContextMenuClick));
            cm.Items.Add("Open With Notepad", Icon.ExtractAssociatedIcon(@"C:\WINDOWS\system32\notepad.exe").ToBitmap(), new System.EventHandler(ContextMenuClick));

            foreach (string app in appList)
            {
                cm.Items.Add(app, null, new System.EventHandler(ContextMenuClick));
            }


            cell.ContextMenuStrip = cm;
        }


        private void ContextMenuClick(Object sender, System.EventArgs e)
        {
            DataGridViewCell cell = grd.CurrentCell;
            

            switch (sender.ToString().Trim())
            {
                case "Open With 秀丸":
                    System.Diagnostics.Process.Start(config.AppSettings.Settings["hidemaru"].Value , cell.Tag.ToString());
                    break;
                case "Open With Notepad":
                    System.Diagnostics.Process.Start("notepad.exe", cell.Tag.ToString());
                    break;
            }
        }

        private void ShowFileList()
        {
            String storagePath = Path.GetDirectoryName(Application.ExecutablePath) + STORAGE;
            List<String> files = Directory.GetFiles(storagePath).ToList();

            for (int i = 0; i < files.Count; i++)
            {
                AddFile(files[i]);
            }
        }


        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            String[] dropped = ((string[])e.Data.GetData(DataFormats.FileDrop));
            List<String> files = dropped.ToList();

            if (!files.Any()) return;


            foreach (string file in files)
            {
                if (IsFolder(file)) return;

                String copyToPath = Path.GetDirectoryName(Application.ExecutablePath) + STORAGE;

                if (!Directory.Exists(copyToPath))
                    Directory.CreateDirectory(copyToPath);

                File.Delete(copyToPath + Path.GetFileName(file));
                File.Move(file, copyToPath + Path.GetFileName(file));

                AddFile(copyToPath + Path.GetFileName(file));
            }
        }

        private void grd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = grd[e.ColumnIndex, e.RowIndex];
            if (cell.Tag != null)
            {
                System.Diagnostics.Process.Start(cell.Tag.ToString());
            }
        }

        private void grd_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Add this
                grd.CurrentCell = grd.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Can leave these here - doesn't hurt
                grd.Rows[e.RowIndex].Selected = true;
                grd.Focus();
            }
        }

        #endregion



        #region "basePne"

        private void pnl_MouseHover(object sender, EventArgs e)
        {
            if (isInSnap)
            {
                ResetForm();
            }
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            if (!isInSnap)
            {
                return;
            }

            Point p = this.PointToClient(Cursor.Position);

            if (p.X <= basePnl.Location.X || p.X >= basePnl.Location.X + basePnl.Width ||
                p.Y <= basePnl.Location.Y || p.Y >= basePnl.Location.Y + basePnl.Height)
            {
                HideForm();
            }
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void pnl_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void pnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void pnl_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;

            Screen scn = Screen.FromPoint(this.Location);
            if (DoSnap(this.Top, scn.WorkingArea.Top))
            {
                this.Top = scn.WorkingArea.Top;
                if (isInSnap == false)
                {
                    frmHeigh = this.Height;
                    frmWidth = this.Width;

                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    isInSnap = true;
                }
                return;
            }
            else
            {
                if (isInSnap)
                {
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                    ResetForm();
                    isInSnap = false;
                }
            }
        }

        #endregion

    }

    public class DataGridViewImageCellEx : DataGridViewImageCell
    {
        public override object DefaultNewRowValue
        {
            get
            {
                return null;
            }
        }
    }
}
