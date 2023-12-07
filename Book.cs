using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOne
{
    public abstract class Book
    {

		//Fields
		private int isbn;
		private string title;
		private string authorFirstName;
		private string authorLastName;
		private bool isCheckedOut;
		private string checkOutDate;
		private string returnDate;
		//Added this
		//private string category;

		//Properties
		public int Isbn
		{
			get { return isbn; }
			set { isbn = value; }
		}

		public string Title
		{
			get { return title; }
			set { title = value; }
		}

		public string AuthorFirstName
		{
			get { return authorFirstName; }
			set { authorFirstName = value; }
		}

		public string AuthorLastName
		{
			get { return authorLastName; }
			set { authorLastName = value; }
		}

		public bool IsCheckedOut
		{
			get { return isCheckedOut; }
			set { isCheckedOut = value; }
		}

		public string CheckOutDate
		{
			get { return checkOutDate; }
			set { checkOutDate = value; }
		}

		public string ReturnDate
		{
			get { return returnDate; }
			set { returnDate = value; }
		}

		//public string Category
		//{
		//	get { return category;}
		//	set { category = value; }	
		//}


		//Constructor
		public Book(int isbn, string title, string authorFirstName, string authorLastName, bool isCheckedOut, string checkOutDate, string returnDate)
		{
			this.Isbn = isbn;
			this.Title = title;
			this.AuthorFirstName = authorFirstName;
			this.AuthorLastName = authorLastName;
			this.IsCheckedOut = isCheckedOut;
			this.CheckOutDate = checkOutDate;
			this.ReturnDate = returnDate;
			//this.category = category;
		}


		//Methods

		//Checkout

		//Add

		//Search

		public virtual string FormatForFile()
		{
			string formatBook = $"{isbn}, {title}, {authorFirstName}, {authorLastName}, {checkOutDate}, {returnDate}";

			return formatBook;
		}


		public override string ToString() // Method to print book information 
		{
			string bookInformation =
				$"\n ISBN: {isbn} " +
				$"\n Title: {title}" +
				$"\n Author: {authorFirstName}, {authorLastName}" +
				$"\n Checkout Date: {checkOutDate}" +
				$"\n Return Date: {returnDate}";

			return bookInformation;
		}
	}
}
