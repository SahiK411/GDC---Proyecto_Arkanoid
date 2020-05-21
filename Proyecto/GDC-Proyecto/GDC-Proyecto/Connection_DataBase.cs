﻿using System.Data;
using Npgsql;

namespace GDC_Proyecto
{
    public static class ConnectionDB
    {
        private static string host = "",
            database = "",
            userId = "",
            password = "";

        private static string sConnection =
            $"Server={host};Port=5432;User Id={userId};Password={password};Database={database};" +
            "sslmode=Require;Trust Server Certificate=true";

        public static DataTable ExecuteQuery(string query)
        {
            NpgsqlConnection connection = new NpgsqlConnection(sConnection);
            DataSet ds = new DataSet();
            
            connection.Open();
            
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(query, connection);
            da.Fill(ds);
            
            connection.Close();

            return ds.Tables[0];
        }

        public static void ExecuteNonQuery(string act)
        {
            NpgsqlConnection connection = new NpgsqlConnection(sConnection);
            
            connection.Open();
            
            NpgsqlCommand command = new NpgsqlCommand(act, connection);
            command.ExecuteNonQuery();
            
            connection.Close();
        }
    }
}