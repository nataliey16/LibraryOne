using Microsoft.Maui;
using System.Collections.ObjectModel;

namespace LibraryOne;

public partial class AddBooksPage : ContentPage
{

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
		this.BookCategories = new ObservableCollection<string>();
		this.BookCategoryPlaceholders = new List<string> { };

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

	//private void UpdateUIForCategory(string expectedSelectedCategory)
	//{
	//	// Clear existing UI elements every time picker changes
	//	bookCategoryLayout.Children.Clear();

	//	if (expectedSelectedCategory == "Science")
	//	{
	//		Entry entry1 = new Entry { Placeholder = "Subject" };
	//		Entry entry2 = new Entry { Placeholder = "Scientific Level" };
	//		Entry entry3 = new Entry { Placeholder = "Type" };

	//		bookCategoryLayout.Children.Add(entry1);
	//		bookCategoryLayout.Children.Add(entry2);
	//		bookCategoryLayout.Children.Add(entry3);
	//	}
	//	else if (expectedSelectedCategory == "Kids")
	//	{
	//		Entry entry1 = new Entry { Placeholder = "Age Group" };
	//		Entry entry2 = new Entry { Placeholder = "Learning Level" };
	//		Entry entry3 = new Entry { Placeholder = "Main Message" };

	//		bookCategoryLayout.Children.Add(entry1);
	//		bookCategoryLayout.Children.Add(entry2);
	//		bookCategoryLayout.Children.Add(entry3);
	//	}
	//	else if (expectedSelectedCategory == "Mystery")
	//	{
	//		Entry entry1 = new Entry { Placeholder = "Suspense Level" };
	//		Entry entry2 = new Entry { Placeholder = "Literature Type" };

	//		bookCategoryLayout.Children.Add(entry1);
	//		bookCategoryLayout.Children.Add(entry2);
	//	}
	//	else if (expectedSelectedCategory == "Romance")
	//	{
	//		Entry entry1 = new Entry { Placeholder = "Tone" };
	//		Entry entry2 = new Entry { Placeholder = "Setting" };

	//		bookCategoryLayout.Children.Add(entry1);
	//		bookCategoryLayout.Children.Add(entry2);
	//	}

	//	// For example, you can show/hide certain input boxes or change their properties
	//}


	//private void UpdateUIForCategory(string expectedSelectedCategory)
	//{

	//	// Clear existing UI elements every time picker changes
	//	bookCategoryLayout.Children.Clear();

	//	if (expectedSelectedCategory == "Science")
	//	{
	//		Entry entry1 = new Entry { Placeholder = "Subject" };
	//		Entry entry2 = new Entry { Placeholder = "Scientific Level" };
	//		Entry entry3 = new Entry { Placeholder = "Type" };

	//		bookCategoryLayout.Children.Add(entry1);
	//		bookCategoryLayout.Children.Add(entry2);
	//		bookCategoryLayout.Children.Add(entry3);
	//	}
	//	else if (expectedSelectedCategory == "Kids")
	//	{
	//		Entry entry1 = new Entry { Placeholder = "Age Group" };
	//		Entry entry2 = new Entry { Placeholder = "Learning Level" };
	//		Entry entry3 = new Entry { Placeholder = "Main Message" };

	//		bookCategoryLayout.Children.Add(entry1);
	//		bookCategoryLayout.Children.Add(entry2);
	//		bookCategoryLayout.Children.Add(entry3);
	//	}
	//	else if (expectedSelectedCategory == "Mystery")
	//	{
	//		Entry entry1 = new Entry { Placeholder = "Suspense Level" };
	//		Entry entry2 = new Entry { Placeholder = "Literature Type" };

	//		bookCategoryLayout.Children.Add(entry1);
	//		bookCategoryLayout.Children.Add(entry2);
	//	}
	//	else if (expectedSelectedCategory == "Romance")
	//	{
	//		Entry entry1 = new Entry { Placeholder = "Tone" };
	//		Entry entry2 = new Entry { Placeholder = "Setting" };

	//		bookCategoryLayout.Children.Add(entry1);
	//		bookCategoryLayout.Children.Add(entry2);
	//	}

	//	// For example, you can show/hide certain input boxes or change their properties

	//}

}

