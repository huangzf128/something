namespace Clickonce
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSource = new System.Windows.Forms.Button();
            this.btnLastTarget = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtLastTarget = new System.Windows.Forms.TextBox();
            this.chkDll = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRemoveDeploy = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTarget = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblBuildExplain = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCreateDeployFolder = new System.Windows.Forms.Button();
            this.lblCreateFolderExplain = new System.Windows.Forms.Label();
            this.lblSelTargetExplain = new System.Windows.Forms.Label();
            this.chkXls = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSource
            // 
            this.btnSource.Location = new System.Drawing.Point(28, 21);
            this.btnSource.Margin = new System.Windows.Forms.Padding(2);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(56, 30);
            this.btnSource.TabIndex = 1;
            this.btnSource.Text = "Source";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // btnLastTarget
            // 
            this.btnLastTarget.Location = new System.Drawing.Point(20, 26);
            this.btnLastTarget.Margin = new System.Windows.Forms.Padding(2);
            this.btnLastTarget.Name = "btnLastTarget";
            this.btnLastTarget.Size = new System.Drawing.Size(56, 30);
            this.btnLastTarget.TabIndex = 3;
            this.btnLastTarget.Text = "Target";
            this.btnLastTarget.UseVisualStyleBackColor = true;
            this.btnLastTarget.Click += new System.EventHandler(this.btnTarget_Click);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(106, 28);
            this.txtSource.Margin = new System.Windows.Forms.Padding(2);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(347, 19);
            this.txtSource.TabIndex = 4;
            // 
            // txtLastTarget
            // 
            this.txtLastTarget.Location = new System.Drawing.Point(98, 34);
            this.txtLastTarget.Margin = new System.Windows.Forms.Padding(2);
            this.txtLastTarget.Name = "txtLastTarget";
            this.txtLastTarget.Size = new System.Drawing.Size(347, 19);
            this.txtLastTarget.TabIndex = 5;
            // 
            // chkDll
            // 
            this.chkDll.AutoSize = true;
            this.chkDll.Location = new System.Drawing.Point(4, 25);
            this.chkDll.Margin = new System.Windows.Forms.Padding(2);
            this.chkDll.Name = "chkDll";
            this.chkDll.Size = new System.Drawing.Size(36, 16);
            this.chkDll.TabIndex = 6;
            this.chkDll.Text = "dll";
            this.chkDll.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkXls);
            this.groupBox1.Controls.Add(this.chkDll);
            this.groupBox1.Location = new System.Drawing.Point(28, 105);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(132, 79);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "対象ファイル拡張子";
            // 
            // chkRemoveDeploy
            // 
            this.chkRemoveDeploy.AutoSize = true;
            this.chkRemoveDeploy.Location = new System.Drawing.Point(28, 198);
            this.chkRemoveDeploy.Margin = new System.Windows.Forms.Padding(2);
            this.chkRemoveDeploy.Name = "chkRemoveDeploy";
            this.chkRemoveDeploy.Size = new System.Drawing.Size(96, 16);
            this.chkRemoveDeploy.TabIndex = 9;
            this.chkRemoveDeploy.Text = "removeDeploy";
            this.chkRemoveDeploy.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(383, 113);
            this.btnGo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(69, 47);
            this.btnGo.TabIndex = 10;
            this.btnGo.Text = "Go!!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.btnTarget);
            this.groupBox2.Controls.Add(this.txtTarget);
            this.groupBox2.Controls.Add(this.btnGo);
            this.groupBox2.Controls.Add(this.btnSource);
            this.groupBox2.Controls.Add(this.chkRemoveDeploy);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.txtSource);
            this.groupBox2.Location = new System.Drawing.Point(16, 227);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(502, 227);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DLLをコピーする";
            // 
            // btnTarget
            // 
            this.btnTarget.Location = new System.Drawing.Point(28, 57);
            this.btnTarget.Name = "btnTarget";
            this.btnTarget.Size = new System.Drawing.Size(56, 29);
            this.btnTarget.TabIndex = 13;
            this.btnTarget.Text = "Target";
            this.btnTarget.UseVisualStyleBackColor = true;
            this.btnTarget.Click += new System.EventHandler(this.Button2_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(16, 18);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(36, 16);
            this.chkAll.TabIndex = 12;
            this.chkAll.Text = "all";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(106, 60);
            this.txtTarget.Margin = new System.Windows.Forms.Padding(2);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(347, 19);
            this.txtTarget.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblBuildExplain);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(16, 10);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(502, 61);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Build";
            // 
            // lblBuildExplain
            // 
            this.lblBuildExplain.AutoSize = true;
            this.lblBuildExplain.Location = new System.Drawing.Point(26, 17);
            this.lblBuildExplain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuildExplain.Name = "lblBuildExplain";
            this.lblBuildExplain.Size = new System.Drawing.Size(115, 12);
            this.lblBuildExplain.TabIndex = 1;
            this.lblBuildExplain.Text = "buildの手順を説明する";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(383, 17);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Go!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCreateDeployFolder);
            this.groupBox4.Controls.Add(this.lblCreateFolderExplain);
            this.groupBox4.Controls.Add(this.lblSelTargetExplain);
            this.groupBox4.Controls.Add(this.txtLastTarget);
            this.groupBox4.Controls.Add(this.btnLastTarget);
            this.groupBox4.Location = new System.Drawing.Point(16, 77);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(502, 125);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Clickonceの保存先を選択";
            // 
            // btnCreateDeployFolder
            // 
            this.btnCreateDeployFolder.Location = new System.Drawing.Point(383, 100);
            this.btnCreateDeployFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateDeployFolder.Name = "btnCreateDeployFolder";
            this.btnCreateDeployFolder.Size = new System.Drawing.Size(69, 18);
            this.btnCreateDeployFolder.TabIndex = 8;
            this.btnCreateDeployFolder.Text = "作成!";
            this.btnCreateDeployFolder.UseVisualStyleBackColor = true;
            this.btnCreateDeployFolder.Click += new System.EventHandler(this.btnCreateDeployFolder_Click);
            // 
            // lblCreateFolderExplain
            // 
            this.lblCreateFolderExplain.AutoSize = true;
            this.lblCreateFolderExplain.Location = new System.Drawing.Point(17, 100);
            this.lblCreateFolderExplain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreateFolderExplain.Name = "lblCreateFolderExplain";
            this.lblCreateFolderExplain.Size = new System.Drawing.Size(81, 12);
            this.lblCreateFolderExplain.TabIndex = 7;
            this.lblCreateFolderExplain.Text = "手順を説明する";
            // 
            // lblSelTargetExplain
            // 
            this.lblSelTargetExplain.AutoSize = true;
            this.lblSelTargetExplain.Location = new System.Drawing.Point(17, 59);
            this.lblSelTargetExplain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelTargetExplain.Name = "lblSelTargetExplain";
            this.lblSelTargetExplain.Size = new System.Drawing.Size(81, 12);
            this.lblSelTargetExplain.TabIndex = 6;
            this.lblSelTargetExplain.Text = "手順を説明する";
            // 
            // chkXls
            // 
            this.chkXls.AutoSize = true;
            this.chkXls.Location = new System.Drawing.Point(4, 47);
            this.chkXls.Name = "chkXls";
            this.chkXls.Size = new System.Drawing.Size(66, 16);
            this.chkXls.TabIndex = 7;
            this.chkXls.Text = "xls/xlsx";
            this.chkXls.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkAll);
            this.groupBox5.Location = new System.Drawing.Point(174, 113);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(161, 62);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "file filter";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 483);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.Button btnLastTarget;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtLastTarget;
        private System.Windows.Forms.CheckBox chkDll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkRemoveDeploy;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblBuildExplain;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblSelTargetExplain;
        private System.Windows.Forms.Label lblCreateFolderExplain;
        private System.Windows.Forms.Button btnCreateDeployFolder;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnTarget;
        private System.Windows.Forms.CheckBox chkXls;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

