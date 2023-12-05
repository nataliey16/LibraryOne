using System;
using MySqlConnector;
using LibraryOne.BookClass;
using LibraryOne.UserClass;


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
            connectionStringBuilder.Password = "password";
            connectionStringBuilder.Database = "Library";




            SqlConnection = new MySqlConnection(connectionStringBuilder.ConnectionString);

            SqlConnection.Open();

        }


        public List<User> LoadEmployees()
        {
            MySqlCommand command = SqlConnection.CreateCommand();

            command.CommandText = "SELECT * FROM Customers";

            MySqlDataReader dataReader = command.ExecuteReader();

            List<User> customers = new();


            while (dataReader.Read())
            {

            }


            return customers;
        }
    }
}

