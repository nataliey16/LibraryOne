using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOne
{
    public class Mystery : Book
    {

		//Fields
		private string suspenseLevel; //low, medium, high
		private string literatureType; // fiction or non - fiction

		//Properties

		public string SuspenseLevel
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
		public Mystery(int isbn, string title, string authorFirstName, string authorLastName, bool isCheckedOut, string checkOutDate, string returnDate, string suspenseLevel, string literatureType) : base(isbn, title, authorFirstName, authorLastName, isCheckedOut, checkOutDate, returnDate)
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

			string displayMysteryBookInfo =
				base.ToString() +
				$"\n Suspense Level: {suspenseLevel}" +
				$"\n Literature Type: {literatureType}";

			return displayMysteryBookInfo;
		}
	}
}
