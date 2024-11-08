using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.Services;
using Dem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dem.Models.Entities;
using Dem.Services.DbServices;
using System.Windows;

namespace Dem.Commands
{
    public class AddEmployeeCommand : AsyncCommandBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly INavigationService<EmploeeListViewModel> _navigationService;
        private readonly AddEmployeeViewModel _viewModel;

        public AddEmployeeCommand(IEmployeeService employeeService, INavigationService<EmploeeListViewModel> navigationService, AddEmployeeViewModel viewModel)
        {
            _employeeService = employeeService;
            _navigationService = navigationService;
            _viewModel = viewModel;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            var employee = new Employee(Guid.NewGuid(), _viewModel.FullName, _viewModel.DateOfBirth, _viewModel.HaveFamily, _viewModel.SelectedHealhStatus, _viewModel.JobTitle, _viewModel.Email, _viewModel.Password, _viewModel.SelectedEmployeeStatus);

            try
            {
                _employeeService.AddAsync(employee);
                MessageBox.Show("Работник успешно добавлен в базу данных", "Success");
                _navigationService.Navigate(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
