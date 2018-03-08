namespace SnapForm
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.grd = new System.Windows.Forms.DataGridView();
            this.topPnl = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.mainPnl = new System.Windows.Forms.Panel();
            this.basePnl = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            this.topPnl.SuspendLayout();
            this.mainPnl.SuspendLayout();
            this.basePnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(188, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open Storage";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grd
            // 
            this.grd.AllowDrop = true;
            this.grd.AllowUserToAddRows = false;
            this.grd.AllowUserToDeleteRows = false;
            this.grd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.grd.BackgroundColor = System.Drawing.Color.BlanchedAlmond;
            this.grd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grd.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grd.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd.DefaultCellStyle = dataGridViewCellStyle1;
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(0, 0);
            this.grd.MultiSelect = false;
            this.grd.Name = "grd";
            this.grd.ReadOnly = true;
            this.grd.RowHeadersVisible = false;
            this.grd.RowTemplate.Height = 21;
            this.grd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grd.Size = new System.Drawing.Size(292, 298);
            this.grd.TabIndex = 4;
            this.grd.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_CellDoubleClick);
            this.grd.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grd_CellMouseDown);
            this.grd.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.grd.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragEnter);
            this.grd.MouseLeave += new System.EventHandler(this.MouseLeave);
            // 
            // topPnl
            // 
            this.topPnl.Controls.Add(this.button2);
            this.topPnl.Controls.Add(this.button1);
            this.topPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPnl.Location = new System.Drawing.Point(0, 0);
            this.topPnl.Name = "topPnl";
            this.topPnl.Size = new System.Drawing.Size(292, 98);
            this.topPnl.TabIndex = 3;
            this.topPnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_MouseDown);
            this.topPnl.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.topPnl.MouseHover += new System.EventHandler(this.pnl_MouseHover);
            this.topPnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_MouseMove);
            this.topPnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_MouseUp);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(188, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mainPnl
            // 
            this.mainPnl.Controls.Add(this.grd);
            this.mainPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainPnl.Location = new System.Drawing.Point(0, 98);
            this.mainPnl.Name = "mainPnl";
            this.mainPnl.Size = new System.Drawing.Size(292, 298);
            this.mainPnl.TabIndex = 5;
            // 
            // basePnl
            // 
            this.basePnl.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.basePnl.Controls.Add(this.mainPnl);
            this.basePnl.Controls.Add(this.topPnl);
            this.basePnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.basePnl.Location = new System.Drawing.Point(0, 0);
            this.basePnl.Name = "basePnl";
            this.basePnl.Size = new System.Drawing.Size(292, 486);
            this.basePnl.TabIndex = 6;
            this.basePnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_MouseDown);
            this.basePnl.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.basePnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_MouseMove);
            this.basePnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_MouseUp);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 486);
            this.Controls.Add(this.basePnl);
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quick";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            this.topPnl.ResumeLayout(false);
            this.mainPnl.ResumeLayout(false);
            this.basePnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView grd;
        private System.Windows.Forms.Panel topPnl;
        private System.Windows.Forms.Panel mainPnl;
        private System.Windows.Forms.Panel basePnl;
        private System.Windows.Forms.Button button2;
    }
}

