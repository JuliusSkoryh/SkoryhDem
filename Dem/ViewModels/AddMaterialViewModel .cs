using Dem.Commands;
using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using Dem.Models.Entities;
using Dem.Services.DbServices;
using System.Collections.ObjectModel;

namespace Dem.ViewModels
{
    public class AddMaterialViewModel : ViewModelBase
    {
        private readonly IMaterialService _materialService;
        private readonly ISupplierService _supplierService;
        private readonly INavigationService<MaterialListViewModel> _navigationService;

        public string Type { get; set; }
        public string Name { get; set; }
        public int QuantityInPackaging { get; set; }
        public string Measurement { get; set; }
        public decimal Cost { get; set; }

        private byte[]? _image;
        public byte[]? Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
                OnPropertyChanged(nameof(ImagePreview));
            }
        }

        public ImageSource? ImagePreview =>
            Image is null ? null : (ImageSource)new ImageSourceConverter().ConvertFrom(Image);

        public Supplier? SelectedSupplier { get; set; }

        public ObservableCollection<Supplier> Suppliers { get; } = new();

        public ICommand SaveProductCommand { get; }
        public ICommand CancelWindowCommand { get; }
        public ICommand LoadImageCommand { get; }

        public AddMaterialViewModel(IMaterialService materialService, INavigationService<MaterialListViewModel> navigationService, ISupplierService supplierService)
        {
            _materialService = materialService;
            _supplierService = supplierService;
            _navigationService = navigationService;


            SaveProductCommand = new SaveMaterialCommand(materialService, this, navigationService);
            CancelWindowCommand = new NavigateCommand<MaterialListViewModel>(_navigationService);
            LoadImageCommand = new LoadImageCommand(() => Image, (img) => Image = img);

            LoadSuppliers();
        }       

        private void LoadSuppliers()
        {
            var suppliers = _supplierService.GetAll();
            Suppliers.Clear();
            Suppliers.Add(new Supplier(Guid.Empty, "Без поставщика", "", ""));
            foreach (var supplier in suppliers)
            {
                Suppliers.Add(supplier);
            }
        }


        public static AddMaterialViewModel Create(IMaterialService materialService, INavigationService<MaterialListViewModel> navigationService, ISupplierService supplierService)
        {
            var viewModel = new AddMaterialViewModel(materialService, navigationService, supplierService);
            return viewModel;
        }
    }
}
