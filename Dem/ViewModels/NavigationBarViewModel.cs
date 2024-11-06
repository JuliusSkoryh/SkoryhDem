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
        public ICommand NavigateProductListCommand { get; }
        public ICommand NavigateRequestListCommand { get; }

        public NavigationBarViewModel(INavigationService<ProductListViewModel> navigateProductListService, INavigationService<RequestListViewModel> navigateRequestListService)
        {
            NavigateProductListCommand = new NavigateCommand<ProductListViewModel>(navigateProductListService);
            NavigateRequestListCommand = new NavigateCommand<RequestListViewModel>(navigateRequestListService);
        }
    }
}
