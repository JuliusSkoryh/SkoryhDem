using Dem.Exceptions.NotFoundExceptions;
using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.ViewModels;
using System.Windows;

namespace Dem.Commands
{
    public class EditEmployeeCommand : CommandBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly EditEmployeeViewModel _editEmployeeViewModel;

        public EditEmployeeCommand(IEmployeeService employeeService, EditEmployeeViewModel editEmployeeViewModel)
        {
            _employeeService = employeeService;
            _editEmployeeViewModel = editEmployeeViewModel;
        }

        public override void Execute(object parameter)
        {
            var employee = _employeeService.Get(_editEmployeeViewModel.Id);

            if (employee == null)
            {
                throw new EmployeeNotFoundException();
            }

            employee.FullName = _editEmployeeViewModel.FullName;
            employee.DateOfBirth = _editEmployeeViewModel.DateOfBirth;
            employee.HaveFamily = _editEmployeeViewModel.HaveFamily;
            employee.Email = _editEmployeeViewModel.Email;
            employee.Password = _editEmployeeViewModel.Password;
            employee.EmployeeStatus = _editEmployeeViewModel.SelectedEmployeeStatus;
            employee.JobTitle = _editEmployeeViewModel.JobTitle;
            employee.HealhStatus = _editEmployeeViewModel.SelectedHealhStatus;

            try
            {
                _employeeService.Update(employee);
                
                MessageBox.Show("Работник успешно обновлён", "Success");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
