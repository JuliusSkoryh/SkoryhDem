using Dem.Commands;
using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.Services;
using System.Windows.Input;
using Dem.Models.Enums;
using System.Collections.ObjectModel;
using Dem.Services.DbServices;
using Dem.Models.Entities;
using System.Windows;

namespace Dem.ViewModels
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        private readonly IEmployeeService _employeeService;

        public string FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public bool HaveFamily { get; set; }
        public HealhStatus SelectedHealhStatus { get; set; }
        public ObservableCollection<HealhStatus> HealhStatuses { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EmployeeStatus SelectedEmployeeStatus { get; set; }
        public ObservableCollection<EmployeeStatus> EmployeeStatuses { get; set; }


        public ICommand AddPartnerCommand { get; }
        public ICommand CancelWindowCommand { get; }

        private AddEmployeeViewModel(IEmployeeService employeeService, INavigationService<EmploeeListViewModel> navigationService)
        {
            _employeeService = employeeService;

            AddPartnerCommand = new AddEmployeeCommand(_employeeService, navigationService, this);
            CancelWindowCommand = new NavigateCommand<EmploeeListViewModel>(navigationService);
        }

        private void InitializeAsync()
        {
            try
            {
                SelectedHealhStatus = HealhStatus.good;
                HealhStatuses = new ObservableCollection<HealhStatus>((HealhStatus[])Enum.GetValues(typeof(HealhStatus)));

                SelectedEmployeeStatus = EmployeeStatus.common;
                EmployeeStatuses = new ObservableCollection<EmployeeStatus>((EmployeeStatus[])Enum.GetValues(typeof(EmployeeStatus)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public static AddEmployeeViewModel CreateAsync(IEmployeeService employeeService, INavigationService<EmploeeListViewModel> navigationService)
        {
            var viewModel = new AddEmployeeViewModel(employeeService, navigationService);
            viewModel.InitializeAsync();
            return viewModel;
        }
    }
}
