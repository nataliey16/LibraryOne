namespace LibraryOne;
using LibraryOne.DataBase;
using MySqlConnector;

public partial class MainPage : ContentPage
{

    public SqlDatabase Database { get; set; }



    public MainPage()
	{
		InitializeComponent();


        Database = new SqlDatabase();
		Database.Open();

    }


	


	
	
}

