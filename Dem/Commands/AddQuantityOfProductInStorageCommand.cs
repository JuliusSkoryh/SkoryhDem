using Dem.Exceptions.InvalidExceptions;
using Dem.Exceptions.NotFoundExceptions;
using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.Views.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dem.Commands
{
    public class AddQuantityOfProductInStorageCommand : AsyncCommandBase
    {
        private readonly IProductService _productService;
        private readonly Guid _productId;

        public AddQuantityOfProductInStorageCommand(IProductService productService, Guid productId)
        {
            _productService = productService;
            _productId = productId;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            var product = _productService.GetAsync(_productId);

            if (product == null)
            {
                throw new ProductNotFoundException();
            }

            var dialog = new Window1();
            if (dialog.ShowDialog() == true && dialog.Quantity.HasValue)
            {
                var count = dialog.Quantity.Value;

                if (count < 0)
                {
                    MessageBox.Show("Неверно введено количество продукта", "Error");
                    throw new InvalidProductException();
                }

                product.QuantityInStorage = count;
                _productService.UpdateAsync(product);
            }            
        }
    }
}
