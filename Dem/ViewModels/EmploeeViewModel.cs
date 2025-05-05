using Dem.Models.Entities;
using Dem.Models.Enums;
using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dem.Commands;

namespace Dem.ViewModels
{ 
    public class EmploeeViewModel : ViewModelBase
    {
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
            get => _employee.HaveFamily;
            set
            {
                _employee.HaveFamily = value;
                OnPropertyChanged(nameof(HaveFamily));
            }
        }
        public HealhStatus HealhStatus
        {
            get => _employee.HealhStatus;
            set
            {
                _employee.HealhStatus = value;
                OnPropertyChanged(nameof(HealhStatus));
            }
        }
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

        public ICommand EditEmploeeNavCommand { get; }


        public EmploeeViewModel(Employee employee, INavigationService<EditEmployeeViewModel> editEmployeeNavigationService)
        {
            _employee = employee;
            EditEmploeeNavCommand = new NavigateCommand<EditEmployeeViewModel>(editEmployeeNavigationService, Id);
        }
    }
}
