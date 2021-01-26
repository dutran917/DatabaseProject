using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class SqlData
    {
        public static DataTable ExeNpSqlToTable(string cmd, string conn)
        {
            DataTable result = new DataTable();

            using (NpgsqlConnection connection = new NpgsqlConnection(conn))
            {
                connection.Open();
                using (NpgsqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = cmd;
                    sqlCommand.CommandType = CommandType.Text;
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlCommand);
                    da.Fill(result);
                }
            }
            return result;
        }

        public static void ExeNpSqlCmd(string cmd, string conn)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(conn))
            {
                connection.Open();
                using (NpgsqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = cmd;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
