using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FPProjectStudentSuccessBSA.Data
{
    public class DBCRUD
    {
        public static SQLConnectionConfig _conn;
        public SqlConnection connection;
        public DBCRUD(SQLConnectionConfig conn)
        {
            _conn = conn;
            connection = new SqlConnection(_conn.Value);
        }
        public async Task ChangeOperation(string SQLQuery)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(SQLQuery, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable ReadOperation(string SQLQuery)
        {
            SqlCommand command = new SqlCommand(SQLQuery, connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
    }
}
