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
    public class DeleteProductCommand : AsyncCommandBase
    {
        private IProductService _productService;
        private ProductEditViewModel _productEditViewModel;
        private readonly INavigationService<ProductListViewModel> _navigationService;

        public DeleteProductCommand(IProductService productService, ProductEditViewModel productEditViewModel, INavigationService<ProductListViewModel> navigationService)
        {
            _productService = productService;
            _productEditViewModel = productEditViewModel;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var result = MessageBox.Show("Вы уверены, что хотите удалить этот продукт?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
            {
                return;
            }


            try
            {
                _productService.DeleteAsync(_productEditViewModel.Id);
                MessageBox.Show("Продукт успешно удален", "Success");
                _navigationService.Navigate(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
