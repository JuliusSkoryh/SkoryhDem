using Dem.Models.Entities;
using Dem.Primitives;
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
    public class SaveRequestCommand : AsyncCommandBase
    {
        private IRequestService _requestService;
        private MakeRequestViewModel _makeRequestViewModel;

        public SaveRequestCommand(IRequestService requestService, MakeRequestViewModel makeRequestViewModel)
        {
            _requestService = requestService;
            _makeRequestViewModel = makeRequestViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            decimal price = _makeRequestViewModel.SelectedProduct.Cost * _makeRequestViewModel.QuantityOfProduct;
            DateOnly dateOfCreation = DateOnly.FromDateTime(DateTime.Now);

            var request = new Request(_makeRequestViewModel.Id, _makeRequestViewModel.QuantityOfProduct, price, dateOfCreation,
                _makeRequestViewModel.IsPrepayment, _makeRequestViewModel.SelectedProduct.Id, _makeRequestViewModel.SelectedPartner.Id, null);

            try
            {
                _requestService.AddAsync(request);
                MessageBox.Show("Заказ успешно создан", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
