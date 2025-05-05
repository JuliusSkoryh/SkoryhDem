using Dem.Commands;
using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices.DbServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        public ObservableCollection<MaterialViewModel?> Materials { get; private set; }

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
    

        private void InitializeAsync(INavigationService<EditMaterialViewModel> navigationEditMaterialService)
        {
            try
            {
                _product = _productService.GetWithDetails(Id);
                var allMaterials = _materialService.GetAll();

                Materials = new ObservableCollection<MaterialViewModel?>(
                    allMaterials.Select(m =>
                    {
                        var viewModel = new MaterialViewModel(m, _materialService, navigationEditMaterialService)
                        {
                            IsSelected = _product.Materials.Contains(m)
                        };
                        viewModel.PropertyChanged += OnMaterialSelectionChanged;
                        return viewModel;
                    })
                );

                MaterialsSelected = new ObservableCollection<Material>(_product.Materials);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                CancelWindowCommand.Execute(null);
            }            
        }

        public static ProductEditViewModel CreateAsync(Guid? id, IProductService productService, IMaterialService materialService, 
            NavigationService<ProductListViewModel> navigationProductListService, INavigationService<EditMaterialViewModel> navigationEditMaterialService)
        {
            var viewModel = new ProductEditViewModel(id, productService, materialService, navigationProductListService);
            viewModel.InitializeAsync(navigationEditMaterialService);
            return viewModel;
        }

        public void AddSelectedMaterial(Material material)
        {
            if (!MaterialsSelected.Contains(material))
            {
                MaterialsSelected.Add(material);
            }
            else
            {
                MaterialsSelected.Remove(material);
            }
        }

        private void IdIsNull()
        {
            MessageBox.Show("Что-то явно пошло не так", "Error");
            CancelWindowCommand.Execute(null);
        }

        private void OnMaterialSelectionChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MaterialViewModel.IsSelected) && sender is MaterialViewModel materialVm)
            {
                if (materialVm.IsSelected)
                {
                    if (!MaterialsSelected.Contains(materialVm.Material))
                    {
                        MaterialsSelected.Add(materialVm.Material);
                    }
                }
                else
                {
                    MaterialsSelected.Remove(materialVm.Material);
                }
            }
        }
    }
}
