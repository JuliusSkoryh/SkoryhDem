using Dem.Commands;
using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dem.Models.Entities;

namespace Dem.ViewModels
{ 
    public class MakeRequestViewModel : ViewModelBase
    {
        private readonly IRequestService _requestService;
        private readonly IProductService _productService;
        private readonly IPartnerService _partnerService;

        public Guid Id { get; }
        public int QuantityOfProduct { get; set; }
        public decimal Price { get; set; }
        public DateOnly DateOfCreation { get; set; }
        public DateOnly? DateOfClosing { get; set; }
        public bool IsPrepayment { get; set; }

        public ObservableCollection<Product> Products { get; private set; }
        public ObservableCollection<Partner> Partners { get; private set; }
        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private Partner _selectedPartner;
        public Partner SelectedPartner
        {
            get => _selectedPartner;
            set
            {
                _selectedPartner = value;
                OnPropertyChanged(nameof(SelectedPartner));
            }
        }


        public ICommand SaveRequestCommand { get; }
        public ICommand CancelWindowCommand { get; }

        private MakeRequestViewModel(IRequestService requestService, IProductService productService, IPartnerService partnerService, INavigationService<RequestListViewModel> navigationProductListService)
        {
            _requestService = requestService;
            _productService = productService;
            _partnerService = partnerService;


            SaveRequestCommand = new SaveRequestCommand(requestService, productService, this, navigationProductListService);
            CancelWindowCommand = new NavigateCommand<RequestListViewModel>(navigationProductListService);

            Id = Guid.NewGuid();
        }

        private void InitializeAsync()
        {
            Products = new ObservableCollection<Product>(_productService.GetAll());
            Partners = new ObservableCollection<Partner>(_partnerService.GetAll());
        }

        public static MakeRequestViewModel CreateAsync(
            IRequestService requestService,
            IProductService productService,
            IPartnerService partnerService,
            NavigationService<RequestListViewModel> navigationRequestListService)
        {
            var viewModel = new MakeRequestViewModel(requestService, productService, partnerService, navigationRequestListService);
            viewModel.InitializeAsync();
            return viewModel;
        }

        
    }
}
