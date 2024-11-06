using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dem.Commands
{
    public class SaveProductCommandForEdit : AsyncCommandBase
    {
        private IProductService _productService;
        private ProductEditViewModel _productEditViewModel;

        public SaveProductCommandForEdit(IProductService productService, ProductEditViewModel productEditViewModel)
        {
            _productService = productService;
            _productEditViewModel = productEditViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {

            try
            {
                var product = _productService.GetAsync(_productEditViewModel.Id);

                if (product != null)
                {
                    product.Type = _productEditViewModel.Type;
                    product.Name = _productEditViewModel.Name;
                    product.Article = _productEditViewModel.Article;
                    product.Image = _productEditViewModel.Image;
                    product.StandartNumber = _productEditViewModel.StandartNumber;
                    product.Cost = _productEditViewModel.Cost;
                    product.Materials = _productEditViewModel.MaterialsSelected;

                    _productService.UpdateAsync(product);
                    MessageBox.Show("Продукт успешно изменён", "Success");
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
