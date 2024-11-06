using Dem.Commands;
using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices.DbServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Dem.ViewModels
{
    public class ProductEditViewModel : ViewModelBase
    {
        private Product _product;
        private readonly IProductService _productService;
        private readonly IMaterialService _materialService;

        public Guid Id { get; }
        public string Type
        {
            get => _product.Type;
            set
            {
                _product.Type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        public string Name
        {
            get => _product.Name;
            set
            {
                _product.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Article
        {
            get => _product.Article;
            set
            {
                _product.Article = value;
                OnPropertyChanged(nameof(Article));
            }
        }
        public byte[]? Image
        {
            get => null;
            set
            {
                _product.Image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public int StandartNumber
        {
            get => _product.StandartNumber;
            set
            {
                _product.StandartNumber = value;
                OnPropertyChanged(nameof(StandartNumber));
            }
        }
        public decimal Cost
        {
            get => _product.Cost;
            set
            {
                _product.Cost = value;
                OnPropertyChanged(nameof(Cost));
            }
        }
        public int QuantityInStorage
        {
            get => _product.QuantityInStorage;
            set
            {
                _product.QuantityInStorage = value;
                OnPropertyChanged(nameof(QuantityInStorage));
            }
        }

        public ObservableCollection<Material?> Materials { get; private set; }

        private ObservableCollection<Material> _materialsSelected;
        public ObservableCollection<Material> MaterialsSelected
        {
            get => _materialsSelected;
            set
            {
                _materialsSelected = value;
                OnPropertyChanged(nameof(MaterialsSelected));
            }
        }


        public ICommand SaveProductCommand { get; }
        public ICommand CancelWindowCommand { get; }
        public ICommand DeleteCommand { get; }        

        private ProductEditViewModel(Guid? id, IProductService productService, IMaterialService materialService, INavigationService<ProductListViewModel> navigationProductListService)
        {
            if (id == null)
            {
                IdIsNull();
                return;
            }
            Id = (Guid)id;

            _productService = productService;
            _materialService = materialService;


            SaveProductCommand = new SaveProductCommandForEdit(productService, this);
            CancelWindowCommand = new NavigateCommand<ProductListViewModel>(navigationProductListService);
            DeleteCommand = new DeleteProductCommand(productService, this, navigationProductListService);
        }
    

        private void InitializeAsync()
        {
            try
            {
                _product = _productService.GetAsync(Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                CancelWindowCommand.Execute(null);
            }
            Materials = new ObservableCollection<Material?>(_materialService.GetAllAsync());
            //MaterialsSelected = _product.Materials.FirstOrDefault();
            MaterialsSelected = new ObservableCollection<Material?>();
        }

        public static ProductEditViewModel CreateAsync(Guid? id, IProductService productService, IMaterialService materialService, NavigationService<ProductListViewModel> navigationProductListService)
        {
            var viewModel = new ProductEditViewModel(id, productService, materialService, navigationProductListService);
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

        private void IdIsNull()
        {
            MessageBox.Show("Что-то явно пошло не так", "Error");
            CancelWindowCommand.Execute(null);
        }
    }
}
