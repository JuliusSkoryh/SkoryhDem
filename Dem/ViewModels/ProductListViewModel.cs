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

        private ProductListViewModel(NavigationBarViewModel navigationBarViewModel, IProductService productService, INavigationService<AddProductViewModel> navigationService)
        {
            NavigationBarViewModel = navigationBarViewModel;
            _productService = productService;

            AddProductNavigateCommand = new NavigateCommand<AddProductViewModel>(navigationService);

            _productViewModels = new ObservableCollection<ProductViewModel>();
        }

        public static ProductListViewModel Create(NavigationBarViewModel navigationBarViewModel, IProductService productService, IMaterialService materialService,
            INavigationService<AddProductViewModel> addProductNavigationService, INavigationService<ProductEditViewModel> productEditNavigationService,
            INavigationService<EditMaterialViewModel> editMaterialNavigationService)
        {
            var viewModel = new ProductListViewModel(navigationBarViewModel, productService, addProductNavigationService);
            viewModel.Initialize(productEditNavigationService, materialService, editMaterialNavigationService);
            return viewModel;
        }
        private void Initialize(INavigationService<ProductEditViewModel> productEditNavigationService, IMaterialService materialService,
            INavigationService<EditMaterialViewModel> editMaterialNavigationService)
        {
            LoadProducts(productEditNavigationService, materialService, editMaterialNavigationService);
        }
        private void LoadProducts(INavigationService<ProductEditViewModel> productEditNavigationService, IMaterialService materialService,
            INavigationService<EditMaterialViewModel> editMaterialNavigationService)
        {
            ICollection<Product>? products = _productService.GetAllWithDetails();
            foreach (var product in products)
            {
                _productViewModels.Add(new ProductViewModel(product, productEditNavigationService, _productService, materialService, editMaterialNavigationService));
            }
        }
    }
}
