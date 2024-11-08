using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dem.Commands
{
    public class DeleteEmployeeCommand : AsyncCommandBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly EditEmployeeViewModel _editEmployeeViewModel;
        private readonly INavigationService<EmploeeListViewModel> _navigationService;

        public DeleteEmployeeCommand(IEmployeeService employeeService, EditEmployeeViewModel editEmployeeViewModel, INavigationService<EmploeeListViewModel> navigationService)
        {
            _employeeService = employeeService;
            _editEmployeeViewModel = editEmployeeViewModel;
            _navigationService = navigationService;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            var result = MessageBox.Show("Вы уверены, что хотите удалить этого работника?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
            {
                return;
            }


            try
            {
                _employeeService.DeleteAsync(_editEmployeeViewModel.Id);
                MessageBox.Show("Работник успешно удален", "Success");
                _navigationService.Navigate(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
