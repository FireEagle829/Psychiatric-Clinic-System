using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Psychiatric
{
    class Database
    {
        SqlConnection conn = new SqlConnection("Data Source=(local);Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public DataTable Read(string statement)
        {
            DataTable table = new DataTable();
            cmd.Connection = conn;
            cmd.CommandText = statement;
            conn.Open();
            table.Load(cmd.ExecuteReader());
            conn.Close();
            return table;
        }

        public void Write(string statement)
        {
            cmd.Connection = conn;
            cmd.CommandText = statement;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return;
        }
    }
}
