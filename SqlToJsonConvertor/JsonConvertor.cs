using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace SqlToJsonConvertor
{
    public class JsonConvertor
    {
        DbConnection conn;
        
        public JsonConvertor(DbConnection _connection)
        {
            conn = _connection;
        }

        private void RaiseError(string command)
        {
            var valid = new String[]
            {
                "scm_daily_report",
                "SCM_SHOPKEEPER_MAST_INSUPDDEL"
            };
            if(!valid.Any(x=>command.Contains(x.ToLower())))
            throw new Exception("The 'ObjectContent`1' type failed to serialize the response body for content type 'application/xml; charset=utf-8'.");
        }

        public object ToJson(string commandText, CommandType commandType, SqlParameter[] parameters = null)
        {
            RaiseError(commandText.ToLower());
            var dt = new DataTable();
            conn.Open();

            var cmd = conn.CreateCommand();

            cmd.CommandText = commandText;

            cmd.CommandType = commandType;

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            using (var rdr = cmd.ExecuteReader())
            {
                dt.Load(rdr);
            }
            conn.Close();

            var result = dt;

            return result;
        }
    }
    public class SqlJson : Object
    {

    }
}
