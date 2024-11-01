using Dem.Commands;
using Dem.Primitives;
using Dem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Dem.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateMakeRequestCommand { get; }
        public ICommand NavigateAddProductCommand { get; }
        public ICommand NavigateProductListCommand { get; }
        public ICommand NavigateRequestListCommand { get; }

        public NavigationBarViewModel(NavigationService<MakeRequestViewModel> navigateMakeRequestCommand, NavigationService<AddProductViewModel> navigateAddProductCommand,
            NavigationService<ProductListViewModel> navigateProductListCommand, NavigationService<RequestListViewModel> navigateRequestListCommand)
        {
            NavigateMakeRequestCommand = new NavigateCommand<MakeRequestViewModel>(navigateMakeRequestCommand);
            NavigateAddProductCommand = new NavigateCommand<AddProductViewModel>(navigateAddProductCommand);
            NavigateProductListCommand = new NavigateCommand<ProductListViewModel>(navigateProductListCommand);
            NavigateRequestListCommand = new NavigateCommand<RequestListViewModel>(navigateRequestListCommand);
        }
    }
}
