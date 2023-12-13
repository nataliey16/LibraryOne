using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOne.BookClass
{
    public class Mystery : Book
    {
		// mystery books start with 1
		//Fields
		private int suspenseLevel; //low, medium, high
		private string literatureType; // fiction or non - fiction

		//Properties

		public int SuspenseLevel
		{
			get { return suspenseLevel; }
			set { suspenseLevel = value; }
		}
		public string LiteratureType
		{
			get { return literatureType; }
			set { literatureType = value; }
		}


		//Constructor
		public Mystery(string isbn, string title, string authorFirstName, string authorLastName, bool isCheckedOut, string checkOutDate, string returnDate, int suspenseLevel, string literatureType) : base(isbn, title, authorFirstName, authorLastName, isCheckedOut, checkOutDate, returnDate)
		{
			this.SuspenseLevel = suspenseLevel;
			this.LiteratureType = literatureType;

		}

		//Methods

		public override string FormatForFile()
		{
			string formatMysteryBookInfo = $"{base.FormatForFile()},{suspenseLevel},{literatureType}";
			return formatMysteryBookInfo;

		}

		public override string ToString()
		{

            return $"ISBN: {Isbn} Title: {Title} Author: {AuthorFirstName}, {AuthorLastName}";
        }
	}
}
