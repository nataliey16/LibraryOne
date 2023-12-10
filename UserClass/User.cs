using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOne.UserClass
{
    public abstract class User
    {

		//Fields
		private int id;
		private string firstName;
		private string lastName;
		private string email;

		//Properties
		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}

		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}
		public string Email
		{
			get { return email; }
			set { email = value; }
		}


		//Constructors

		public User(int id, string firstName, string lastName, string email)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Email = email;
		}

		//Methods

		public virtual string FormatForFile()
		{
			string formatUser = $"{id}, {firstName}, {lastName}, {email}";

			return formatUser;
		}


		public override string ToString() // Method to print book information 
		{
			string userInformation =
				$"\n Id: {id} " +
				$"\n First Name: {firstName}" +
				$"\n Last Name: {lastName}" +
				$"\n Email: {email}";

			return userInformation;
		}

	}
}
