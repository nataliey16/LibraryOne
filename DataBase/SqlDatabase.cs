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

        // sets sqlconnection property 
        private MySqlConnection SqlConnection;


        // method to connect to the database 
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


        // reads the customers table and creates object adds it to a list and returns list with customer objects 
        public List<Customer> LoadCustomers()
        {
            MySqlCommand command = SqlConnection.CreateCommand();

            command.CommandText = "SELECT * FROM Customers";

            MySqlDataReader dataReader = command.ExecuteReader();

            List<Customer> customers = new();


            while (dataReader.Read())
            {
                int id = dataReader.GetInt32(0);

                string custFirstName = dataReader.GetString(1);

                string custLastName = dataReader.GetString(2);

                string custEmail = dataReader.GetString(3);


                Customer customer = new Customer(id, custFirstName, custLastName, custEmail);

                customers.Add(customer);
            }

            dataReader.Close();
            command.Dispose();

            return customers;
        }



        // reads the Librarians table and creates object adds it to a list and returns list with librarain objects 
        public List<Librarian> LoadLibrarians()
        {
            MySqlCommand command = SqlConnection.CreateCommand();

            command.CommandText = "SELECT * FROM Librarian";

            MySqlDataReader dataReader = command.ExecuteReader();

            List<Librarian> librarians = new();


            while (dataReader.Read())
            {
                int id = dataReader.GetInt32(0);

                string libFirstName = dataReader.GetString(1);

                string libLastName = dataReader.GetString(2);

                string libEmail = dataReader.GetString(3);


                Librarian librarian = new Librarian(id, libFirstName, libLastName, libEmail);

                librarians.Add(librarian);
            }


            dataReader.Close();
            command.Dispose();

            return librarians;
        }



        // 
        public List<Children> LoadChildrenBooks()
        {
            MySqlCommand command = SqlConnection.CreateCommand();

            command.CommandText = "SELECT isbn, LEFT(isbn, 1) as \"first digit\", bookTitle , authorFirstName , authorLastName  \nFROM Library.Books b\nWHERE LEFT(isbn, 1) = 0;";

            MySqlDataReader dataReader = command.ExecuteReader();

            List<Children> books = new();


            while (dataReader.Read())
            {
                
                int isbn = dataReader.GetInt32(0);

                string BookTitle = dataReader.GetString(1);

                string authorFirstName = dataReader.GetString(2);

                string authorLastName = dataReader.GetString(3);

                bool isCheckedOut = dataReader.GetBoolean(4);

                string checkOutDate = dataReader.GetString(5);

                string returnDate = dataReader.GetString(6);



                Children book = new Children(isbn, BookTitle, authorFirstName, authorLastName, isCheckedOut, checkOutDate, returnDate);

                books.Add(book);
            }


            dataReader.Close();
            command.Dispose();

            return librarians;
        }
    }
}

