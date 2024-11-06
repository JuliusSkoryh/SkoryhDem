using Dem.Commands;
using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services;
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

        private ObservableCollection<Material>? _materials;
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

        public ObservableCollection<Material>? Materials
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

        public ProductViewModel(Product product, NavigationService<ProductEditViewModel> productEditNavigationService)
        {
            _product = product;

            Initialize();

            // DI id навигация с параметром, асинхронная фабрика создания 

            EditProductCommand = new NavigateCommand<ProductEditViewModel>(productEditNavigationService, _product.Id);
        }

        private void Initialize()
        {

            _materials = new ObservableCollection<Material>(_product.Materials);

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
