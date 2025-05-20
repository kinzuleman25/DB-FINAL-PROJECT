using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace WpfApp6
{
    public static class DatabaseHelper
    {
        private static string connectionString = "server=127.0.0.1;port=3306;user=root;password=kinza25;database=smajorglazing;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static DataTable ExecuteQuery(string query)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static object ExecuteScalar(string query)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }

    }
}
