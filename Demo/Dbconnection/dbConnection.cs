using MySql.Data.MySqlClient;
using System.Data.Common;
using System;

namespace Demo.Dbconnection
{
    public class dbConnection
    {
        static readonly string _conn = "server=localhost;port=3306;database=demo;uid=root;password=";

        public static DbCommand Command(DbConnection connection, string cmdText)
        {
            return new MySqlCommand(cmdText, (MySqlConnection)connection);
        }
        public static DbConnection NewConnection
        {
            get
            {
                DbConnection connection = null;
                try
                {
                    connection = new MySqlConnection(_conn);
                    connection.Open();
                }
                catch (Exception ex)
                {
                    connection?.Close();
                    throw ex;
                }

                return connection;
            }
        }

    }
}
