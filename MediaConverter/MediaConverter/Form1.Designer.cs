namespace WindowsFormsApp1
{
    partial class frmMain
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
            this.pnlHead = new System.Windows.Forms.Panel();
            this.labTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnOpenTarget = new System.Windows.Forms.Button();
            this.labTargetPath = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.rdoWavToFlac = new System.Windows.Forms.RadioButton();
            this.pnlHead.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHead
            // 
            this.pnlHead.Controls.Add(this.labTitle);
            this.pnlHead.Location = new System.Drawing.Point(16, 15);
            this.pnlHead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(889, 99);
            this.pnlHead.TabIndex = 0;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("MS UI Gothic", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labTitle.Location = new System.Drawing.Point(236, 24);
            this.labTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(367, 50);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "MediaConverter";
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.rdoWavToFlac);
            this.pnlBody.Controls.Add(this.btnExecute);
            this.pnlBody.Controls.Add(this.btnOpenTarget);
            this.pnlBody.Controls.Add(this.labTargetPath);
            this.pnlBody.Location = new System.Drawing.Point(16, 138);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(889, 309);
            this.pnlBody.TabIndex = 1;
            // 
            // btnExecute
            // 
            this.btnExecute.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnExecute.Location = new System.Drawing.Point(24, 220);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(164, 58);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Start";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnOpenTarget
            // 
            this.btnOpenTarget.Location = new System.Drawing.Point(24, 26);
            this.btnOpenTarget.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenTarget.Name = "btnOpenTarget";
            this.btnOpenTarget.Size = new System.Drawing.Size(129, 39);
            this.btnOpenTarget.TabIndex = 1;
            this.btnOpenTarget.Text = "選択";
            this.btnOpenTarget.UseVisualStyleBackColor = true;
            this.btnOpenTarget.Click += new System.EventHandler(this.btnOpenTarget_Click);
            // 
            // labTargetPath
            // 
            this.labTargetPath.AutoSize = true;
            this.labTargetPath.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labTargetPath.Location = new System.Drawing.Point(175, 35);
            this.labTargetPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labTargetPath.Name = "labTargetPath";
            this.labTargetPath.Size = new System.Drawing.Size(313, 24);
            this.labTargetPath.TabIndex = 0;
            this.labTargetPath.Text = "対象フォルダを選択してください。";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // rdoWavToFlac
            // 
            this.rdoWavToFlac.AutoSize = true;
            this.rdoWavToFlac.Location = new System.Drawing.Point(24, 95);
            this.rdoWavToFlac.Name = "rdoWavToFlac";
            this.rdoWavToFlac.Size = new System.Drawing.Size(118, 19);
            this.rdoWavToFlac.TabIndex = 3;
            this.rdoWavToFlac.TabStop = true;
            this.rdoWavToFlac.Text = "WAV => FLAC";
            this.rdoWavToFlac.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 478);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHead);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.Text = "MediaConverter";
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnOpenTarget;
        private System.Windows.Forms.Label labTargetPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton rdoWavToFlac;
    }
}

