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



        // Loads from children book table
        public List<Children> LoadChildrenBooks()
        {
            MySqlCommand command = SqlConnection.CreateCommand();

            command.CommandText = "SELECT * FROM Childrenbooks";

            MySqlDataReader dataReader = command.ExecuteReader();

            List<Children> childbooks = new();


            while (dataReader.Read())
            {
                string isbn = dataReader.GetString(0);

                string bookTitle = dataReader.GetString(1);

                string authorFirstName = dataReader.GetString(2);

                string authorLastName = dataReader.GetString(3);

                bool isCheckedOut = dataReader.GetBoolean(4);

                string checkOutDate = dataReader.GetString(5);

                string returnDate = dataReader.GetString(6);

                int ageGroup = dataReader.GetInt32(7);

                int learningLevel = dataReader.GetInt32(8);

                string message = dataReader.GetString(9);


                Children childrenbook = new Children(isbn, bookTitle, authorFirstName, authorLastName, isCheckedOut, checkOutDate, returnDate, ageGroup, learningLevel, message);

                childbooks.Add(childrenbook);
            }


            dataReader.Close();
            command.Dispose();

            return childbooks;
        }



        // Loads from Mystery table
        public List<Mystery> LoadMysteryBooks()
        {
            MySqlCommand command = SqlConnection.CreateCommand();

            command.CommandText = "SELECT * FROM Mysterybooks";

            MySqlDataReader dataReader = command.ExecuteReader();

            List<Mystery> mysterybooks = new();


            while (dataReader.Read())
            {
                string isbn = dataReader.GetString(0);

                string bookTitle = dataReader.GetString(1);

                string authorFirstName = dataReader.GetString(2);

                string authorLastName = dataReader.GetString(3);

                bool isCheckedOut = dataReader.GetBoolean(4);

                string checkOutDate = dataReader.GetString(5);

                string returnDate = dataReader.GetString(6);

                int suspenseLevel = dataReader.GetInt32(7);

                string literatureType = dataReader.GetString(8);

                


                Mystery mysterybook = new Mystery(isbn, bookTitle, authorFirstName, authorLastName, isCheckedOut, checkOutDate, returnDate, suspenseLevel, literatureType);

                mysterybooks.Add(mysterybook);
            }


            dataReader.Close();
            command.Dispose();

            return mysterybooks;
        }


        // Loads from Romance table
        public List<Romance> LoadRomanceBooks()
        {
            MySqlCommand command = SqlConnection.CreateCommand();

            command.CommandText = "SELECT * FROM Romancebooks";

            MySqlDataReader dataReader = command.ExecuteReader();

            List<Romance> romancebooks = new();


            while (dataReader.Read())
            {
                string isbn = dataReader.GetString(0);

                string bookTitle = dataReader.GetString(1);

                string authorFirstName = dataReader.GetString(2);

                string authorLastName = dataReader.GetString(3);

                bool isCheckedOut = dataReader.GetBoolean(4);

                string checkOutDate = dataReader.GetString(5);

                string returnDate = dataReader.GetString(6);

                string tone = dataReader.GetString(7);

                string setting = dataReader.GetString(8);




                Romance romancebook = new Romance(isbn, bookTitle, authorFirstName, authorLastName, isCheckedOut, checkOutDate, returnDate, tone, setting);

                romancebooks.Add(romancebook);
            }


            dataReader.Close();
            command.Dispose();

            return romancebooks;
        }


        // Loads from Romance table
        public List<Science> LoadScienceBooks()
        {
            MySqlCommand command = SqlConnection.CreateCommand();

            command.CommandText = "SELECT * FROM Sciencebooks";

            MySqlDataReader dataReader = command.ExecuteReader();

            List<Science> sciencebooks = new();


            while (dataReader.Read())
            {
                string isbn = dataReader.GetString(0);

                string bookTitle = dataReader.GetString(1);

                string authorFirstName = dataReader.GetString(2);

                string authorLastName = dataReader.GetString(3);

                bool isCheckedOut = dataReader.GetBoolean(4);

                string checkOutDate = dataReader.GetString(5);

                string returnDate = dataReader.GetString(6);

                string subject = dataReader.GetString(7);

                int scienctificLevel = dataReader.GetInt32(8);

                string type = dataReader.GetString(9);




                Science sciencebook = new Science(isbn, bookTitle, authorFirstName, authorLastName, isCheckedOut, checkOutDate, returnDate, subject, scienctificLevel, type);

                sciencebooks.Add(sciencebook);
            }


            dataReader.Close();
            command.Dispose();

            return sciencebooks;
        }


		//public void Add(Science science)
		//{	

		//	// Create MySqlCommand instance
		//	MySqlCommand command = SqlConnection.CreateCommand();

		//	// Create the SQL statement
		//	// Ensure quotes are placed around string values.
		//	command.CommandText = string.Format("INSERT INTO sciencebooks VALUES('{0}', '{1}', '{2}','{3}', {4}, '{5}', '{6}', '{7}', {8}, '{9}'", science.Isbn, science.Title, science.AuthorFirstName, science.AuthorLastName, science.IsCheckedOut, science.CheckOutDate, science.ReturnDate, science.Subject, science.ScientificLevel, science.TypeOfBook);

		//	// Execute the SQL statement
		//	// Must use the "ExecuteNonQuery" method when writing to the database.
		//	command.ExecuteNonQuery();

		//	// Ensure the cmd resources are disposed since it's no longer used.
		//	command.Dispose();
		//}

        //Add to Sciencebooks Database
		public void Add(Science science)
		{
			// Create MySqlCommand instance
			MySqlCommand command = SqlConnection.CreateCommand();

			// Create the SQL statement
			// Ensure quotes are placed around string values.
			command.CommandText = string.Format("INSERT INTO sciencebooks VALUES('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}', '{7}', {8}, '{9}')",
				science.Isbn, science.Title, science.AuthorFirstName, science.AuthorLastName, science.IsCheckedOut, science.CheckOutDate, science.ReturnDate, science.Subject, science.ScientificLevel, science.TypeOfBook);

			// Execute the SQL statement
			// Must use the "ExecuteNonQuery" method when writing to the database.
			command.ExecuteNonQuery();

			// Ensure the cmd resources are disposed since it's no longer used.
			command.Dispose();
		}

        //Add to Childrens books database
		public void Add(Children children)
		{
			// Create MySqlCommand instance
			MySqlCommand command = SqlConnection.CreateCommand();

			// Create the SQL statement
			// Ensure quotes are placed around string values.
			command.CommandText = string.Format("INSERT INTO childrenbooks VALUES('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}', {7}, {8}, '{9}')",
				children.Isbn, children.Title, children.AuthorFirstName, children.AuthorLastName, children.IsCheckedOut, children.CheckOutDate, children.ReturnDate, children.AgeGroup, children.LearningLevel, children.Message);

			// Execute the SQL statement
			// Must use the "ExecuteNonQuery" method when writing to the database.
			command.ExecuteNonQuery();

			// Ensure the cmd resources are disposed since it's no longer used.
			command.Dispose();
		}

		//Add to Mystery books database
		public void Add(Mystery mystery)
		{
			// Create MySqlCommand instance
			MySqlCommand command = SqlConnection.CreateCommand();

			// Create the SQL statement
			// Ensure quotes are placed around string values.
			command.CommandText = string.Format("INSERT INTO mysterybooks VALUES('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}', {7}, '{8}')",
				mystery.Isbn, mystery.Title, mystery.AuthorFirstName, mystery.AuthorLastName, mystery.IsCheckedOut, mystery.CheckOutDate, mystery.ReturnDate, mystery.SuspenseLevel, mystery.LiteratureType);

			// Execute the SQL statement
			// Must use the "ExecuteNonQuery" method when writing to the database.
			command.ExecuteNonQuery();

			// Ensure the cmd resources are disposed since it's no longer used.
			command.Dispose();
		}

		//Add to Romance books database

		public void Add(Romance romance)
		{
			// Create MySqlCommand instance
			MySqlCommand command = SqlConnection.CreateCommand();

			// Create the SQL statement
			// Ensure quotes are placed around string values.
			command.CommandText = string.Format("INSERT INTO romancebooks VALUES('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}', '{7}', '{8}')",
				romance.Isbn, romance.Title, romance.AuthorFirstName, romance.AuthorLastName, romance.IsCheckedOut, romance.CheckOutDate, romance.ReturnDate, romance.Tone, romance.Setting);

			// Execute the SQL statement
			// Must use the "ExecuteNonQuery" method when writing to the database.
			command.ExecuteNonQuery();

			// Ensure the cmd resources are disposed since it's no longer used.
			command.Dispose();
		}
	}
}

