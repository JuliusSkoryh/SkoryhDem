using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services.DbServices;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.ViewModels;
using System.Windows;

namespace Dem.Commands
{
    public class CloseRequestCommand : AsyncCommandBase
    {
        private readonly IRequestService _requestService;
        private RequestViewModel _requestViewModel;
        private readonly NavigateCommand<RequestListViewModel> _navigateCommand;

        public CloseRequestCommand(IRequestService requestService, RequestViewModel requestViewModel, NavigateCommand<RequestListViewModel> navigateCommand)
        {
            _requestService = requestService;
            _requestViewModel = requestViewModel;
            _navigateCommand = navigateCommand;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            DateOnly dateOfClose = DateOnly.FromDateTime(DateTime.Now);

            try
            {
                var request = _requestService.Get(_requestViewModel.Id);

                if (request != null)
                {
                    if(request.DateOfClosing == null)
                    {
                        request.DateOfClosing = dateOfClose;
                        _requestService.Update(request);

                        _requestViewModel.DateOfClosing = dateOfClose;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }    
}
