using Microsoft.Maui;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using LibraryOne.DataBase;
using LibraryOne.BookClass;

namespace LibraryOne;

public partial class AddBooksPage : ContentPage
{
	//Add Database functionality
	public SqlDatabase Database { get; set; }

	//Stores all Science Books
	public List<Science> AllScienceBooks { get; set; }



	//Create an observational list of book categories for Category Picker
	public ObservableCollection<string> BookCategories { get; set; }

	//Create a list of placeholders for each book category
	public List<string> BookCategoryPlaceholders { get; set; }
	
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
		this.AllScienceBooks = new List<Science>();
		this.BookCategories = new ObservableCollection<string>();
		this.BookCategoryPlaceholders = new List<string> { };

		//BIND CONTENT TO XAML
		this.BindingContext = this;

		// Create connection to database
		this.Database = new SqlDatabase();
		this.Database.Open();

		//CALL METHOD
		LoadScienceBookFromDatabase();
		ListBookCategories();
	}

	private void LoadScienceBookFromDatabase()
	{
		//this.AllScienceBooks.Clear();

		//// Get employees from database
		////List<Science> results = this.Database.All();

		//// Add science books to AllScienceBooks
		//this.AllScienceBooks.AddRange(results);
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

	//METHOD TO DYNAMTICALL UPDATE UI DEPENDING ON SELECTED CATEGORY
	
	private void BookCategoryPickerChanged(object sender, EventArgs e)
	{

		//Expected selected input category
		string expectedSelectedCategory;
		expectedSelectedCategory = (string)findBookCategoryFromPicker.SelectedItem;

		//Default the selection is false
		bool findSelectedBookCategory = false;

		//Verify that user selects a category
		if (expectedSelectedCategory != null)
		{
			findSelectedBookCategory = true;
		}
		else
		{
			DisplayAlert("Error", "Please select a Book Category.", "OK");
		}


		// Update UI based on the selected category
		UpdateUIForCategory(expectedSelectedCategory);
	}

	private void UpdateUIForCategory(string expectedSelectedCategory)
	{
		// Clear existing UI elements every time picker changes
		bookCategoryLayout.Children.Clear();

		if (expectedSelectedCategory == "Science")
		{
			Entry entry1 = new Entry { Placeholder = "Subject" };
			entry1.Style = (Style)Application.Current.Resources["CommonEntryStyle"];
			bookCategoryLayout.Children.Add(entry1);

			Entry entry2 = new Entry { Placeholder = "Scientific Level" };
			entry2.Style = (Style)Application.Current.Resources["CommonEntryStyle"];
			bookCategoryLayout.Children.Add(entry2);

			Entry entry3 = new Entry { Placeholder = "Type" };
			entry3.Style = (Style)Application.Current.Resources["CommonEntryStyle"];
			bookCategoryLayout.Children.Add(entry3);
		}
		// For example, you can show/hide certain input boxes or change their properties
		else if (expectedSelectedCategory == "Kids")
		{
			Entry entry1 = new Entry { Placeholder = "Age Group" };
			entry1.Style = (Style)Application.Current.Resources["CommonEntryStyle"];
			bookCategoryLayout.Children.Add(entry1);

			Entry entry2 = new Entry { Placeholder = "Learning Level" };
			entry2.Style = (Style)Application.Current.Resources["CommonEntryStyle"];
			bookCategoryLayout.Children.Add(entry2);

			Entry entry3 = new Entry { Placeholder = "Message" };
			entry3.Style = (Style)Application.Current.Resources["CommonEntryStyle"];
			bookCategoryLayout.Children.Add(entry3);
		}

		else if (expectedSelectedCategory == "Mystery")
		{
			Entry entry1 = new Entry { Placeholder = "Suspense Level" };
			entry1.Style = (Style)Application.Current.Resources["CommonEntryStyle"];
			bookCategoryLayout.Children.Add(entry1);

			Entry entry2 = new Entry { Placeholder = "Literature Type" };
			entry2.Style = (Style)Application.Current.Resources["CommonEntryStyle"];
			bookCategoryLayout.Children.Add(entry2);

		}
		else if (expectedSelectedCategory == "Romance")
		{
			Entry entry1 = new Entry { Placeholder = "Tone" };
			entry1.Style = (Style)Application.Current.Resources["CommonEntryStyle"];
			bookCategoryLayout.Children.Add(entry1);

			Entry entry2 = new Entry { Placeholder = "Setting" };
			entry2.Style = (Style)Application.Current.Resources["CommonEntryStyle"];
			bookCategoryLayout.Children.Add(entry2);

		}
	}

	private void ClickAddBook(object sender, EventArgs e)
	{
		//Input values
		string isbn;
		string title;
		string authorFirstName;
		string authorLastName;

		//Input values for Science
		string subject; // e.g., Biology, Chemistry, Physics
		int scientificLevel; // beginner, intermediate, advanced
		string typeOfBook; // textbook, journal, report

		//Input values for Children
		int ageGroup; //preschool (age: 2-5), early readers (ages 6-8), middle grade (ages: 9-12), teens (ages: 13-17)
		int learningLevel; //beginner, intermediate, advanced
		string message; // alphabets, being kind, bullying, puberty

		//Input values for Mystery book: 
		int suspenseLevel; //low, medium, high
		string literatureType; // fiction or non - fiction

		string tone; // romantic, dramatic, humorous
		string setting; //location/time period

		if (string.IsNullOrEmpty(addAuthorLastName.Text) == false)
		{
			authorLastName = addAuthorLastName.Text;
		}
		else
		{
			DisplayAlert("Error", "Author last name is empty. Please try again.", "Ok");
			authorLastName = "";
		}

		if (string.IsNullOrEmpty(addAuthorFirstName.Text) == false)
		{
			authorFirstName = addAuthorFirstName.Text;
		}
		else
		{
			DisplayAlert("Error", "Author first name is empty. Please try again.", "Ok");
			authorLastName = "";
		}

		if (string.IsNullOrEmpty(addBookTitle.Text) == false)
		{
			title = addBookTitle.Text;
		}
		else
		{
			DisplayAlert("Error", "Book title is empty. Please try again.", "Ok");
			title = "";
		}

		if (string.IsNullOrEmpty(addBookISBN.Text) == false)
		{
			isbn = addBookISBN.Text;
		}
		else
		{
			DisplayAlert("Error", "Book ISBN is empty. Please try again.", "Ok");
			isbn = "";
		}

		if (string.IsNullOrEmpty(addBookISBN.Text) == false)
		{
			isbn = addBookISBN.Text;
		}
		else
		{
			DisplayAlert("Error", "Book ISBN is empty. Please try again.", "Ok");
			isbn = "";
		}




	}

}

