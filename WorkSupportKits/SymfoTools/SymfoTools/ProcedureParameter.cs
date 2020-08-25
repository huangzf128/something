using Fujitsu.Symfoware.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymfoTools
{

    public class COLUMN_TYPE
    {
        public static readonly int P_IN = 1;
        public static readonly int P_OUT = 4;
    }
    public class DATA_TYPE
    {
        public static readonly int P_CHAR = 1;
    }

    class ProcedureParameter
    {
        public string colName { get; set; }
        public int max { get; set; }
        public int colType { get; set; }

        public int dataType { get; set; }


        public ParameterDirection getDirect()
        {
            if (colType == COLUMN_TYPE.P_IN)
            {
                return ParameterDirection.Input;
            }
            else if (colType == COLUMN_TYPE.P_OUT)
            {
                return ParameterDirection.Output;
            }

            return ParameterDirection.InputOutput;
        }

        public SymfowareDbType getDataType()
        {
            if (dataType == DATA_TYPE.P_CHAR)
            {
                return SymfowareDbType.Char;
            }

            return SymfowareDbType.VarChar;
        }

    }
}
