namespace DBSupporter
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
            this.lvwColumn = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTableList = new System.Windows.Forms.Label();
            this.lstTable = new System.Windows.Forms.ListBox();
            this.btnGenerateEntity = new System.Windows.Forms.Button();
            this.lblColumnList = new System.Windows.Forms.Label();
            this.chkNumColumnAnno = new System.Windows.Forms.CheckBox();
            this.chkIgnoreCommon = new System.Windows.Forms.CheckBox();
            this.btnCreateMapper = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwColumn
            // 
            this.lvwColumn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwColumn.FullRowSelect = true;
            this.lvwColumn.GridLines = true;
            this.lvwColumn.HideSelection = false;
            this.lvwColumn.Location = new System.Drawing.Point(219, 46);
            this.lvwColumn.Name = "lvwColumn";
            this.lvwColumn.Size = new System.Drawing.Size(257, 292);
            this.lvwColumn.TabIndex = 0;
            this.lvwColumn.UseCompatibleStateImageBehavior = false;
            this.lvwColumn.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ColumnName";
            this.columnHeader1.Width = 112;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ColumnType";
            this.columnHeader2.Width = 141;
            // 
            // lblTableList
            // 
            this.lblTableList.AutoSize = true;
            this.lblTableList.Location = new System.Drawing.Point(18, 27);
            this.lblTableList.Name = "lblTableList";
            this.lblTableList.Size = new System.Drawing.Size(56, 12);
            this.lblTableList.TabIndex = 1;
            this.lblTableList.Text = "Table List";
            // 
            // lstTable
            // 
            this.lstTable.FormattingEnabled = true;
            this.lstTable.ItemHeight = 12;
            this.lstTable.Location = new System.Drawing.Point(20, 46);
            this.lstTable.Name = "lstTable";
            this.lstTable.Size = new System.Drawing.Size(171, 292);
            this.lstTable.TabIndex = 2;
            this.lstTable.DoubleClick += new System.EventHandler(this.lstTable_DoubleClick);
            // 
            // btnGenerateEntity
            // 
            this.btnGenerateEntity.Location = new System.Drawing.Point(557, 364);
            this.btnGenerateEntity.Name = "btnGenerateEntity";
            this.btnGenerateEntity.Size = new System.Drawing.Size(99, 23);
            this.btnGenerateEntity.TabIndex = 3;
            this.btnGenerateEntity.Text = "generate entity";
            this.btnGenerateEntity.UseVisualStyleBackColor = true;
            this.btnGenerateEntity.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // lblColumnList
            // 
            this.lblColumnList.AutoSize = true;
            this.lblColumnList.Location = new System.Drawing.Point(217, 27);
            this.lblColumnList.Name = "lblColumnList";
            this.lblColumnList.Size = new System.Drawing.Size(66, 12);
            this.lblColumnList.TabIndex = 4;
            this.lblColumnList.Text = "Column List";
            // 
            // chkNumColumnAnno
            // 
            this.chkNumColumnAnno.AutoSize = true;
            this.chkNumColumnAnno.Location = new System.Drawing.Point(557, 331);
            this.chkNumColumnAnno.Name = "chkNumColumnAnno";
            this.chkNumColumnAnno.Size = new System.Drawing.Size(212, 16);
            this.chkNumColumnAnno.TabIndex = 5;
            this.chkNumColumnAnno.Text = "列名に数字を含む列にアノテーション付く";
            this.chkNumColumnAnno.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreCommon
            // 
            this.chkIgnoreCommon.AutoSize = true;
            this.chkIgnoreCommon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chkIgnoreCommon.Checked = true;
            this.chkIgnoreCommon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnoreCommon.Location = new System.Drawing.Point(557, 297);
            this.chkIgnoreCommon.Name = "chkIgnoreCommon";
            this.chkIgnoreCommon.Size = new System.Drawing.Size(141, 16);
            this.chkIgnoreCommon.TabIndex = 6;
            this.chkIgnoreCommon.Text = "ignore common column";
            this.chkIgnoreCommon.UseVisualStyleBackColor = true;
            // 
            // btnCreateMapper
            // 
            this.btnCreateMapper.Location = new System.Drawing.Point(557, 403);
            this.btnCreateMapper.Name = "btnCreateMapper";
            this.btnCreateMapper.Size = new System.Drawing.Size(99, 23);
            this.btnCreateMapper.TabIndex = 7;
            this.btnCreateMapper.Text = "generate mapper";
            this.btnCreateMapper.UseVisualStyleBackColor = true;
            this.btnCreateMapper.Click += new System.EventHandler(this.btnCreateMapper_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCreateMapper);
            this.Controls.Add(this.chkIgnoreCommon);
            this.Controls.Add(this.chkNumColumnAnno);
            this.Controls.Add(this.lblColumnList);
            this.Controls.Add(this.btnGenerateEntity);
            this.Controls.Add(this.lstTable);
            this.Controls.Add(this.lblTableList);
            this.Controls.Add(this.lvwColumn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwColumn;
        private System.Windows.Forms.Label lblTableList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListBox lstTable;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnGenerateEntity;
        private System.Windows.Forms.Label lblColumnList;
        private System.Windows.Forms.CheckBox chkNumColumnAnno;
        private System.Windows.Forms.CheckBox chkIgnoreCommon;
        private System.Windows.Forms.Button btnCreateMapper;
    }
}

