using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices.DbServiceInterfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Dem.Commands;

namespace Dem.ViewModels
{ 
    public class EmploeeListViewModel : ViewModelBase
    {
        private readonly IEmployeeService _employeeService;
        private ObservableCollection<EmploeeViewModel> _employees;
        public NavigationBarViewModel NavigationBarViewModel { get; set; }

        public ObservableCollection<EmploeeViewModel> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public ICommand AddEmploeeNavCommand { get; }

        private EmploeeListViewModel(NavigationBarViewModel navigationBarViewModel, IEmployeeService employeeService, INavigationService<AddEmployeeViewModel> addEmployeeNavigationService)
        {
            NavigationBarViewModel = navigationBarViewModel;
            _employeeService = employeeService;

            AddEmploeeNavCommand = new NavigateCommand<AddEmployeeViewModel>(addEmployeeNavigationService);
        }

        public static EmploeeListViewModel CreateAsync(NavigationBarViewModel navigationBarViewModel, IEmployeeService employeeService,
            NavigationService<AddEmployeeViewModel> addEmployeeNavigationService, NavigationService<EditEmployeeViewModel> editEmployeeNavigationService)
        {
            var viewModel = new EmploeeListViewModel(navigationBarViewModel, employeeService, addEmployeeNavigationService);
            viewModel.InitializeAsync(editEmployeeNavigationService);
            return viewModel;
        }
        private void InitializeAsync(NavigationService<EditEmployeeViewModel> editEmployeeNavigationService)
        {
            _employees = new ObservableCollection<EmploeeViewModel>();

            var employees = _employeeService.GetAll();

            foreach (var employee in employees)
            {
                _employees.Add(new EmploeeViewModel(employee, editEmployeeNavigationService));
            }
        }
    }
}
