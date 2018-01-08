using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMTestProject.Models
{
	public class Employee
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Team Team { get; set; }
	}
}
