using System;
using MySqlConnector;

namespace LibraryOne.DataBase
{
    public class SqlDatabase
    {
        public SqlDatabase()
        {
        }


        private MySqlConnection SqlConnection;


        public void Open()
        {
            MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();

            connectionStringBuilder.Server = "localhost";
            connectionStringBuilder.UserID = "root";
            connectionStringBuilder.Password = "Password35!";
            connectionStringBuilder.Database = "Library";



            SqlConnection = new MySqlConnection(connectionStringBuilder.ConnectionString);

            SqlConnection.Open();

        }

    }
}

