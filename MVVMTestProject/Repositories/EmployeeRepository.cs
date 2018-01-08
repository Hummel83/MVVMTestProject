using System.Collections.Generic;
using MVVMTestProject.Models;

namespace MVVMTestProject.Repositories
{
	public class EmployeeRepository
	{

		public IEnumerable<Employee> GetEmployees()
		{
			Team team1 = new Team() { Name = "Team 1" };
			Team team2 = new Team() { Name = "Team 3" };
			Team team3 = new Team() { Name = "Team 4" };
			return new List<Employee>()
			{
				new Employee() { FirstName = "Gerd", LastName = "Brunner", Team = team1 },
				new Employee() { FirstName = "Joseph", LastName = "Pörstel", Team = team1 },
				new Employee() { FirstName = "Franziska", LastName = "Friedemann", Team = team1 },
				new Employee() { FirstName = "Konstanze", LastName = "Ganzheim", Team = team1 },
				new Employee() { FirstName = "Gertrud", LastName = "Schmied", Team = team2 },
				new Employee() { FirstName = "Ferdinand", LastName = "Töpfer", Team = team2 },
				new Employee() { FirstName = "Sabine", LastName = "Grube", Team = team2 },
				new Employee() { FirstName = "Peter", LastName = "Möller", Team = team2 },
				new Employee() { FirstName = "Claudia", LastName = "Bender", Team = team3 },
				new Employee() { FirstName = "Claire", LastName = "von Burckhardt", Team = team3 },
				new Employee() { FirstName = "Johanna", LastName = "Sägebrecht", Team = team3 },
				new Employee() { FirstName = "Walther", LastName = "Heumann", Team = team3 },
			};
		}

	}
}
