using Common;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSupporter.DB
{
    class PostgreSql : IBaseDB
    {
        public static string TYPE_STRING = "character varying";
        public static string TYPE_DATE = "timestamp without time zone";
        public static string TYPE_NUMBER = "numeric";

        private NpgsqlConnection sqlConnection;
        private NpgsqlTransaction sqlTransaction;

        public PostgreSql()
        {
            // 接続文字列を生成
            string connectString =
            "Server = " + AppConfigUtil.ReadAppconfig("serverIp")
            + ";Port = " + AppConfigUtil.ReadAppconfig("port")
            + ";Database = " + AppConfigUtil.ReadAppconfig("dbName")
            + ";User ID = " + AppConfigUtil.ReadAppconfig("userId")
            + ";Password = " + AppConfigUtil.ReadAppconfig("password")
            + ";Enlist = true";

            this.sqlConnection = new NpgsqlConnection(connectString);

            this.sqlConnection.Open();
        }



        public void BeginTran()
        {
            this.sqlTransaction = this.sqlConnection.BeginTransaction();
        }

        public void Close()
        {
            this.sqlConnection.Close();
            this.sqlConnection.Dispose();
        }

        public void CommitTran()
        {
            if (this.sqlTransaction.Connection != null)
            {
                this.sqlTransaction.Commit();
                this.sqlTransaction.Dispose();
            }
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object> paramDict)
        {
            NpgsqlCommand sqlCom = new NpgsqlCommand();

            //クエリー送信先、トランザクションの指定
            sqlCom.Connection = this.sqlConnection;
            sqlCom.Transaction = this.sqlTransaction;

            sqlCom.CommandText = query;
            foreach (KeyValuePair<string, Object> item in paramDict)
            {
                sqlCom.Parameters.Add(new SqlParameter(item.Key, item.Value));
            }

            // SQLを実行
            return sqlCom.ExecuteNonQuery();
        }

        public DbDataReader ExecuteQuery(string query, Dictionary<string, object> paramDict)
        {
            NpgsqlCommand sqlCom = new NpgsqlCommand();

            //クエリー送信先、トランザクションの指定
            sqlCom.Connection = this.sqlConnection;
            sqlCom.Transaction = this.sqlTransaction;

            sqlCom.CommandText = query;
            foreach (KeyValuePair<string, Object> item in paramDict)
            {
                sqlCom.Parameters.Add(new SqlParameter(item.Key, item.Value));
            }

            // SQLを実行
            NpgsqlDataReader reader = sqlCom.ExecuteReader();

            return reader;
        }

        public DbDataReader ExecuteQuery(string query)
        {
            return this.ExecuteQuery(query, new Dictionary<string, Object>());
        }

        public void RollBack()
        {
            if (this.sqlTransaction.Connection != null)
            {
                this.sqlTransaction.Rollback();
                this.sqlTransaction.Dispose();
            }
        }
    }
}
