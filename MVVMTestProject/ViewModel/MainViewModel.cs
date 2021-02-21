using MVVMTestProject.Commands;
using MVVMTestProject.Repositories;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MVVMTestProject.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<EmployeeViewModel> _employees;
        private ObservableCollection<TeamViewModel> _teams;
        private EmployeeViewModel _selectedEmployee;

        #endregion Fields

        #region Properties

        public ObservableCollection<EmployeeViewModel> Employees
        {
            get { return _employees; }
            set
            {
                if (_employees == value)
                    return;
                _employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public ObservableCollection<TeamViewModel> Teams
        {
            get { return _teams; }
            set
            {
                if (_teams == value)
                    return;
                _teams = value;
                OnPropertyChanged("Teams");
            }
        }

        public EmployeeViewModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                if (_selectedEmployee == value)
                    return;
                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
                OnPropertyChanged("IsEmployeeSelected");
            }
        }

        public bool IsEmployeeSelected
        {
            get { return SelectedEmployee != null; }
        }

        #endregion Properties

        #region Commands

        public ICommand AddNewEmployeeCommand { get; set; }
        public ICommand RemoveEmployeeCommand { get; set; }

        #endregion Commands

        #region Constructor

        public MainViewModel()
        {
            var repository = new EmployeeRepository();
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

        #endregion Constructor

        #region Methods

        public void AddNewEmployee()
        {
            EmployeeViewModel employee = new EmployeeViewModel();
            Employees.Add(employee);
            SelectedEmployee = employee;
        }

        #endregion Methods
    }
}