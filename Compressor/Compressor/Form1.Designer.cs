namespace Compressor
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
            this.btnCompress = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnUnCompress = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCompress
            // 
            this.btnCompress.Location = new System.Drawing.Point(12, 69);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(92, 39);
            this.btnCompress.TabIndex = 0;
            this.btnCompress.Text = "圧縮";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(110, 32);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(378, 19);
            this.txtFolder.TabIndex = 2;
            // 
            // btnUnCompress
            // 
            this.btnUnCompress.Location = new System.Drawing.Point(110, 69);
            this.btnUnCompress.Name = "btnUnCompress";
            this.btnUnCompress.Size = new System.Drawing.Size(92, 39);
            this.btnUnCompress.TabIndex = 3;
            this.btnUnCompress.Text = "解凍";
            this.btnUnCompress.UseVisualStyleBackColor = true;
            this.btnUnCompress.Click += new System.EventHandler(this.btnUnCompress_Click);
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(12, 30);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(92, 23);
            this.btnFolder.TabIndex = 4;
            this.btnFolder.Text = "Folder";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 199);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.btnUnCompress);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.btnCompress);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnUnCompress;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnFolder;
    }
}

