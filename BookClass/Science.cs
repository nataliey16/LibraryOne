using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOne.BookClass
{
    public class Science : Book
    {
		// starts with 3
		//Fields
		private string subject; // e.g., Biology, Chemistry, Physics
		private int scientificLevel; // beginner, intermediate, advanced
		private string typeOfBook; // textbook, journal, report


		//Properties

		public string Subject
		{
			get { return subject; }
			set { subject = value; }
		}

		public int ScientificLevel
		{
			get { return scientificLevel; }
			set { scientificLevel = value; }

		}
		public string TypeOfBook
		{
			get { return typeOfBook; }
			set { typeOfBook = value; }
		}


		//Constructor
		public Science(string isbn, string title, string authorFirstName, string authorLastName, bool isCheckedOut, string checkOutDate, string returnDate, string subject, int scientificLevel, string typeOfBook) : base(isbn, title, authorFirstName, authorLastName, isCheckedOut, checkOutDate, returnDate)
		{
			this.Subject = subject;
			this.ScientificLevel = scientificLevel;
			this.TypeOfBook = typeOfBook;
		}


		//Methods

		public override string FormatForFile()
		{
			string formatScienceBookInfo = $"{base.FormatForFile()},{subject},{scientificLevel}, {typeOfBook}";
			return formatScienceBookInfo;

		}

		public override string ToString()
		{

            return $"ISBN: {Isbn} Title: {Title} Author: {AuthorFirstName}, {AuthorLastName}";
        }

	}
}
