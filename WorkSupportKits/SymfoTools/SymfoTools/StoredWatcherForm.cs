using Fujitsu.Symfoware.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SymfoTools
{
    public partial class StoredWatcherForm : Form
    {
        public StoredWatcherForm()
        {
            InitializeComponent();
            ShowProcedureList();
        }

        private void ShowProcedureList()
        {
            ListBox1.DisplayMember = "Value";
            ListBox1.ValueMember = "Key";

            using (SymfowareConnection conn = DbUtil.GetConnection())
            {
                SymfowareDataReader myReader = GetProcedureNameList(conn);

                while (myReader.Read())
                {
                    string key = DbUtil.GetValue(myReader, "PROCEDURE_NAME");
                    string value = DbUtil.GetValue(myReader, "PROCEDURE_CODE");
                    ListBox1.Items.Add(new DictionaryEntry(value, key));
                }

                myReader.Close();
            }
        }

        private void ShowStoredInfo(string storedCode)
        {
            txtInfo.Text = "StoredCode : " + storedCode;
        }

        #region ---------------------- SQL ----------------------

        private SymfowareDataReader GetProcedureNameList(SymfowareConnection conn)
        {
            string str = @"SELECT 
                            PROCEDURE_NAME, PROCEDURE_CODE 
                        FROM 
                            RDBII_SYSTEM.RDBII_PROC 
                        WHERE SCHEMA_NAME = 'CRMSC'
                        ORDER BY PROCEDURE_NAME";

            SymfowareCommand command = new SymfowareCommand(str, conn);
            SymfowareDataReader myReader = command.ExecuteReader();

            return myReader;
        }

        /// <summary>
        /// プロシージャ定義取得
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="storedCode"></param>
        /// <returns></returns>
        private SymfowareDataReader GetProcedureDefinition(SymfowareConnection conn, string storedCode)
        {
            string str = @"SELECT  DESC_VALUE 
                            FROM 
                             RDBII_SYSTEM.RDBII_DESCRIPTION 
                            WHERE OBJECT_CODE = :OBJECT_CODE ";

            SymfowareCommand command = new SymfowareCommand(str, conn);
            command.Parameters.Add("OBJECT_CODE", storedCode);
            return command.ExecuteReader();
        }

        private SymfowareDataReader GetProcedureParameterInfo(SymfowareConnection conn, string storedCode)
        {
            string str = @"SELECT 
                          COLUMN_NAME, COLUMN_CODE, COLUMN_TYPE, DATA_TYPE, CHAR_MAX_LENGTH 
                         FROM 
                             RDBII_SYSTEM.RDBII_PROC_COL 
                         WHERE PROCEDURE_CODE = :PROCEDURE_CODE
                         ORDER BY COLUMN_CODE ";

            SymfowareCommand command = new SymfowareCommand(str, conn);
            command.Parameters.Add("PROCEDURE_CODE", storedCode);
            return command.ExecuteReader();
        }

        private SymfowareDataReader GetProcedureCaller(SymfowareConnection conn, string storedName)
        {
            string str = @"SELECT 
                            T1.PROCEDURE_NAME
                         FROM 
                             RDBII_SYSTEM.RDBII_DESCRIPTION T
                         LEFT JOIN RDBII_SYSTEM.RDBII_PROC T1
                         ON  T.DB_CODE      = T1.DB_CODE
                         AND T.SCHEMA_CODE  = T1.SCHEMA_CODE
                         AND T.OBJECT_CODE  = T1.PROCEDURE_CODE

                         WHERE UPPER(T.DESC_VALUE) LIKE :PROCEDURE_NAME
                         ";

            SymfowareCommand command = new SymfowareCommand(str, conn);
            command.Parameters.Add("PROCEDURE_NAME", "%" +  storedName.ToUpper() + "%");
            return command.ExecuteReader();
        }

        #endregion


        #region --------------- EVENT ---------------

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DictionaryEntry Item = (DictionaryEntry) ListBox1.SelectedItem;
            SymfowareDataReader myReader = null;

            try
            {
                using (SymfowareConnection conn = DbUtil.GetConnection())
                {
                    myReader = GetProcedureDefinition(conn, Item.Key.ToString());
                    myReader.Read();

                    string strText = DbUtil.GetValue(myReader, "DESC_VALUE");

                    richTxtStoredDef.Text = strText.Replace("\r", "\r\n");
                    richTxtStoredDef.SelectionStart = 0;
                    richTxtStoredDef.ScrollToCaret();

                    myReader.Close();

                    ShowStoredInfo(Item.Key.ToString());
                }

            }
            catch (Exception)
            {
                if (myReader != null) {
                    myReader.Close();
                }
            }
        }

        private void btnExeProc_Click(object sender, EventArgs e)
        {
            List<ProcedureParameter> paramInfos = new List<ProcedureParameter>();
            DictionaryEntry Item = (DictionaryEntry)ListBox1.SelectedItem;

            using (SymfowareConnection conn = DbUtil.GetConnection())
            {
                SymfowareDataReader sfReader = GetProcedureParameterInfo(conn, Item.Key.ToString());
                while (sfReader.Read())
                {
                    ProcedureParameter paramInfo = new ProcedureParameter();
                    paramInfo.colType = int.Parse(DbUtil.GetValue(sfReader, "COLUMN_TYPE"));
                    paramInfo.dataType = int.Parse(DbUtil.GetValue(sfReader, "DATA_TYPE"));
                    paramInfo.max = int.Parse(DbUtil.GetValue(sfReader, "CHAR_MAX_LENGTH"));
                    paramInfo.colName = DbUtil.GetValue(sfReader, "COLUMN_NAME");
                    paramInfos.Add(paramInfo);
                }
                sfReader.Close();
            }

            string strCommand = "CALL CRMSC." + Item.Value + "(";
            foreach (ProcedureParameter paramInfo in paramInfos)
            {
                strCommand += "?,";
            }
            strCommand = strCommand.TrimEnd(new Char[] {','}) + ")";

            using (SymfowareConnection conn = DbUtil.GetConnection())
            {
                SymfowareCommand command = new SymfowareCommand(strCommand, conn);
                command = DbUtil.CallProcedure(command, paramInfos);

                string text1 = "result:  " + command.Parameters["oERRMSG"].Value;
                command.Dispose();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.ListBox1.Items.Clear();
            this.richTxtStoredDef.Text = String.Empty;
            ShowProcedureList();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DictionaryEntry Item = (DictionaryEntry)ListBox1.SelectedItem;
            string procedureName = Item.Value.ToString();
            string message = procedureName + " を削除します。本当？";

            DialogResult result = MessageBox.Show(this, message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string str = "drop procedure CRMSC." + procedureName;

                using (SymfowareConnection conn = DbUtil.GetConnection())
                {
                    try
                    {
                        SymfowareCommand command = new SymfowareCommand(str, conn);
                        command.ExecuteReader();
                        MessageBox.Show("できた。");
                        btnReload.PerformClick();
                    }
                    catch (Fujitsu.Symfoware.Client.SymfowareException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 呼出元を検索する
        /// </summary>
        private void btnSrchCaller_Click(object sender, EventArgs e)
        {
            DictionaryEntry Item = (DictionaryEntry)ListBox1.SelectedItem;
            SymfowareDataReader sfReader = null;

            try
            {
                using (SymfowareConnection conn = DbUtil.GetConnection())
                {
                    sfReader = GetProcedureCaller(conn, Item.Value.ToString());
                    List<string> calls = new List<string>();
                    while (sfReader.Read())
                    {
                        calls.Add(DbUtil.GetValue(sfReader, "PROCEDURE_NAME"));
                    }
                    sfReader.Close();

                    MessageBox.Show(string.Join("; ", calls));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (sfReader != null)
                {
                    sfReader.Close();
                }
            }

        }

        private void butTable_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (false == FormManager.IsFormAlreadyOpen(typeof(TableWatcherForm).ToString()))
            {
                FormManager.GetForm(typeof(TableWatcherForm).ToString()).ShowDialog();
            }
            else
            {
                FormManager.GetForm(typeof(TableWatcherForm).ToString()).Show();
            }
        }

        #endregion


        private void CreateProcedure()
        {

            string str = richTxtStoredDef.Text;
            using (SymfowareConnection conn = DbUtil.GetConnection())
            {
                try
                {
                    SymfowareCommand command = new SymfowareCommand(str, conn);
                    command.ExecuteNonQuery();
                    string text1 = "result:  " + command.ToString();
                    MessageBox.Show("できた。");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }


    }
}
