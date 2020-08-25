using Fujitsu.Symfoware.Client;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SymfoTools
{
    class DbUtil
    {
        static SymfowareConnection conn;

        public static SymfowareConnection GetConnection()
        {
            try
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }

                var appConfig = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
                string connStr = appConfig.AppSettings.Settings["Connection"].Value;

                conn = new SymfowareConnection(connStr);
                conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to connect to data source. Check App.Config.");
            }
            return null;
        }

        public static SymfowareCommand CallProcedure(SymfowareCommand command, List<ProcedureParameter> paramInfos)
        {

            foreach(ProcedureParameter paramInfo in paramInfos)
            {
                SymfowareParameter param = new SymfowareParameter();
                param.ParameterName = paramInfo.colName;
                param.SymfowareDbType = paramInfo.getDataType();
                param.Direction = paramInfo.getDirect();

                if (param.Direction == ParameterDirection.Input) {
                    param.Value = DbUtil.GetUserInput(paramInfo.colName);
                } else if (param.Direction == ParameterDirection.Output)
                {
                    param.Size = paramInfo.max;
                }
                command.Parameters.Add(param);
            }
            command.ExecuteNonQuery();

            return command;
        }

        public static string GetValue(SymfowareDataReader sfReader, string strName)
        {
            string ret;
            int fld = sfReader.GetOrdinal(strName);

            if (sfReader.IsDBNull(fld))
            {
                ret = "";
            }
            else
            {
                ret = sfReader.GetValue(fld).ToString().Trim();
            }
            return ret;
        }


        private static object GetUserInput(string prompt)
        {
            return Interaction.InputBox(prompt, "パラメータを入力してください。", "");
        }


        public static string ReplaceColumnName(string columnName)
        {
            Dictionary<String, String> colMapping = new Dictionary<String, String>();
            colMapping.Add("CH", "CHAR");
            colMapping.Add("CV", "VARCHAR");
            colMapping.Add("CN", "NCHAR");
            colMapping.Add("NV", "NCHAR VARYING");

            colMapping.Add("IN", "INT");
            colMapping.Add("NU", "NUMERIC");
            colMapping.Add("DE", "DECIMAL");
            colMapping.Add("FL", "FLOAT");

            colMapping.Add("TI", "TIME");
            colMapping.Add("TM", "TIMESTAMP");
            colMapping.Add("DT", "DATE");

            if (colMapping.ContainsKey(columnName))
            {
                return colMapping[columnName];
            }
            return columnName;
        }
    }
}
