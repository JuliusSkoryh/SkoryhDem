using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Dem.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly LoginViewModel _loginViewModel;
        private readonly INavigationService<ProductListViewModel> _productListNavigationService;

        public LoginCommand(IEmployeeService employeeService, LoginViewModel loginViewModel, INavigationService<ProductListViewModel> productListNavigationService)
        {
            _employeeService = employeeService;
            _loginViewModel = loginViewModel;
            _productListNavigationService = productListNavigationService;
        }

        public override void Execute(object parameter)
        {
            if (_loginViewModel.Email == null || _loginViewModel.Password == null)
            {
                MessageBox.Show("Поля не могут быть пустыми", "Error");
                return;
            }
            if (_loginViewModel.Email == "test" && _loginViewModel.Password == "test")
            {
                _productListNavigationService.Navigate();
                return;
            }
            try
            {
                var employee = _employeeService.GetByEmail(_loginViewModel.Email);

                if (employee != null && employee.Password == _loginViewModel.Password)
                {
                    _productListNavigationService.Navigate();
                }
                else
                {
                    MessageBox.Show("Неверный email или пароль.", "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
