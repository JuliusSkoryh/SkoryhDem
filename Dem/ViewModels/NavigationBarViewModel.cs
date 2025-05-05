using Dem.Commands;
using Dem.Primitives;
using Dem.Services;
using System.Windows.Input;

namespace Dem.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateProductListCommand { get; }
        public ICommand NavigateRequestListCommand { get; }
        public ICommand NavigatePartnerListCommand { get; }
        public ICommand NavigateEmployeeListCommand { get; }
        public ICommand NavigateMaterialListCommand { get; }



        public NavigationBarViewModel(INavigationService<ProductListViewModel> navigateProductListService, INavigationService<RequestListViewModel> navigateRequestListService,
            INavigationService<PartnerListViewModel> navigatePartnerListService, INavigationService<EmploeeListViewModel> navigateEmployeeListService, INavigationService<MaterialListViewModel> navigateMaterialListService)
        {
            NavigateProductListCommand = new NavigateCommand<ProductListViewModel>(navigateProductListService);
            NavigateRequestListCommand = new NavigateCommand<RequestListViewModel>(navigateRequestListService);
            NavigatePartnerListCommand = new NavigateCommand<PartnerListViewModel>(navigatePartnerListService);
            NavigateEmployeeListCommand = new NavigateCommand<EmploeeListViewModel>(navigateEmployeeListService);
            NavigateMaterialListCommand = new NavigateCommand<MaterialListViewModel>(navigateMaterialListService);

        }
    }
}
