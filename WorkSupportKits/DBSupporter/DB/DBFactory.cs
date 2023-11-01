using DBSupporter.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DBSupporter.Common.Consts;

namespace DBSupporter.DB
{
    class DBFactory
    {
        public static IBaseDB GetDBInstance(DBTYPE dbType)
        {
            IBaseDB db = null;
            if (dbType == DBTYPE.postgresql)
            {
                db = new PostgreSql();
            }
            return db;
        }

        public static String GetTableListSql(DBTYPE dbType)
        {
            String sql = "";
            if (dbType == DBTYPE.postgresql)
            {
                 sql = @"SELECT table_name 
                        FROM information_schema.tables
                        WHERE table_schema = 'public'
                        AND table_type = 'BASE TABLE'";
            }

            return sql;
        }

        public static String GetColumnListSql(DBTYPE dbType, String tableName)
        {
            String sql = "";
            if (dbType == DBTYPE.postgresql)
            {
                 sql = @"SELECT c.column_name, c.data_type, c.ordinal_position, (case when ccu.column_name is null then '0' else '1' end) AS is_pk
                        FROM information_schema.columns c
                        LEFT JOIN information_schema.constraint_column_usage AS ccu
                            on ccu.column_name = c.column_name
                            and ccu.table_name = c.table_name
                            and ccu.table_schema = c.table_schema
                        WHERE c.table_schema = 'public'
                        AND c.table_name = '" + tableName + "'; ";
            }

            return sql;
        }

    }
}
