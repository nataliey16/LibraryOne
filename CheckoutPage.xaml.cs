namespace LibraryOne;
using LibraryOne.DataBase;
using LibraryOne.BookClass;

public partial class CheckoutPage : ContentPage
{
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

    public CheckoutPage(Book book)
	{
        InitializeComponent();

        SelectedBook = book;
        AuthorFullName = book.AuthorFirstName + " " + book.AuthorLastName;

        this.BindingContext = this;
    }

    private async void GoToMainPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}