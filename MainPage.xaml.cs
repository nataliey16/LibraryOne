namespace LibraryOne;
using LibraryOne.DataBase;
using LibraryOne.BookClass;
using LibraryOne.UserClass;
using MySqlConnector;

public partial class MainPage : ContentPage
{
    // sets the Database property to class type Sqldatabase
    public SqlDatabase Database { get; set; }

    //Lists
	List<Children> ChildrenBooks = new();

    List<Mystery> MysteryBooks = new();

    List<Romance> RomanceBooks = new();

    List<Science> ScienceBooks = new();

    List<Customer> Customers = new();

    List<Librarian> Librarians = new();



    public MainPage()
	{
		InitializeComponent();


        // inialize and create sqldatabase object/class
        Database = new SqlDatabase();


        // calls open method in sqldatabase class 
		Database.Open();


        // calls methods in sql data base class and stores values into the lists
        Customers = Database.LoadCustomers();

        Librarians = Database.LoadLibrarians();

        // set a method call for each book type 
        ChildrenBooks = Database.LoadChildrenBooks();

    }


	


	
	
}

