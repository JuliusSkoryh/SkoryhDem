using Dem.Commands;
using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices.DbServiceInterfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Dem.ViewModels
{
    public class ProductListViewModel : ViewModelBase
    {
        private readonly IProductService _productService;

        public NavigationBarViewModel NavigationBarViewModel { get; set; }

        


        private ObservableCollection<ProductViewModel> _productViewModels;
        public ObservableCollection<ProductViewModel> ProductViewModels => _productViewModels;

        public ICommand AddProductNavigateCommand { get; set; }

        private ProductListViewModel(NavigationBarViewModel navigationBarViewModel, IProductService productService, NavigationService<AddProductViewModel> navigationService)
        {
            NavigationBarViewModel = navigationBarViewModel;
            _productService = productService;

            AddProductNavigateCommand = new NavigateCommand<AddProductViewModel>(navigationService);

            _productViewModels = new ObservableCollection<ProductViewModel>();
        }

        public static ProductListViewModel CreateAsync(NavigationBarViewModel navigationBarViewModel, IProductService productService,
            NavigationService<AddProductViewModel> addProductNavigationService, NavigationService<ProductEditViewModel> productEditNavigationService)
        {
            var viewModel = new ProductListViewModel(navigationBarViewModel, productService, addProductNavigationService);
            viewModel.InitializeAsync(productEditNavigationService);
            return viewModel;
        }
        private void InitializeAsync(NavigationService<ProductEditViewModel> productEditNavigationService)
        {
            LoadProductsAsync(productEditNavigationService);
        }
        private void LoadProductsAsync(NavigationService<ProductEditViewModel> productEditNavigationService)
        {
            ICollection<Product>? products = _productService.GetAllWithDetailsAsync();
            foreach (var product in products)
            {
                _productViewModels.Add(new ProductViewModel(product, productEditNavigationService));
            }
        }
    }
}
