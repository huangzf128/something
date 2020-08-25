namespace SymfoTools
{
    partial class TableWatcherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewTable = new System.Windows.Forms.ListView();
            this.labTitle = new System.Windows.Forms.Label();
            this.butProcedure = new System.Windows.Forms.Button();
            this.colTableName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTableCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSchema = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.butReShow = new System.Windows.Forms.Button();
            this.labSchema = new System.Windows.Forms.Label();
            this.listViewCol = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrecision = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewTable
            // 
            this.listViewTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTableName,
            this.colTableCode});
            this.listViewTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.listViewTable.HideSelection = false;
            this.listViewTable.Location = new System.Drawing.Point(0, 0);
            this.listViewTable.Name = "listViewTable";
            this.listViewTable.Size = new System.Drawing.Size(301, 562);
            this.listViewTable.TabIndex = 0;
            this.listViewTable.UseCompatibleStateImageBehavior = false;
            this.listViewTable.SelectedIndexChanged += new System.EventHandler(this.listViewTable_SelectedIndexChanged);
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labTitle.ForeColor = System.Drawing.Color.Maroon;
            this.labTitle.Location = new System.Drawing.Point(336, 15);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(324, 24);
            this.labTitle.TabIndex = 1;
            this.labTitle.Text = "TABLE DEFINITION WATCHER";
            // 
            // butProcedure
            // 
            this.butProcedure.Location = new System.Drawing.Point(107, 12);
            this.butProcedure.Name = "butProcedure";
            this.butProcedure.Size = new System.Drawing.Size(76, 40);
            this.butProcedure.TabIndex = 2;
            this.butProcedure.Text = "Procedure";
            this.butProcedure.UseVisualStyleBackColor = true;
            this.butProcedure.Click += new System.EventHandler(this.butProcedure_Click);
            // 
            // colTableName
            // 
            this.colTableName.Text = "表名";
            this.colTableName.Width = 240;
            // 
            // colTableCode
            // 
            this.colTableCode.Text = "TABCODE";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.butProcedure);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(877, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 562);
            this.panel1.TabIndex = 4;
            // 
            // txtSchema
            // 
            this.txtSchema.Location = new System.Drawing.Point(57, 15);
            this.txtSchema.Name = "txtSchema";
            this.txtSchema.Size = new System.Drawing.Size(106, 19);
            this.txtSchema.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labSchema);
            this.groupBox1.Controls.Add(this.butReShow);
            this.groupBox1.Controls.Add(this.txtSchema);
            this.groupBox1.Location = new System.Drawing.Point(6, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 83);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // butReShow
            // 
            this.butReShow.Location = new System.Drawing.Point(57, 40);
            this.butReShow.Name = "butReShow";
            this.butReShow.Size = new System.Drawing.Size(99, 26);
            this.butReShow.TabIndex = 4;
            this.butReShow.Text = "再表示";
            this.butReShow.UseVisualStyleBackColor = true;
            this.butReShow.Click += new System.EventHandler(this.butReShow_Click);
            // 
            // labSchema
            // 
            this.labSchema.AutoSize = true;
            this.labSchema.Location = new System.Drawing.Point(6, 15);
            this.labSchema.Name = "labSchema";
            this.labSchema.Size = new System.Drawing.Size(45, 12);
            this.labSchema.TabIndex = 5;
            this.labSchema.Text = "Schema";
            // 
            // listViewCol
            // 
            this.listViewCol.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colType,
            this.colPrecision});
            this.listViewCol.HideSelection = false;
            this.listViewCol.Location = new System.Drawing.Point(313, 58);
            this.listViewCol.Name = "listViewCol";
            this.listViewCol.Size = new System.Drawing.Size(425, 492);
            this.listViewCol.TabIndex = 5;
            this.listViewCol.UseCompatibleStateImageBehavior = false;
            // 
            // colName
            // 
            this.colName.Text = "列名";
            this.colName.Width = 180;
            // 
            // colType
            // 
            this.colType.Text = "型";
            this.colType.Width = 100;
            // 
            // colPrecision
            // 
            this.colPrecision.Text = "精度";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(717, 12);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(154, 41);
            this.txtInfo.TabIndex = 23;
            // 
            // TableWatcherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 562);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.listViewCol);
            this.Controls.Add(this.labTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listViewTable);
            this.Name = "TableWatcherForm";
            this.Text = "TABLE DEFINITION WATCHER";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewTable;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Button butProcedure;
        private System.Windows.Forms.ColumnHeader colTableName;
        private System.Windows.Forms.ColumnHeader colTableCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSchema;
        private System.Windows.Forms.Button butReShow;
        private System.Windows.Forms.Label labSchema;
        private System.Windows.Forms.ListView listViewCol;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colPrecision;
        internal System.Windows.Forms.TextBox txtInfo;
    }
}