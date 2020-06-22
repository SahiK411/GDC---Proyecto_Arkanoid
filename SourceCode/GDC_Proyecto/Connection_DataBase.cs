using System;
using System.Data;
using Npgsql;

namespace GDC_Proyecto
{
    class Connection_DataBase
    {
        private static string host = "ec2-18-209-187-54.compute-1.amazonaws.com",
            database = "dartithgc6pdad",
            userId = "elquyvcumthlll",
            password = "d1987de60e45c8f18ab6638266ff62cf6361d7bd0829b1868bdeea5674b2688a";

        private static string sConnection =
            $"Server={host};Port=5432;User Id={userId};Password={password};Database={database};" +
            "sslmode=Require;Trust Server Certificate=true";

        public static DataTable ExecuteQuery(string query)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(sConnection);
                DataSet ds = new DataSet();

                connection.Open();

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connection);
                da.Fill(ds);

                connection.Close();

                return ds.Tables[0];
            }
            catch (Exception)
            {
                throw new UnableToConnectException("Error de Conexion.");
            }
        }

        public static void ExecuteNonQuery(string act)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(sConnection);

                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand(act, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception)
            {
                throw new UnableToConnectException("Error de Conexion.");
            }
        }
    }
}
