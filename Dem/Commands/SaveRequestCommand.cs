using Dem.Exceptions.InvalidExceptions;
using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services;
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
    public class SaveRequestCommand : AsyncCommandBase
    {
        private readonly IRequestService _requestService;
        private readonly IProductService _productService;
        private MakeRequestViewModel _makeRequestViewModel;
        private readonly INavigationService<RequestListViewModel> _navigateCommand;

        public SaveRequestCommand(IRequestService requestService, IProductService productService, MakeRequestViewModel makeRequestViewModel, INavigationService<RequestListViewModel> navigateCommand)
        {
            _requestService = requestService;
            _productService = productService;
            _makeRequestViewModel = makeRequestViewModel;
            _navigateCommand = navigateCommand;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                decimal price = _makeRequestViewModel.SelectedProduct.Cost * _makeRequestViewModel.QuantityOfProduct;
                DateOnly dateOfCreation = DateOnly.FromDateTime(DateTime.Now);

                if (_makeRequestViewModel.SelectedProduct.QuantityInStorage < _makeRequestViewModel.QuantityOfProduct)
                {
                    throw new InvalidRequestException("нехватает продукции на складе");
                }

                var request = new Request(_makeRequestViewModel.Id, _makeRequestViewModel.QuantityOfProduct, price, dateOfCreation,
                    _makeRequestViewModel.IsPrepayment, _makeRequestViewModel.SelectedProduct.Id, _makeRequestViewModel.SelectedPartner.Id, null);

                _requestService.AddAsync(request);

                var product = _productService.GetAsync(_makeRequestViewModel.SelectedProduct.Id);
                product.QuantityInStorage -= _makeRequestViewModel.QuantityOfProduct;
                _productService.UpdateAsync(product);

                MessageBox.Show("Заказ успешно создан", "Success");

                _navigateCommand.Navigate(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
