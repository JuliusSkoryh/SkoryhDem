using Dem.Commands;
using Dem.Models.Entities;
using Dem.Models.Enums;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices;
using Dem.Services.DbServices.DbServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Dem.ViewModels
{
    public class EditEmployeeViewModel : ViewModelBase
    {
        private readonly IEmployeeService _employeeService;
        private Employee _employee;

        public Guid Id => _employee.Id;
        public string FullName
        {
            get => _employee.FullName;
            set
            {
                _employee.FullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }
        public DateOnly DateOfBirth
        {
            get => _employee.DateOfBirth;
            set
            {
                _employee.DateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }
        public bool HaveFamily
        {
            get => HaveFamily;
            set
            {
                _employee.HaveFamily = value;
                OnPropertyChanged(nameof(HaveFamily));
            }
        }
        public HealhStatus SelectedHealhStatus
        {
            get => _employee.HealhStatus;
            set
            {
                _employee.HealhStatus = value;
                OnPropertyChanged(nameof(SelectedHealhStatus));
            }
        }
        public ObservableCollection<HealhStatus> HealhStatuses { get; set; }

        public string JobTitle
        {
            get => _employee.JobTitle;
            set
            {
                _employee.JobTitle = value;
                OnPropertyChanged(nameof(JobTitle));
            }
        }
        public string Email
        {
            get => _employee.Email;
            set
            {
                _employee.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Password
        {
            get => _employee.Password;
            set
            {
                _employee.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public EmployeeStatus SelectedEmployeeStatus
        {
            get => _employee.EmployeeStatus;
            set
            {
                _employee.EmployeeStatus = value;
                OnPropertyChanged(nameof(SelectedEmployeeStatus));
            }
        }
        public ObservableCollection<EmployeeStatus> EmployeeStatuses { get; set; }

        public ICommand EditEmployeeCommand { get; }
        public ICommand CancelWindowCommand { get; }
        public ICommand DeleteCommand { get; }

        private EditEmployeeViewModel(IEmployeeService employeeService, INavigationService<EmploeeListViewModel> emploeeListNavigationService)
        {
            _employeeService = employeeService;

            EditEmployeeCommand = new EditEmployeeCommand(_employeeService, this);
            CancelWindowCommand = new NavigateCommand<EmploeeListViewModel>(emploeeListNavigationService);
            DeleteCommand = new DeleteEmployeeCommand(_employeeService, this, emploeeListNavigationService);
        }

        public static EditEmployeeViewModel CreateAsync(Guid id, IEmployeeService employeeService, INavigationService<EmploeeListViewModel> navigationService)
        {
            var viewModel = new EditEmployeeViewModel(employeeService, navigationService);
            viewModel.InitializeAsync(id);
            return viewModel;
        }

        private void InitializeAsync(Guid id)
        {
            try
            {
                _employee = _employeeService.GetAsync(id);

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
    }
}
