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

	//Stores all Children Books
	public List<Children> AllChildrenBooks { get; set; }

	//Store all Mystery Books
	public List<Mystery> AllMysteryBooks { get; set; }

	//Store all Romance Books
	public List<Romance> AllRomanceBooks { get; set; }	

	//Create an observational list of book categories for Category Picker
	public ObservableCollection<string> BookCategories { get; set; }

	//Create a observable collection of the Bookentry status
	public ObservableCollection<bool> EntryIsEnabled {  get; set; }

	
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
		this.AllChildrenBooks = new List<Children>();
		this.AllMysteryBooks = new List<Mystery>();
		this.AllRomanceBooks = new List<Romance>();

		this.BookCategories = new ObservableCollection<string>();
		this.EntryIsEnabled = new ObservableCollection<bool>();

		//BIND CONTENT TO XAML
		this.BindingContext = this;

		// Create connection to database
		this.Database = new SqlDatabase();
		this.Database.Open();

		//CALL METHOD
		ListBookCategories();
		//ApplyEntryBoxStates(expectedSelectedCategory);
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
		this.EntryIsEnabled.Clear(); // Clear the previous state

		if (expectedSelectedCategory == "Science")
		{
			// Enable the entry boxes for Science category
			this.EntryIsEnabled.Add(true); // Enable Subject
			this.EntryIsEnabled.Add(true); // Enable Scientific Level
			this.EntryIsEnabled.Add(true); // Enable Type of Book
		}
		else if (expectedSelectedCategory == "Children")
		{
			// Enable the entry boxes for Children category
			this.EntryIsEnabled.Add(true); // Enable Age Group
			this.EntryIsEnabled.Add(true); // Enable Learning Level
			this.EntryIsEnabled.Add(true); // Enable Message
		}
		else if (expectedSelectedCategory == "Mystery")
		{
			// Enable the entry boxes for Mystery category
			this.EntryIsEnabled.Add(true); // Enable Suspense Level
			this.EntryIsEnabled.Add(true); // Enable Literature Type
		}
		else if (expectedSelectedCategory == "Romance")
		{
			// Enable the entry boxes for Mystery category
			this.EntryIsEnabled.Add(true); // Enable Suspense Level
			this.EntryIsEnabled.Add(true); // Enable Literature Type
		}
		else
		{
			// Disable the entry boxes for other categories
			DisableEntry();
		}


		// Apply the entry box states to your UI controls
		ApplyEntryBoxStates(expectedSelectedCategory);
	}

	private void DisableEntry()
	{
		// Disable all entry boxes
		this.EntryIsEnabled.Add(false); // Disable Subject
		this.EntryIsEnabled.Add(false); // Disable Scientific Level
		this.EntryIsEnabled.Add(false); // Disable Type of Book
		this.EntryIsEnabled.Add(false); // Disable Age Group
		this.EntryIsEnabled.Add(false); // Disable Learning Level
		this.EntryIsEnabled.Add(false); // Disable Message
		this.EntryIsEnabled.Add(false); // Disable Message
	}


	// Implement this method to apply the boolean values to your entry boxes in the UI
	private void ApplyEntryBoxStates(string expectedSelectedCategory)
	{


		//By default, entry boxes are disabled 
		this.addSubject.IsEnabled = false;
		this.addScientificLevel.IsEnabled = false;
		this.addTypeOfBook.IsEnabled = false;
		this.addAgeGroup.IsEnabled = false;
		this.addLearningLevel.IsEnabled = false;
		this.addMessage.IsEnabled = false;
		this.addSuspenseLevel.IsEnabled = false;
		this.addLiteratureType.IsEnabled = false;	
		this.addTone.IsEnabled = false;	
		this.addSetting.IsEnabled = false;	

		if (expectedSelectedCategory == "Science" && EntryIsEnabled.Count >= 3)
		{
				this.addSubject.IsEnabled = EntryIsEnabled[0];
				this.addScientificLevel.IsEnabled = EntryIsEnabled[1];
			this.addTypeOfBook.IsEnabled = EntryIsEnabled[2];
		}
		else if (expectedSelectedCategory == "Children" && EntryIsEnabled.Count >= 3)
		{
		
				this.addAgeGroup.IsEnabled = EntryIsEnabled[0];
				this.addLearningLevel.IsEnabled = EntryIsEnabled[1];
				this.addMessage.IsEnabled = EntryIsEnabled[2];
		}
		else if (expectedSelectedCategory == "Mystery" && EntryIsEnabled.Count >= 2)
		{
				this.addSuspenseLevel.IsEnabled = EntryIsEnabled[0];
			this.addLiteratureType.IsEnabled = EntryIsEnabled[1];
		}
		else if (expectedSelectedCategory == "Romance" && EntryIsEnabled.Count >= 2)
		{
			this.addTone.IsEnabled = EntryIsEnabled[0];
			this.addSetting.IsEnabled = EntryIsEnabled[1];
		}
	}


	private void ClickAddBook(object sender, EventArgs e)
	{
		//Input values
		string authorFirstName;
		string authorLastName;
		string isbn;
		string title;
		bool isCheckedOut;
		string checkOutDate;
		string returnDate;

		//string bookCategory;
		//Input values for Science
		string subject; // e.g., Biology, Chemistry, Physics
		int scientificLevel; // beginner, intermediate, advanced
		string typeOfBook; // textbook, journal, report

		//Input values for Children
		int ageGroup; //preschool (age: 2-5), early readers (ages 6-8), middle grade (ages: 9-12), teens (ages: 13-17)
		int learningLevel; //beginner, intermediate, advanced
		string message; // alphabets, being kind, bullying, puberty

		////Input values for Mystery book: 
		int suspenseLevel; //low, medium, high
		string literatureType; // fiction or non - fiction

		string tone; // romantic, dramatic, humorous
		string setting; //location/time period

		if (string.IsNullOrEmpty(this.addAuthorLastName.Text) == false)
		{
			authorLastName = this.addAuthorLastName.Text;
		}
		else
		{
			authorLastName = "";
		}

		if (string.IsNullOrEmpty(this.addAuthorFirstName.Text) == false)
		{
			authorFirstName = this.addAuthorFirstName.Text;
		}
		else
		{
			authorFirstName = "";
		}

		if (string.IsNullOrEmpty(this.addBookTitle.Text) == false)
		{
			title = this.addBookTitle.Text;
		}
		else
		{
			title = "";
		}

		if (string.IsNullOrEmpty(this.addBookISBN.Text) == false)
		{
			isbn = this.addBookISBN.Text;
		}
		else
		{
			isbn = "";
		}

		if (string.IsNullOrEmpty(this.addCheckOutStatus.Text) == false)
		{
			isCheckedOut = true;
		}
		else
		{
			isCheckedOut = false;
		}


		if (string.IsNullOrEmpty(this.addCheckOutDate.Text) == false)
		{
			checkOutDate = this.addCheckOutDate.Text;
		}
		else
		{
			checkOutDate = "";
		}

		if (string.IsNullOrEmpty(this.addReturnDate.Text) == false)
		{
			returnDate = this.addReturnDate.Text;
		}
		else
		{
			returnDate = "";
		}


		if (string.IsNullOrEmpty(this.addSubject.Text) == false)
		{
			subject = this.addSubject.Text;
		}
		else
		{
			subject = "";
		}

		if (string.IsNullOrEmpty(this.addScientificLevel.Text) == false)
		{
			scientificLevel = int.Parse(this.addScientificLevel.Text);
		}
		else
		{
			scientificLevel = -1;
		}

		if (string.IsNullOrEmpty(this.addTypeOfBook.Text) == false)
		{
			typeOfBook = this.addTypeOfBook.Text;
		}
		else
		{
			typeOfBook = "";
		}


		//Add Children Book Inputs


		if (string.IsNullOrEmpty(this.addAgeGroup.Text) == false)
		{
			ageGroup = int.Parse(this.addAgeGroup.Text);
		}
		else
		{
			ageGroup = -1;
		}

		if (string.IsNullOrEmpty(this.addLearningLevel.Text) == false)
		{
			learningLevel = int.Parse(this.addLearningLevel.Text);
		}
		else
		{
			learningLevel = -1;
		}

		if (string.IsNullOrEmpty(this.addMessage.Text) == false)
		{
			message = this.addMessage.Text;
		}
		else
		{
			message= "";
		}


		//Inputs for mystery book



		if (string.IsNullOrEmpty(this.addSuspenseLevel.Text) == false)
		{
			suspenseLevel = int.Parse(this.addSuspenseLevel.Text);
		}
		else
		{
			suspenseLevel = -1;
		}


		if (string.IsNullOrEmpty(this.addLiteratureType.Text) == false)
		{
			literatureType= this.addLiteratureType.Text;
		}
		else
		{
			literatureType = "";
		}



		//Inputs for Romance
		if (string.IsNullOrEmpty(this.addTone.Text) == false)
		{
			tone = this.addTone.Text;
		}
		else
		{
			tone = "";
		}

		if (string.IsNullOrEmpty(this.addSetting.Text) == false)
		{
			setting= this.addSetting.Text;
		}
		else
		{
			setting = "";
		}


		//Validate input values

		// Check if a name was entered.
		if (string.IsNullOrEmpty(authorFirstName))
		{
			DisplayAlert("Error", "Author first name is empty. Please try again.", "Ok");
			return;
		}

		if (string.IsNullOrEmpty(authorLastName))
		{
			DisplayAlert("Error", "Author last name is empty. Please try again.", "Ok");
			return;
		}
		if (string.IsNullOrEmpty(title))
		{
			DisplayAlert("Error", "Book title is empty. Please try again.", "Ok");
			return;
		}
		if (string.IsNullOrEmpty(isbn))
		{
			DisplayAlert("Error", "Book ISBN is empty. Please try again.", "Ok");
			return;
		}
		if (!isCheckedOut)
		{
			DisplayAlert("Error", "Book status is empty. Please try again.", "Ok");
			return;
		}

		Science science = new Science(isbn, title, authorFirstName, authorLastName, isCheckedOut, checkOutDate, returnDate, subject, scientificLevel, typeOfBook);
		Children children = new Children(isbn, title, authorFirstName, authorLastName, isCheckedOut, checkOutDate, returnDate, ageGroup, learningLevel, message);		// Add to database
		Mystery mystery = new Mystery(isbn, title, authorFirstName, authorLastName, isCheckedOut, checkOutDate, returnDate, suspenseLevel, literatureType);     // Add to database
		Romance romance = new Romance(isbn, title, authorFirstName, authorLastName, isCheckedOut, checkOutDate, returnDate, tone, setting);
		
		
		//Add to database
		this.Database.Add(science);
		this.Database.Add(children);
		this.Database.Add(mystery);
		this.Database.Add(romance);

		// Add to existing list
		this.AllScienceBooks.Add(science);
		this.AllChildrenBooks.Add(children);
		this.AllMysteryBooks.Add(mystery);
		this.AllRomanceBooks.Add(romance);


		// Tell user employee was added
		this.DisplayAlert("Success!", "Book was added.", "OK");

	}

}

