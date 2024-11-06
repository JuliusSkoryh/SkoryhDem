using Dem.Commands;
using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dem.ViewModels
{
    public class AddProductViewModel : ViewModelBase
    {
        private readonly IProductService _productService;
        private readonly IMaterialService _materialService;

        public string Type { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public byte[]? Image { get; set; }
        public int StandartNumber { get; set; }
        public decimal Cost { get; set; }
        public ObservableCollection<Material> Materials { get; private set; }
        public ObservableCollection<Material> MaterialsSelected { get; set; }


        public ICommand SaveProductCommand { get; }
        public ICommand CancelWindowCommand { get; }

        private AddProductViewModel(IProductService productService, IMaterialService materialService, INavigationService<ProductListViewModel> navigationProductListService)
        {
            _productService = productService;
            _materialService = materialService;


            SaveProductCommand = new SaveProductCommand(productService, this);
            CancelWindowCommand = new NavigateCommand<ProductListViewModel>(navigationProductListService);
        }

        private void InitializeAsync()
        {
            Materials = new ObservableCollection<Material>(_materialService.GetAllAsync());
            MaterialsSelected = new ObservableCollection<Material>();

            
        }

        public static AddProductViewModel CreateAsync(IProductService productService, IMaterialService materialService, NavigationService<ProductListViewModel> navigationProductListService)
        {
            var viewModel = new AddProductViewModel(productService ,materialService, navigationProductListService);
            viewModel.InitializeAsync();
            return viewModel;
        }

        public void AddSelectedMaterial(Material material)
        {
            if (!MaterialsSelected.Contains(material))
            {
                MaterialsSelected.Add(material);
            }
        }
    }
}
