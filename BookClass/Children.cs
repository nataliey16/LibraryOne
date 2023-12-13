using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryOne.BookClass
{
	public class Children : Book
	{

		// childern books start with 0
		//Fields

		private int ageGroup; //preschool (age: 2-5), early readers (ages 6-8), middle grade (ages: 9-12), teens (ages: 13-17)
		private int learningLevel; //beginner, intermediate, advanced
		private string message; // alphabets, being kind, bullying, puberty


		//Properties

		public int AgeGroup
		{
			get { return ageGroup; }
			set { ageGroup = value; }
		}
		public int LearningLevel
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
		public Children(string isbn, string title, string authorFirstName, string authorLastName, bool isCheckedOut, string checkOutDate, string returnDate, int ageGroup, int learningLevel, string message) : base(isbn, title, authorFirstName, authorLastName, isCheckedOut, checkOutDate, returnDate)
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

			return $"ISBN: {Isbn} Title: {Title} Author: {AuthorFirstName}, {AuthorLastName}";
		}











	}



}