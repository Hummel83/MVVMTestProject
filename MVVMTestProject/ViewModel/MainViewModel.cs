using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MVVMTestProject.Commands;
using MVVMTestProject.Repositories;

namespace MVVMTestProject.ViewModel
{
	public class MainViewModel : BaseViewModel
	{

		#region Fields

		private ObservableCollection<EmployeeViewModel> employees;
		private ObservableCollection<TeamViewModel> teams;
		private EmployeeViewModel selectedEmployee;

		#endregion



		#region Properties

		public ObservableCollection<EmployeeViewModel> Employees
		{
			get { return employees; }
			set
			{
				if (employees == value)
					return;
				employees = value;
				OnPropertyChanged("Employees");
			}
		}

		public ObservableCollection<TeamViewModel> Teams
		{
			get { return teams; }
			set
			{
				if (teams == value)
					return;
				teams = value;
				OnPropertyChanged("Teams");
			}
		}

		public EmployeeViewModel SelectedEmployee
		{
			get { return selectedEmployee; }
			set
			{
				if (selectedEmployee == value)
					return;
				selectedEmployee = value;
				OnPropertyChanged("SelectedEmployee");
				OnPropertyChanged("IsEmployeeSelected");
			}
		}

		public bool IsEmployeeSelected
		{
			get { return SelectedEmployee != null; }
		}
		#endregion



		#region Commands

		public ICommand AddNewEmployeeCommand { get; set; }
		public ICommand RemoveEmployeeCommand { get; set; }

		#endregion



		#region Constructor

		public MainViewModel()
		{
			EmployeeRepository repository = new EmployeeRepository();
			var employees = repository.GetEmployees();
			var teams = employees.Select(m => m.Team).Distinct();
			var teamViewModelsByName = teams.Select(m => new TeamViewModel() { Name = m.Name }).ToDictionary(m => m.Name);
			var employeeViewModels = employees.Select(m => new EmployeeViewModel()
			{
				FirstName = m.FirstName,
				LastName = m.LastName,
				Team = teamViewModelsByName[m.Team.Name]
			});

			Employees = new ObservableCollection<EmployeeViewModel>(employeeViewModels);
			Teams = new ObservableCollection<TeamViewModel>(teamViewModelsByName.Values);

			AddNewEmployeeCommand = new RelayCommand(parameter => AddNewEmployee());
			RemoveEmployeeCommand = new RelayCommand(parameter => Employees.Remove((EmployeeViewModel)parameter), parameter => parameter != null);
		}

		#endregion



		#region Methods

		public void AddNewEmployee()
		{
			EmployeeViewModel employee = new EmployeeViewModel();
			Employees.Add(employee);
			SelectedEmployee = employee;
		}
		#endregion

	}
}
