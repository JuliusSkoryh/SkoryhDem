using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services;
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
    class SaveProductCommand : AsyncCommandBase
    {
        // исправь эту хуйню
        private IProductService _productService;
        private AddProductViewModel _addProductViewModel;
        private readonly INavigationService<ProductListViewModel> _navigationService;

        public SaveProductCommand(IProductService productService, AddProductViewModel addProductViewModel, INavigationService<ProductListViewModel> navigationService)
        {
            _productService = productService;
            _addProductViewModel = addProductViewModel;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var product = new Product(Guid.NewGuid(), _addProductViewModel.Type, _addProductViewModel.Name, _addProductViewModel.Article,
                _addProductViewModel.Image, _addProductViewModel.StandartNumber, _addProductViewModel.Cost, _addProductViewModel.MaterialsSelected);

            try
            {
                _productService.AddAsync(product);
                MessageBox.Show("Продукт успешно добавлен в базу данных", "Success");
                _navigationService.Navigate(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
