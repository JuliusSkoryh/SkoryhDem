using Dem.Commands;
using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices;
using Dem.Services.DbServices.DbServiceInterfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Dem.ViewModels
{
    public class PartnerListViewModel : ViewModelBase
    {
        private readonly IPartnerService _partnerService;


        private ObservableCollection<PartnerViewModel> _partnerViewModels;               

        public ObservableCollection<PartnerViewModel> PartnerViewModels => _partnerViewModels;
        public NavigationBarViewModel NavigationBarViewModel { get; set; }

        public ICommand AddPartnerNavCommand { get; }

        private PartnerListViewModel(NavigationBarViewModel navigationBarViewModel, IPartnerService partnerService,
            INavigationService<AddPartnerViewModel> navigationService)
        {
            _partnerService = partnerService;
            NavigationBarViewModel = navigationBarViewModel;

            AddPartnerNavCommand = new NavigateCommand<AddPartnerViewModel>(navigationService);
        }

        public static PartnerListViewModel CreateAsync(NavigationBarViewModel navigationBarViewModel, IPartnerService partnerService, 
            INavigationService<AddPartnerViewModel> navigationService, INavigationService<EditPartnerViewModel> editPartnerNavigationService)
        {
            var viewModel = new PartnerListViewModel(navigationBarViewModel, partnerService, navigationService);
            viewModel.InitializeAsync(partnerService, editPartnerNavigationService);
            return viewModel;
        }

        private void InitializeAsync(IPartnerService partnerService, INavigationService<EditPartnerViewModel> editPartnerNavigationService)
        {
            _partnerViewModels = new ObservableCollection<PartnerViewModel>();

            ICollection<Partner>? partners = _partnerService.GetAllWithDetailsAsync();

            foreach (var partner in partners)
            {
                _partnerViewModels.Add(PartnerViewModel.CreateAsync(_partnerService, editPartnerNavigationService, partner.Id));
            }
        }
    }
}
