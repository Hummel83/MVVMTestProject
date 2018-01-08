using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMTestProject.ViewModel
{
	public class EmployeeViewModel : BaseViewModel
	{
		private string firstName;
		private string lastName;
		private TeamViewModel team;

		public string FirstName
		{
			get { return firstName; }
			set
			{
				if (value != firstName)
				{
					firstName = value;
					OnPropertyChanged("FirstName");
					OnPropertyChanged("FullName");
				}
			}
		}

		public string LastName
		{
			get { return lastName; }
			set
			{
				if (value != lastName)
				{
					lastName = value;
					OnPropertyChanged("LastName");
					OnPropertyChanged("FullName");
				}
			}
		}

		public string FullName
		{
			get { return string.Format("{0} {1}", FirstName, LastName); }
		}

		public TeamViewModel Team
		{
			get { return team; }
			set
			{
				if (value != team)
				{
					team = value;
					OnPropertyChanged("Team");
				}
			}
		}
	}
}
