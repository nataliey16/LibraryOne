using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOne.UserClass
{
    public class Customer : User
    {

		//Constructor
		public Customer(int id, string firstName, string lastName, string email) : base(id, firstName, lastName, email)
		{
		}
	}
}
