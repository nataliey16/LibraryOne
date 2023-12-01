using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOne
{
    public class Romance: Book
    {
		//Fields

		private string tone; // romantic, dramatic, humorous
		private string setting; //location/time period


		//Properties
		public string Tone
		{
			get { return tone; }
			set { tone = value; }
		}
		public string Setting
		{
			get { return setting; }
			set { setting = value; }
		}


		//Constructor
		public Romance(int isbn, string title, string authorFirstName, string authorLastName, bool isCheckedOut, string checkOutDate, string returnDate, string tone, string setting) : base(isbn, title, authorFirstName, authorLastName, isCheckedOut, checkOutDate, returnDate)
		{

			this.Tone = tone;
			this.Setting = setting;
		}

		//Methods

		public override string FormatForFile()
		{
			string formatRomanceBookInfo = $"{base.FormatForFile()},{tone},{setting}";
			return formatRomanceBookInfo;

		}

		public override string ToString()
		{

			string displayRomanceBookInfo =
				base.ToString() +
				$"\n Tone: {tone}" +
				$"\n Setting: {setting}";

			return displayRomanceBookInfo;
		}

	}
}
