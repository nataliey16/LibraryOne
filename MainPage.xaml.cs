﻿namespace LibraryOne;
using LibraryOne.DataBase;
using LibraryOne.BookClass;
using LibraryOne.UserClass;
using MySqlConnector;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using System.Globalization;



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
        // sets input feild text as varible and call capitalize frist letter of each word method
        string BookTitleSearch = CapitalizeFirstLetter(SearchTitle.Text);
        

        string BookAuthorFNSearch = CapitalizeFirstLetter(SearchAuthorFirstName.Text);
        

        string BookAuthorLNSearch = CapitalizeFirstLetter(SearchAuthorLastName.Text);
        

        try // exceptions for is search is null or if author first & last name are not filled out 
        {

            if(string.IsNullOrEmpty(BookTitleSearch) & string.IsNullOrEmpty(BookAuthorFNSearch) & string.IsNullOrEmpty(BookAuthorLNSearch))
            {
                throw new InvalidDataException();
            }
            else if(!string.IsNullOrEmpty(BookTitleSearch) & !string.IsNullOrEmpty(BookAuthorFNSearch) & string.IsNullOrEmpty(BookAuthorLNSearch))
            {
                throw new ArgumentException();
            }
            else if (!string.IsNullOrEmpty(BookTitleSearch) & string.IsNullOrEmpty(BookAuthorFNSearch) & !string.IsNullOrEmpty(BookAuthorLNSearch))
            {
                throw new ArgumentException();
            }
            else if (string.IsNullOrEmpty(BookTitleSearch) & !string.IsNullOrEmpty(BookAuthorFNSearch) & string.IsNullOrEmpty(BookAuthorLNSearch))
            {
                throw new ArgumentException();
            }
            else if (string.IsNullOrEmpty(BookTitleSearch) & string.IsNullOrEmpty(BookAuthorFNSearch) & !string.IsNullOrEmpty(BookAuthorLNSearch))
            {
                throw new ArgumentException();
            }



        }
        catch (InvalidDataException)
        {

            await DisplayAlert("Alert", "Search fields cannot be empty", "OK");

        }
        catch (ArgumentException)
        {
            await DisplayAlert("Alert", "Must enter author first & last name", "OK");
        }


        // look for a match in the books list after input is filled out 
        // exception will throw error if no match is found
        try
        {

            if (!string.IsNullOrEmpty(BookTitleSearch) || (!string.IsNullOrEmpty(BookAuthorFNSearch) & !string.IsNullOrEmpty(BookAuthorLNSearch)))
            {

                foreach (Book book in Allbooks)
                {
                    if (BookTitleSearch == book.Title || (BookAuthorFNSearch == book.AuthorFirstName & BookAuthorLNSearch == book.AuthorLastName))
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




    // Capitalizes first letter of each word for easier input and interaction with database values
    static string CapitalizeFirstLetter(string input)
    {
        if (string.IsNullOrEmpty(input)) // couldnt get exceptions to work without this if 
        {
            return string.Empty;
        }

        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        return textInfo.ToTitleCase(input);
    }






}

