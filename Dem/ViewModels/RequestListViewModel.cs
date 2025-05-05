using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Dem.Commands;

namespace Dem.ViewModels
{
    public class RequestListViewModel : ViewModelBase 
    {
        private IRequestService _requestService;
        public NavigationBarViewModel NavigationBarViewModel { get; set; }

        private ObservableCollection<RequestViewModel> _requests;
        public ObservableCollection<RequestViewModel> Requests => _requests;

        public ICommand MakeRequestNavigateCommand { get; set; }


        public RequestListViewModel(NavigationBarViewModel navigationBarViewModel, IRequestService requestService, NavigationService<MakeRequestViewModel> navigationService)
        {
            NavigationBarViewModel = navigationBarViewModel;

            _requestService = requestService;
            MakeRequestNavigateCommand = new NavigateCommand<MakeRequestViewModel>(navigationService);
        }


        public static RequestListViewModel CreateAsync(NavigationBarViewModel navigationBarViewModel, IRequestService requestService,
            NavigationService<MakeRequestViewModel> makeRequestnavigationService, NavigationService<RequestListViewModel> requestListnavigationService)
        {
            var viewModel = new RequestListViewModel(navigationBarViewModel, requestService, makeRequestnavigationService);
            viewModel.InitializeAsync(requestService, requestListnavigationService);
            return viewModel;
        }
        private void InitializeAsync(IRequestService requestService, NavigationService<RequestListViewModel> requestListnavigationService)
        {
            LoadRequestsAsync(requestService, requestListnavigationService);
        }
        private void LoadRequestsAsync(IRequestService requestService, NavigationService<RequestListViewModel> requestListnavigationService)
        {
            _requests = new ObservableCollection<RequestViewModel>();

            var requests = _requestService.GetAllWithDetails();
            foreach (var request in requests)
            {
                _requests.Add(new RequestViewModel(request, requestService, requestListnavigationService));
            }
        }
    }
}
