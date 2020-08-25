using Fujitsu.Symfoware.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SymfoTools
{
    public partial class TableWatcherForm : Form
    {
        public TableWatcherForm()
        {
            InitializeComponent();
            listViewTable.View = View.Details;
            listViewCol.View = View.Details;
            
            ShowTableList();
        }

        private void ShowTableList()
        {
            using (SymfowareConnection conn = DbUtil.GetConnection())
            {
                SymfowareDataReader sfReader = GetTableNameList(conn);

                while (sfReader.Read())
                {
                    string tabName = DbUtil.GetValue(sfReader, "TABLE_NAME");
                    string tabCode = DbUtil.GetValue(sfReader, "TABLE_CODE");
                    string dbCode = DbUtil.GetValue(sfReader, "DB_CODE");
                    string schemaCode = DbUtil.GetValue(sfReader, "SCHEMA_CODE");
                    string tableOwner = DbUtil.GetValue(sfReader, "TABLE_OWNER");

                    string[] item = { tabName, tabCode, dbCode, schemaCode, tableOwner };
                    listViewTable.Items.Add(new ListViewItem(item));
                }

                sfReader.Close();
            }
            foreach (ListViewItem item in listViewTable.Items)
            {
                item.BackColor = item.Index % 2 == 0 ? Color.AntiqueWhite : Color.White;
            }
        }


        #region ----------------------- SQL ----------------------
        private SymfowareDataReader GetTableNameList(SymfowareConnection conn)
        {
            string str = @"SELECT
                                T1.DB_NAME, T1.SCHEMA_NAME, T1.TABLE_NAME, T1.DB_CODE, T1.SCHEMA_CODE, T1.TABLE_CODE, T2.TABLE_OWNER
                            FROM RDBII_SYSTEM.RDBII_TABLE T1
                            LEFT JOIN RDBII_SYSTEM.TABLES T2
                                ON T1.DB_CODE = T2.DB_CODE
                               AND T1.SCHEMA_CODE = T2.SCHEMA_CODE
                               AND T1.TABLE_CODE = T2.TABLE_CODE
                            WHERE T1.DB_NAME = :DB_NAME ";

            SymfowareCommand command = new SymfowareCommand(str, conn);

            var appConfig = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            string dbName = appConfig.AppSettings.Settings["DBName"].Value;

            command.Parameters.Add("DB_NAME", dbName);
            SymfowareDataReader sfReader = command.ExecuteReader();
            return sfReader;
        }

        private SymfowareDataReader GetColumnList(SymfowareConnection conn, string dbCode, string schemaCode, string tableCode)
        {
            string str = @"SELECT * FROM
                            RDBII_SYSTEM.RDBII_COLUMN
                            WHERE 
                                DB_CODE = :DB_CODE
                            AND SCHEMA_CODE = :SCHEMA_CODE
                            AND TABLE_CODE = :TABLE_CODE ";

            SymfowareCommand command = new SymfowareCommand(str, conn);

            command.Parameters.Add("DB_CODE", dbCode);
            command.Parameters.Add("SCHEMA_CODE", schemaCode);
            command.Parameters.Add("TABLE_CODE", tableCode);
            SymfowareDataReader sfReader = command.ExecuteReader();
            return sfReader;

        }
        #endregion

        #region --------------- EVENT ---------------

        private void butProcedure_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (false == FormManager.IsFormAlreadyOpen(typeof(StoredWatcherForm).ToString()))
            {
                FormManager.GetForm(typeof(StoredWatcherForm).ToString()).ShowDialog();
            } else
            {
                FormManager.GetForm(typeof(StoredWatcherForm).ToString()).Show();
            }
        }

        private void butReShow_Click(object sender, EventArgs e)
        {
            listViewTable.Items.Clear();
            ShowTableList();
        }

        private void listViewTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewTable.SelectedItems.Count == 0) return;
            string tableCode = listViewTable.SelectedItems[0].SubItems[1].Text;
            string dbCode = listViewTable.SelectedItems[0].SubItems[2].Text;
            string schemaCode = listViewTable.SelectedItems[0].SubItems[3].Text;

            string tableOwner = listViewTable.SelectedItems[0].SubItems[4].Text;
            txtInfo.Text = "Owner: {Owner}".Replace("{Owner}", tableOwner);

            listViewCol.Items.Clear();
            using (SymfowareConnection conn = DbUtil.GetConnection())
            {
                SymfowareDataReader sfReader = GetColumnList(conn, dbCode, schemaCode, tableCode);

                while (sfReader.Read())
                {
                    string colName = DbUtil.GetValue(sfReader, "COLUMN_NAME");
                    string dataType = DbUtil.GetValue(sfReader, "DATA_TYPE");
                    string length = DbUtil.GetValue(sfReader, "NUMERIC_PRECISION");
                    if (String.IsNullOrEmpty(length))
                    {
                        length = DbUtil.GetValue(sfReader, "CHAR_MAX_LENGTH");
                    }

                    string[] item = { colName, DbUtil.ReplaceColumnName(dataType), length };
                    listViewCol.Items.Add(new ListViewItem(item));
                }

                sfReader.Close();
            }
            foreach (ListViewItem item in listViewCol.Items)
            {
                item.BackColor = item.Index % 2 == 0 ? Color.PaleGreen : Color.White;
            }

        }
        #endregion


    }
}
