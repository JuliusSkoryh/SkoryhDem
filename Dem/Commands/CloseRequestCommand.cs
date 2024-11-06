using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services.DbServices;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dem.Commands
{
    public class CloseRequestCommand : AsyncCommandBase
    {
        private IRequestService _requestService;
        private MakeRequestViewModel _makeRequestViewModel;
        private NavigateCommand<RequestListViewModel> _navigateCommand;

        public CloseRequestCommand(IRequestService requestService, MakeRequestViewModel makeRequestViewModel, NavigateCommand<RequestListViewModel> navigateCommand)
        {
            _requestService = requestService;
            _makeRequestViewModel = makeRequestViewModel;
            _navigateCommand = navigateCommand;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            DateOnly dateOfClose = DateOnly.FromDateTime(DateTime.Now);

            var request = new Request(_makeRequestViewModel.Id, _makeRequestViewModel.QuantityOfProduct, _makeRequestViewModel.Price, _makeRequestViewModel.DateOfCreation,
                _makeRequestViewModel.IsPrepayment, _makeRequestViewModel.SelectedProduct.Id, _makeRequestViewModel.SelectedPartner.Id, dateOfClose);

            try
            {
                _requestService.UpdateAsync(request);
                MessageBox.Show("Продукт успешно изменён", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }    
}
