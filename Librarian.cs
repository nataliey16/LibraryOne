using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOne
{
	public class Librarian : User
	{

		//Constructor
		public Librarian(int id, string firstName, string lastName, string email) : base(id, firstName, lastName, email)
		{
		}
	}
}
