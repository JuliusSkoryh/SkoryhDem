using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Dem.Models.Entities;
using Dem.Commands;
using Dem.Services.DbServices;

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
            NavigationService<MakeRequestViewModel> navigationService, CloseRequestCommand closeRequestCommand)
        {
            var viewModel = new RequestListViewModel(navigationBarViewModel, requestService, navigationService);
            viewModel.InitializeAsync(closeRequestCommand);
            return viewModel;
        }
        private void InitializeAsync(CloseRequestCommand closeRequestCommand)
        {
            LoadRequestsAsync(closeRequestCommand);
        }
        private void LoadRequestsAsync(CloseRequestCommand closeRequestCommand)
        {
            var requests = _requestService.GetAllWithDetailsAsync();
            foreach (var request in requests)
            {
                _requests.Add(new RequestViewModel(request, closeRequestCommand));
            }
        }
    }
}
