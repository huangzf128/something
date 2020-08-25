namespace FetchRepository
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
            this.button1 = new System.Windows.Forms.Button();
            this.dtPickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dtPickerTo = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocalPath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtServerPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.labLocalPath = new System.Windows.Forms.Label();
            this.labServerPath = new System.Windows.Forms.Label();
            this.btnFindSrvPath = new System.Windows.Forms.Button();
            this.chkJavaClass = new System.Windows.Forms.CheckBox();
            this.txtLocalClassPath = new System.Windows.Forms.TextBox();
            this.btnOpenOutput = new System.Windows.Forms.Button();
            this.btnSelClassPath = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(436, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "GoGoGo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtPickerFrom
            // 
            this.dtPickerFrom.Location = new System.Drawing.Point(53, 29);
            this.dtPickerFrom.Name = "dtPickerFrom";
            this.dtPickerFrom.Size = new System.Drawing.Size(119, 19);
            this.dtPickerFrom.TabIndex = 1;
            // 
            // dtPickerTo
            // 
            this.dtPickerTo.Location = new System.Drawing.Point(53, 54);
            this.dtPickerTo.Name = "dtPickerTo";
            this.dtPickerTo.Size = new System.Drawing.Size(119, 19);
            this.dtPickerTo.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtPickerFrom);
            this.groupBox1.Controls.Add(this.dtPickerTo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // txtLocalPath
            // 
            this.txtLocalPath.Location = new System.Drawing.Point(84, 129);
            this.txtLocalPath.Name = "txtLocalPath";
            this.txtLocalPath.Size = new System.Drawing.Size(395, 19);
            this.txtLocalPath.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(490, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "選択";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtServerPath
            // 
            this.txtServerPath.Location = new System.Drawing.Point(84, 160);
            this.txtServerPath.Name = "txtServerPath";
            this.txtServerPath.Size = new System.Drawing.Size(395, 19);
            this.txtServerPath.TabIndex = 6;
            // 
            // labLocalPath
            // 
            this.labLocalPath.AutoSize = true;
            this.labLocalPath.Location = new System.Drawing.Point(14, 132);
            this.labLocalPath.Name = "labLocalPath";
            this.labLocalPath.Size = new System.Drawing.Size(62, 12);
            this.labLocalPath.TabIndex = 7;
            this.labLocalPath.Text = "ローカルパス";
            // 
            // labServerPath
            // 
            this.labServerPath.AutoSize = true;
            this.labServerPath.Location = new System.Drawing.Point(14, 163);
            this.labServerPath.Name = "labServerPath";
            this.labServerPath.Size = new System.Drawing.Size(64, 12);
            this.labServerPath.TabIndex = 8;
            this.labServerPath.Text = "サーバーパス";
            // 
            // btnFindSrvPath
            // 
            this.btnFindSrvPath.Location = new System.Drawing.Point(490, 160);
            this.btnFindSrvPath.Name = "btnFindSrvPath";
            this.btnFindSrvPath.Size = new System.Drawing.Size(43, 28);
            this.btnFindSrvPath.TabIndex = 9;
            this.btnFindSrvPath.Text = "取得";
            this.btnFindSrvPath.UseVisualStyleBackColor = true;
            this.btnFindSrvPath.Click += new System.EventHandler(this.btnFindSrvPath_Click);
            // 
            // chkJavaClass
            // 
            this.chkJavaClass.AutoSize = true;
            this.chkJavaClass.Location = new System.Drawing.Point(16, 195);
            this.chkJavaClass.Name = "chkJavaClass";
            this.chkJavaClass.Size = new System.Drawing.Size(111, 16);
            this.chkJavaClass.TabIndex = 10;
            this.chkJavaClass.Text = "JavaClassも取得";
            this.chkJavaClass.UseVisualStyleBackColor = true;
            // 
            // txtLocalClassPath
            // 
            this.txtLocalClassPath.Location = new System.Drawing.Point(84, 218);
            this.txtLocalClassPath.Name = "txtLocalClassPath";
            this.txtLocalClassPath.Size = new System.Drawing.Size(395, 19);
            this.txtLocalClassPath.TabIndex = 11;
            // 
            // btnOpenOutput
            // 
            this.btnOpenOutput.Location = new System.Drawing.Point(272, 268);
            this.btnOpenOutput.Name = "btnOpenOutput";
            this.btnOpenOutput.Size = new System.Drawing.Size(116, 23);
            this.btnOpenOutput.TabIndex = 12;
            this.btnOpenOutput.Text = "openOutputFolder";
            this.btnOpenOutput.UseVisualStyleBackColor = true;
            this.btnOpenOutput.Click += new System.EventHandler(this.btnOpenOutput_Click);
            // 
            // btnSelClassPath
            // 
            this.btnSelClassPath.Location = new System.Drawing.Point(490, 218);
            this.btnSelClassPath.Name = "btnSelClassPath";
            this.btnSelClassPath.Size = new System.Drawing.Size(64, 23);
            this.btnSelClassPath.TabIndex = 13;
            this.btnSelClassPath.Text = "選択";
            this.btnSelClassPath.UseVisualStyleBackColor = true;
            this.btnSelClassPath.Click += new System.EventHandler(this.btnSelClassPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 303);
            this.Controls.Add(this.btnSelClassPath);
            this.Controls.Add(this.btnOpenOutput);
            this.Controls.Add(this.txtLocalClassPath);
            this.Controls.Add(this.chkJavaClass);
            this.Controls.Add(this.btnFindSrvPath);
            this.Controls.Add(this.labServerPath);
            this.Controls.Add(this.labLocalPath);
            this.Controls.Add(this.txtServerPath);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtLocalPath);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtPickerFrom;
        private System.Windows.Forms.DateTimePicker dtPickerTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocalPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtServerPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label labLocalPath;
        private System.Windows.Forms.Label labServerPath;
        private System.Windows.Forms.Button btnFindSrvPath;
        private System.Windows.Forms.CheckBox chkJavaClass;
        private System.Windows.Forms.TextBox txtLocalClassPath;
        private System.Windows.Forms.Button btnOpenOutput;
        private System.Windows.Forms.Button btnSelClassPath;
    }
}

