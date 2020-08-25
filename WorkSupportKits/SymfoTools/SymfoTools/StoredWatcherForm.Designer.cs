namespace SymfoTools
{
    partial class StoredWatcherForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.btnDel = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnExeProc = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.richTxtStoredDef = new System.Windows.Forms.RichTextBox();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.butTable = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSrchCaller = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(178, 22);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(60, 25);
            this.btnDel.TabIndex = 23;
            this.btnDel.Text = "Remove";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(778, 3);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(117, 44);
            this.txtInfo.TabIndex = 22;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(710, -11);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(70, 12);
            this.Label4.TabIndex = 21;
            this.Label4.Text = "ストアド情報：";
            // 
            // btnExeProc
            // 
            this.btnExeProc.Location = new System.Drawing.Point(92, 22);
            this.btnExeProc.Name = "btnExeProc";
            this.btnExeProc.Size = new System.Drawing.Size(80, 25);
            this.btnExeProc.TabIndex = 20;
            this.btnExeProc.Text = "実行(Call)";
            this.btnExeProc.UseVisualStyleBackColor = true;
            this.btnExeProc.Click += new System.EventHandler(this.btnExeProc_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(12, 11);
            this.btnReload.Margin = new System.Windows.Forms.Padding(2);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 36);
            this.btnReload.TabIndex = 19;
            this.btnReload.Text = "再読込み";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // richTxtStoredDef
            // 
            this.richTxtStoredDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.richTxtStoredDef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTxtStoredDef.Location = new System.Drawing.Point(144, 55);
            this.richTxtStoredDef.Margin = new System.Windows.Forms.Padding(2);
            this.richTxtStoredDef.Name = "richTxtStoredDef";
            this.richTxtStoredDef.Size = new System.Drawing.Size(994, 648);
            this.richTxtStoredDef.TabIndex = 18;
            this.richTxtStoredDef.Text = "";
            // 
            // ListBox1
            // 
            this.ListBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.ItemHeight = 12;
            this.ListBox1.Location = new System.Drawing.Point(0, 0);
            this.ListBox1.Margin = new System.Windows.Forms.Padding(2);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(144, 703);
            this.ListBox1.TabIndex = 14;
            this.ListBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // butTable
            // 
            this.butTable.Location = new System.Drawing.Point(921, 7);
            this.butTable.Name = "butTable";
            this.butTable.Size = new System.Drawing.Size(61, 40);
            this.butTable.TabIndex = 25;
            this.butTable.Text = "Table";
            this.butTable.UseVisualStyleBackColor = true;
            this.butTable.Click += new System.EventHandler(this.butTable_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSrchCaller);
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Controls.Add(this.butTable);
            this.panel1.Controls.Add(this.btnExeProc);
            this.panel1.Controls.Add(this.txtInfo);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(144, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 55);
            this.panel1.TabIndex = 1;
            // 
            // btnSrchCaller
            // 
            this.btnSrchCaller.Location = new System.Drawing.Point(244, 11);
            this.btnSrchCaller.Name = "btnSrchCaller";
            this.btnSrchCaller.Size = new System.Drawing.Size(75, 36);
            this.btnSrchCaller.TabIndex = 26;
            this.btnSrchCaller.Text = "呼出元検索";
            this.btnSrchCaller.UseVisualStyleBackColor = true;
            this.btnSrchCaller.Click += new System.EventHandler(this.btnSrchCaller_Click);
            // 
            // StoredWatcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 703);
            this.Controls.Add(this.richTxtStoredDef);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.ListBox1);
            this.Name = "StoredWatcherForm";
            this.Text = "STORED DEFINITION WATCHER";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button btnDel;
        internal System.Windows.Forms.TextBox txtInfo;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnExeProc;
        internal System.Windows.Forms.Button btnReload;
        internal System.Windows.Forms.RichTextBox richTxtStoredDef;
        internal System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.Button butTable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSrchCaller;
    }
}

