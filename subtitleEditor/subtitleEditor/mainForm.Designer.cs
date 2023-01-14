namespace subtitleEditor
{
    partial class mainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSelFile = new System.Windows.Forms.TextBox();
            this.btnSelFile = new System.Windows.Forms.Button();
            this.txtSrch = new System.Windows.Forms.TextBox();
            this.btnSrch = new System.Windows.Forms.Button();
            this.btnSrchUp = new System.Windows.Forms.Button();
            this.btnSrchDown = new System.Windows.Forms.Button();
            this.txtTimeSrtS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimeMovieS = new System.Windows.Forms.TextBox();
            this.btnShift = new System.Windows.Forms.Button();
            this.txtRowNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShiftTime = new System.Windows.Forms.TextBox();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtDelLineNoS = new System.Windows.Forms.TextBox();
            this.txtDelLineNoT = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnWriteFile = new System.Windows.Forms.Button();
            this.txtFile = new subtitleEditor.Control.RichTextBoxEx();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSelFile
            // 
            this.txtSelFile.Location = new System.Drawing.Point(93, 26);
            this.txtSelFile.Name = "txtSelFile";
            this.txtSelFile.ReadOnly = true;
            this.txtSelFile.Size = new System.Drawing.Size(410, 21);
            this.txtSelFile.TabIndex = 1;
            // 
            // btnSelFile
            // 
            this.btnSelFile.Location = new System.Drawing.Point(12, 24);
            this.btnSelFile.Name = "btnSelFile";
            this.btnSelFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelFile.TabIndex = 2;
            this.btnSelFile.Text = "SelectFile";
            this.btnSelFile.UseVisualStyleBackColor = true;
            this.btnSelFile.Click += new System.EventHandler(this.btnSelFile_Click);
            // 
            // txtSrch
            // 
            this.txtSrch.Location = new System.Drawing.Point(0, 3);
            this.txtSrch.Name = "txtSrch";
            this.txtSrch.Size = new System.Drawing.Size(304, 21);
            this.txtSrch.TabIndex = 5;
            // 
            // btnSrch
            // 
            this.btnSrch.Location = new System.Drawing.Point(310, 3);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(87, 23);
            this.btnSrch.TabIndex = 6;
            this.btnSrch.Text = "Search";
            this.btnSrch.UseVisualStyleBackColor = true;
            this.btnSrch.Click += new System.EventHandler(this.btnSrch_Click);
            // 
            // btnSrchUp
            // 
            this.btnSrchUp.Location = new System.Drawing.Point(457, 3);
            this.btnSrchUp.Name = "btnSrchUp";
            this.btnSrchUp.Size = new System.Drawing.Size(37, 23);
            this.btnSrchUp.TabIndex = 7;
            this.btnSrchUp.Text = "↑";
            this.btnSrchUp.UseVisualStyleBackColor = true;
            this.btnSrchUp.Click += new System.EventHandler(this.btnSrchUp_Click);
            // 
            // btnSrchDown
            // 
            this.btnSrchDown.Location = new System.Drawing.Point(412, 3);
            this.btnSrchDown.Name = "btnSrchDown";
            this.btnSrchDown.Size = new System.Drawing.Size(39, 23);
            this.btnSrchDown.TabIndex = 8;
            this.btnSrchDown.Text = "↓";
            this.btnSrchDown.UseVisualStyleBackColor = true;
            this.btnSrchDown.Click += new System.EventHandler(this.btnSrchDown_Click);
            // 
            // txtTimeSrtS
            // 
            this.txtTimeSrtS.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTimeSrtS.Location = new System.Drawing.Point(51, 52);
            this.txtTimeSrtS.Name = "txtTimeSrtS";
            this.txtTimeSrtS.Size = new System.Drawing.Size(135, 21);
            this.txtTimeSrtS.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "SRT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "MOVIE";
            // 
            // txtTimeMovieS
            // 
            this.txtTimeMovieS.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTimeMovieS.Location = new System.Drawing.Point(51, 79);
            this.txtTimeMovieS.Name = "txtTimeMovieS";
            this.txtTimeMovieS.Size = new System.Drawing.Size(135, 21);
            this.txtTimeMovieS.TabIndex = 13;
            // 
            // btnShift
            // 
            this.btnShift.Location = new System.Drawing.Point(360, 55);
            this.btnShift.Name = "btnShift";
            this.btnShift.Size = new System.Drawing.Size(58, 45);
            this.btnShift.TabIndex = 15;
            this.btnShift.Text = "Shift";
            this.btnShift.UseVisualStyleBackColor = true;
            this.btnShift.Click += new System.EventHandler(this.btnShift_Click);
            // 
            // txtRowNo
            // 
            this.txtRowNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtRowNo.Location = new System.Drawing.Point(254, 52);
            this.txtRowNo.Name = "txtRowNo";
            this.txtRowNo.Size = new System.Drawing.Size(39, 21);
            this.txtRowNo.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "RowNo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "ShiftTime";
            // 
            // txtShiftTime
            // 
            this.txtShiftTime.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtShiftTime.Location = new System.Drawing.Point(254, 79);
            this.txtShiftTime.Name = "txtShiftTime";
            this.txtShiftTime.Size = new System.Drawing.Size(100, 21);
            this.txtShiftTime.TabIndex = 19;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.txtSrch);
            this.pnlSearch.Controls.Add(this.btnSrch);
            this.pnlSearch.Controls.Add(this.btnSrchUp);
            this.pnlSearch.Controls.Add(this.btnSrchDown);
            this.pnlSearch.Location = new System.Drawing.Point(12, 541);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(539, 36);
            this.pnlSearch.TabIndex = 20;
            // 
            // txtDelLineNoS
            // 
            this.txtDelLineNoS.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDelLineNoS.Location = new System.Drawing.Point(51, 107);
            this.txtDelLineNoS.Name = "txtDelLineNoS";
            this.txtDelLineNoS.Size = new System.Drawing.Size(36, 21);
            this.txtDelLineNoS.TabIndex = 21;
            // 
            // txtDelLineNoT
            // 
            this.txtDelLineNoT.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtDelLineNoT.Location = new System.Drawing.Point(93, 107);
            this.txtDelLineNoT.Name = "txtDelLineNoT";
            this.txtDelLineNoT.Size = new System.Drawing.Size(38, 21);
            this.txtDelLineNoT.TabIndex = 22;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(149, 105);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 23;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnWriteFile
            // 
            this.btnWriteFile.Location = new System.Drawing.Point(239, 106);
            this.btnWriteFile.Name = "btnWriteFile";
            this.btnWriteFile.Size = new System.Drawing.Size(77, 24);
            this.btnWriteFile.TabIndex = 24;
            this.btnWriteFile.Text = "Write";
            this.btnWriteFile.UseVisualStyleBackColor = true;
            this.btnWriteFile.Click += new System.EventHandler(this.btnWriteFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.BackColor = System.Drawing.Color.Cornsilk;
            this.txtFile.Location = new System.Drawing.Point(12, 136);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(491, 399);
            this.txtFile.TabIndex = 3;
            this.txtFile.Text = "";
            this.txtFile.DoubleClick += new System.EventHandler(this.txtFile_DoubleClick);
            this.txtFile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtFile_MouseMove);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 580);
            this.Controls.Add(this.btnWriteFile);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.txtDelLineNoT);
            this.Controls.Add(this.txtDelLineNoS);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.txtShiftTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRowNo);
            this.Controls.Add(this.btnShift);
            this.Controls.Add(this.txtTimeMovieS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimeSrtS);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnSelFile);
            this.Controls.Add(this.txtSelFile);
            this.Name = "mainForm";
            this.Text = "subtitleEditor";
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSelFile;
        private System.Windows.Forms.Button btnSelFile;
        private Control.RichTextBoxEx txtFile;
        private System.Windows.Forms.TextBox txtSrch;
        private System.Windows.Forms.Button btnSrch;
        private System.Windows.Forms.Button btnSrchUp;
        private System.Windows.Forms.Button btnSrchDown;
        private System.Windows.Forms.TextBox txtTimeSrtS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTimeMovieS;
        private System.Windows.Forms.Button btnShift;
        private System.Windows.Forms.TextBox txtRowNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtShiftTime;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtDelLineNoS;
        private System.Windows.Forms.TextBox txtDelLineNoT;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnWriteFile;
    }
}

