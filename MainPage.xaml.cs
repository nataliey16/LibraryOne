namespace LibraryOne;
using LibraryOne.DataBase;
using LibraryOne.BookClass;
using LibraryOne.UserClass;
using MySqlConnector;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;

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

    List<Book> Allbooks = new();

    // picker for found books
    ObservableCollection<string> Foundbooks = new ObservableCollection<string>();

    

    public MainPage()
	{
		InitializeComponent();

        BindingContext = this;

        // inialize and create sqldatabase object/class
        Database = new SqlDatabase();


        // calls open method in sqldatabase class 
		Database.Open();


        // calls methods in sql data base class and stores values into the lists
        Customers = Database.LoadCustomers();

        Librarians = Database.LoadLibrarians();


        ChildrenBooks = Database.LoadChildrenBooks();
        Allbooks.AddRange(ChildrenBooks);


        MysteryBooks = Database.LoadMysteryBooks();
        Allbooks.AddRange(MysteryBooks);


        RomanceBooks = Database.LoadRomanceBooks();
        Allbooks.AddRange(RomanceBooks);


        ScienceBooks = Database.LoadScienceBooks();
        Allbooks.AddRange(ScienceBooks);

        // found book picker item source = observable collection
        BookPicker.ItemsSource = Foundbooks;
        
       
        

    }


    // on search button clicked calls search method 
    public void Button_ClickedSearch(System.Object sender, System.EventArgs e)
    {
        SearchBook();
        
    }



    // Search for book 
    public async void SearchBook()
    {
        // sets input feild text as varible
        string BookTitleSerach = SearchTitle.Text;

        string BookAuthorFNSearch = SearchAuthorFirstName.Text;

        string BookAuthorLNSearch = SearchAuthorLastName.Text;


        try // exceptions for is search is null
        {

            if(string.IsNullOrEmpty(BookTitleSerach) & string.IsNullOrEmpty(BookAuthorFNSearch) & string.IsNullOrEmpty(BookAuthorLNSearch))
            {
                throw new InvalidDataException();
            }

        }
        catch (InvalidDataException)
        {

            await DisplayAlert("Alert", "Search fields cannot be empty", "OK");

        }

        // look for a match in the books list after input is filled out 
        // exception will throw error if no match is found
        try
        {

            if (!string.IsNullOrEmpty(BookTitleSerach) || (!string.IsNullOrEmpty(BookAuthorFNSearch) & !string.IsNullOrEmpty(BookAuthorLNSearch)))
            {

                foreach (Book book in Allbooks)
                {
                    if (BookTitleSerach == book.Title || (BookAuthorFNSearch == book.AuthorFirstName & BookAuthorLNSearch == book.AuthorLastName))
                    {


                        string DisplayBook = $"ISBN: {book.Isbn}, Title: {book.Title}, Author: {book.AuthorFirstName} {book.AuthorLastName}";

                        Foundbooks.Add(DisplayBook);
                        return;

                    }
                    
                }

                throw new ArgumentException();
                    
            }
                
            
            

        }
        catch (ArgumentException)
        {
            await DisplayAlert("Alert", "Could not find that book or author", "Search Again");
        }
        

    }

   
}

