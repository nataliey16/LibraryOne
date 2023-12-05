namespace LibraryOne;
using LibraryOne.DataBase;
using LibraryOne.BookClass;
using LibraryOne.UserClass;
using MySqlConnector;

public partial class MainPage : ContentPage
{

    public SqlDatabase Database { get; set; }

	List<Book> books = new();

    List<User> Customers = new();

    List<User> Librarians = new();


    public MainPage()
	{
		InitializeComponent();


        Database = new SqlDatabase();
		Database.Open();


        User customerResults = Database.LoadEmployees();

        Customers.Add(customerResults);
    }


	


	
	
}

