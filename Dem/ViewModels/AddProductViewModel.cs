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
using System.ComponentModel;
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
        public ObservableCollection<MaterialViewModel> Materials { get; private set; }
        public ObservableCollection<Material> MaterialsSelected { get; set; }


        public ICommand SaveProductCommand { get; }
        public ICommand CancelWindowCommand { get; }

        private AddProductViewModel(IProductService productService, IMaterialService materialService, INavigationService<ProductListViewModel> navigationProductListService)
        {
            _productService = productService;
            _materialService = materialService;


            SaveProductCommand = new SaveProductCommand(productService, this, navigationProductListService);
            CancelWindowCommand = new NavigateCommand<ProductListViewModel>(navigationProductListService);
        }

        private void InitializeAsync()
        {
            var materials = _materialService.GetAllAsync();
            Materials = new ObservableCollection<MaterialViewModel>(
                materials.Select(m => new MaterialViewModel(m))
            );
            foreach (var material in Materials)
            {
                material.PropertyChanged += OnMaterialSelectionChanged;
            }
            MaterialsSelected = new ObservableCollection<Material>();
        }

        public static AddProductViewModel CreateAsync(IProductService productService, IMaterialService materialService, NavigationService<ProductListViewModel> navigationProductListService)
        {
            var viewModel = new AddProductViewModel(productService ,materialService, navigationProductListService);
            viewModel.InitializeAsync();
            return viewModel;
        }

        private void OnMaterialSelectionChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MaterialViewModel.IsSelected) && sender is MaterialViewModel material)
            {
                if (material.IsSelected)
                {
                    if (!MaterialsSelected.Contains(material.Material))
                    {
                        MaterialsSelected.Add(material.Material);
                    }
                }
                else
                {
                    if (MaterialsSelected.Contains(material.Material))
                    {
                        MaterialsSelected.Remove(material.Material);
                    }
                }
            }
        }
    }
}
