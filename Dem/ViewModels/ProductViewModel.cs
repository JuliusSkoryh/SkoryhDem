using Dem.Commands;
using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices.DbServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Dem.ViewModels
{
    public class ProductViewModel : ViewModelBase
    { 
        // если есть баги - чекай в Init

        private readonly Product _product;

        private ObservableCollection<MaterialViewModel>? _materials;
        private ObservableCollection<Request>? _requests;


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

        public ObservableCollection<MaterialViewModel>? Materials
        {
            get => _materials;
            set
            {
                _materials = value;
                OnPropertyChanged(nameof(Materials));
            }
        }

        public ObservableCollection<Request>? Requests
        {
            get => _requests;
            set
            {
                _requests = value;
                OnPropertyChanged(nameof(Requests));
            }
        }

        public ICommand EditProductCommand { get; }
        public ICommand AddQuantityOfProductInStorageCommand { get; }

        public ProductViewModel(Product product, INavigationService<ProductEditViewModel> productEditNavigationService,
            IProductService productService, IMaterialService materialService, INavigationService<EditMaterialViewModel> editMaterialNavigationService)
        {
            _product = product;

            Initialize(materialService, editMaterialNavigationService);

            // DI id навигация с параметром, асинхронная фабрика создания 

            EditProductCommand = new NavigateCommand<ProductEditViewModel>(productEditNavigationService, _product.Id);
            AddQuantityOfProductInStorageCommand = new AddQuantityOfProductInStorageCommand(productService, _product.Id);
        }

        private void Initialize(IMaterialService materialService, INavigationService<EditMaterialViewModel> editMaterialNavigationService)
        {

            _materials = new ObservableCollection<MaterialViewModel>(_product.Materials.Select(m => new MaterialViewModel(m, materialService, editMaterialNavigationService)));

            if(_requests == null || !_requests.Any())
            {
                _requests = new ObservableCollection<Request>();
            }
            else
            {
                _requests = new ObservableCollection<Request>(_product.Requests);
            }
        }
    }
}
