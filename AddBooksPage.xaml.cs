using System.Collections.ObjectModel;

namespace LibraryOne;

public partial class AddBooksPage : ContentPage
{

	//Create an observational list of book categories for Category Picker
	public ObservableCollection<string> BookCategories { get; set; }
	
	//Get full path of the CSV path 
	public string BookCategoriesCSVFilePath
	{
		get {

			string csvBookCategoriesFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\categories.csv");
			return csvBookCategoriesFilePath;
		}
	}
	public AddBooksPage()
	{
		InitializeComponent();
		//CREATE ITEMS
		this.BookCategories = new ObservableCollection<string>();


		//BIND CONTENT TO XAML
		this.BindingContext = this;

		//CALL METHOD
		ListBookCategories();
	}


	private void ListBookCategories()
	{
		this.BookCategories.Clear();

		//Create an array of Book Categories
		string[] lines = File.ReadAllLines(this.BookCategoriesCSVFilePath);

		foreach (string line in lines)
        {
			string[] columns = line.Split();
			if (columns.Length > 0)
			{
				string bookCategory = columns[0];
				this.BookCategories.Add(bookCategory);
			}
        }
    }
}