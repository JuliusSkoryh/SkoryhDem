using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Dem.Commands;

namespace Dem.ViewModels
{ 
    public class LoginViewModel : ViewModelBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly INavigationService<ProductListViewModel> _productListNavigationService;

        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; }

        private LoginViewModel(IEmployeeService employeeService, INavigationService<ProductListViewModel> productListNavigationService)
        {
            _employeeService = employeeService;
            _productListNavigationService = productListNavigationService;

            LoginCommand = new LoginCommand(employeeService, this, productListNavigationService);
        }

        public static LoginViewModel Create(IEmployeeService employeeService, INavigationService<ProductListViewModel> productListNavigationService)
        {
            return new LoginViewModel(employeeService, productListNavigationService);
        }
    }
}
