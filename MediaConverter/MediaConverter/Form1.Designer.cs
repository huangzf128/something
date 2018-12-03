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
            this.grpConverterType = new System.Windows.Forms.GroupBox();
            this.rdoWav2Flac = new System.Windows.Forms.RadioButton();
            this.rdoFlac2Wav = new System.Windows.Forms.RadioButton();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnOpenTarget = new System.Windows.Forms.Button();
            this.labTargetPath = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chkCreateMetaFile = new System.Windows.Forms.CheckBox();
            this.pnlHead.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.grpConverterType.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHead
            // 
            this.pnlHead.Controls.Add(this.labTitle);
            this.pnlHead.Location = new System.Drawing.Point(16, 15);
            this.pnlHead.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(737, 99);
            this.pnlHead.TabIndex = 0;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("MS UI Gothic", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labTitle.Location = new System.Drawing.Point(170, 20);
            this.labTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(367, 50);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "MediaConverter";
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.chkCreateMetaFile);
            this.pnlBody.Controls.Add(this.grpConverterType);
            this.pnlBody.Controls.Add(this.btnExecute);
            this.pnlBody.Controls.Add(this.btnOpenTarget);
            this.pnlBody.Controls.Add(this.labTargetPath);
            this.pnlBody.Location = new System.Drawing.Point(16, 138);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(737, 309);
            this.pnlBody.TabIndex = 1;
            // 
            // grpConverterType
            // 
            this.grpConverterType.Controls.Add(this.rdoWav2Flac);
            this.grpConverterType.Controls.Add(this.rdoFlac2Wav);
            this.grpConverterType.Location = new System.Drawing.Point(24, 76);
            this.grpConverterType.Name = "grpConverterType";
            this.grpConverterType.Size = new System.Drawing.Size(206, 108);
            this.grpConverterType.TabIndex = 5;
            this.grpConverterType.TabStop = false;
            // 
            // rdoWav2Flac
            // 
            this.rdoWav2Flac.AutoSize = true;
            this.rdoWav2Flac.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoWav2Flac.Location = new System.Drawing.Point(21, 24);
            this.rdoWav2Flac.Name = "rdoWav2Flac";
            this.rdoWav2Flac.Size = new System.Drawing.Size(163, 28);
            this.rdoWav2Flac.TabIndex = 3;
            this.rdoWav2Flac.TabStop = true;
            this.rdoWav2Flac.Text = "WAV => FLAC";
            this.rdoWav2Flac.UseVisualStyleBackColor = true;
            // 
            // rdoFlac2Wav
            // 
            this.rdoFlac2Wav.AutoSize = true;
            this.rdoFlac2Wav.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdoFlac2Wav.Location = new System.Drawing.Point(21, 63);
            this.rdoFlac2Wav.Name = "rdoFlac2Wav";
            this.rdoFlac2Wav.Size = new System.Drawing.Size(163, 28);
            this.rdoFlac2Wav.TabIndex = 4;
            this.rdoFlac2Wav.TabStop = true;
            this.rdoFlac2Wav.Text = "FLAC => WAV";
            this.rdoFlac2Wav.UseVisualStyleBackColor = true;
            // 
            // btnExecute
            // 
            this.btnExecute.BackColor = System.Drawing.Color.DarkRed;
            this.btnExecute.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnExecute.Location = new System.Drawing.Point(546, 231);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(4);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(164, 58);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Start";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnOpenTarget
            // 
            this.btnOpenTarget.BackColor = System.Drawing.Color.DarkRed;
            this.btnOpenTarget.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenTarget.Location = new System.Drawing.Point(24, 26);
            this.btnOpenTarget.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenTarget.Name = "btnOpenTarget";
            this.btnOpenTarget.Size = new System.Drawing.Size(129, 39);
            this.btnOpenTarget.TabIndex = 1;
            this.btnOpenTarget.Text = "選択";
            this.btnOpenTarget.UseVisualStyleBackColor = false;
            this.btnOpenTarget.Click += new System.EventHandler(this.btnOpenTarget_Click);
            // 
            // labTargetPath
            // 
            this.labTargetPath.AutoSize = true;
            this.labTargetPath.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labTargetPath.Location = new System.Drawing.Point(175, 31);
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
            // chkCreateMetaFile
            // 
            this.chkCreateMetaFile.AutoSize = true;
            this.chkCreateMetaFile.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chkCreateMetaFile.Location = new System.Drawing.Point(24, 216);
            this.chkCreateMetaFile.Name = "chkCreateMetaFile";
            this.chkCreateMetaFile.Size = new System.Drawing.Size(175, 28);
            this.chkCreateMetaFile.TabIndex = 6;
            this.chkCreateMetaFile.Text = "MetaData作成";
            this.chkCreateMetaFile.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(770, 478);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHead);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "MediaConverter";
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.grpConverterType.ResumeLayout(false);
            this.grpConverterType.PerformLayout();
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
        private System.Windows.Forms.RadioButton rdoWav2Flac;
        private System.Windows.Forms.RadioButton rdoFlac2Wav;
        private System.Windows.Forms.GroupBox grpConverterType;
        private System.Windows.Forms.CheckBox chkCreateMetaFile;
    }
}

