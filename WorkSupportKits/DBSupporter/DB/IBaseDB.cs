
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSupporter.DB
{
    interface IBaseDB
    {

        DbDataReader ExecuteQuery(string query, Dictionary<string, Object> paramDict);
        DbDataReader ExecuteQuery(string query);

        int ExecuteNonQuery(string query, Dictionary<string, Object> paramDict);

        void Close();

        void BeginTran();

        void CommitTran();

        void RollBack();
    }
}
