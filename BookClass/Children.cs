using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOne.BookClass
{
    public class Children : Book
    {

		//Fields

		private string ageGroup; //preschool (age: 2-5), early readers (ages 6-8), middle grade (ages: 9-12), teens (ages: 13-17)
		private string learningLevel; //beginner, intermediate, advanced
		private string message; // alphabets, being kind, bullying, puberty


		//Properties

		public string AgeGroup
		{
			get { return ageGroup; }
			set { ageGroup = value; }
		}
		public string LearningLevel
		{
			get { return learningLevel; }
			set { learningLevel = value; }
		}

		public string Message
		{
			get { return message; }
			set { message = value; }
		}

		//Constructor
		public Children(int isbn, string title, string authorFirstName, string authorLastName, bool isCheckedOut, string checkOutDate, string returnDate, string ageGroup, string learningLevel, string message) : base(isbn, title, authorFirstName, authorLastName, isCheckedOut, checkOutDate, returnDate)
		{
			this.AgeGroup = ageGroup;
			this.LearningLevel = learningLevel;
			this.Message = message;
		}



		//Methods

		public override string FormatForFile()
		{
			string formatChildrenBookInfo = $"{base.FormatForFile()},{ageGroup},{learningLevel}, {message}";
			return formatChildrenBookInfo;

		}

		public override string ToString()
		{

			string displayChildrenBookInfo =
				base.ToString() +
				$"\n Subject: {ageGroup}" +
				$"\n Scientific Level: {learningLevel} " +
				$"\n Type of Book: {message}";

			return displayChildrenBookInfo;
		}
	}
}
