namespace LibraryOne;
using LibraryOne.DataBase;
using LibraryOne.BookClass;

public partial class CheckoutPage : ContentPage
{
    //Add Database functionality
    public SqlDatabase Database { get; set; }

    // Added for picker function in checkout page
    private Book selectedBook;
    public Book SelectedBook
    {
        get { return selectedBook; }
        set
        {
            selectedBook = value;
            OnPropertyChanged();
        }
    }

    private string authorFullName;
    public string AuthorFullName
    {
        get { return authorFullName; }
        set
        {
            authorFullName = value;
            OnPropertyChanged();
        }
    }

    private bool availability;
    public bool Availability
    {
        get { return availability; }
        set
        {
            availability = value;
            OnPropertyChanged();
        }
    }

    public CheckoutPage(Book book)
	{
        InitializeComponent();

        SelectedBook = book;
        AuthorFullName = book.AuthorFirstName + " " + book.AuthorLastName;
        Availability = !book.IsCheckedOut;

        this.BindingContext = this;

        // Create connection to database
        this.Database = new SqlDatabase();
        this.Database.Open();
    }

    private async void GoToMainPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void ClickSubmitCheckOut(object sender, EventArgs e)
    {      
        // Update the database to mark the book as checked out and set the CheckedOutDate to the current date
        this.Database.UpdateBook(SelectedBook.Isbn, true);

        await Navigation.PushAsync(new MainPage());

        // Tell the user the book was checked out
        this.DisplayAlert("Success!", "Book checked out", "OK");
    }
}