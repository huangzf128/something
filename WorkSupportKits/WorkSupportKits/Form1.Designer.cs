namespace WorkSupportKits
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
            this.btnFetchSVN = new System.Windows.Forms.Button();
            this.butProcedure = new System.Windows.Forms.Button();
            this.butSymfoTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFetchSVN
            // 
            this.btnFetchSVN.Location = new System.Drawing.Point(28, 45);
            this.btnFetchSVN.Name = "btnFetchSVN";
            this.btnFetchSVN.Size = new System.Drawing.Size(102, 42);
            this.btnFetchSVN.TabIndex = 0;
            this.btnFetchSVN.Text = "FetchSVN";
            this.btnFetchSVN.UseVisualStyleBackColor = true;
            this.btnFetchSVN.Click += new System.EventHandler(this.btnFetchSVN_Click);
            // 
            // butProcedure
            // 
            this.butProcedure.Location = new System.Drawing.Point(158, 45);
            this.butProcedure.Name = "butProcedure";
            this.butProcedure.Size = new System.Drawing.Size(107, 42);
            this.butProcedure.TabIndex = 1;
            this.butProcedure.Text = "SymfoProcedure";
            this.butProcedure.UseVisualStyleBackColor = true;
            this.butProcedure.Click += new System.EventHandler(this.butProcedure_Click);
            // 
            // butSymfoTable
            // 
            this.butSymfoTable.Location = new System.Drawing.Point(296, 45);
            this.butSymfoTable.Name = "butSymfoTable";
            this.butSymfoTable.Size = new System.Drawing.Size(85, 42);
            this.butSymfoTable.TabIndex = 2;
            this.butSymfoTable.Text = "SymfoTable";
            this.butSymfoTable.UseVisualStyleBackColor = true;
            this.butSymfoTable.Click += new System.EventHandler(this.butSymfoTable_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 229);
            this.Controls.Add(this.butSymfoTable);
            this.Controls.Add(this.butProcedure);
            this.Controls.Add(this.btnFetchSVN);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFetchSVN;
        private System.Windows.Forms.Button butProcedure;
        private System.Windows.Forms.Button butSymfoTable;
    }
}

