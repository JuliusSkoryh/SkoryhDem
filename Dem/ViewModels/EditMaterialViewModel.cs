using Dem.Commands;
using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices.DbServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Dem.ViewModels
{
    public class EditMaterialViewModel : ViewModelBase
    {
        private readonly IMaterialService _materialService;
        private readonly ISupplierService _supplierService;
        private Material _material;

        public Guid Id => _material.Id;
        public string Type
        {
            get => _material.Type;
            set
            {
                _material.Type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        public string Name
        {
            get => _material.Name;
            set
            {
                _material.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int QuantityInPackaging
        {
            get => _material.QuantityInPackaging;
            set
            {
                _material.QuantityInPackaging = value;
                OnPropertyChanged(nameof(QuantityInPackaging));
            }
        }
        public string Measurement
        {
            get => _material.Measurement;
            set
            {
                _material.Measurement = value;
                OnPropertyChanged(nameof(Measurement));
            }
        }
        public decimal Cost
        {
            get => _material.Cost;
            set
            {
                _material.Cost = value;
                OnPropertyChanged(nameof(Cost));
            }
        }
        public byte[]? Image
        {
            get => _material.Image;
            set
            {
                _material.Image = value;
                OnPropertyChanged(nameof(Image));
                OnPropertyChanged(nameof(ImagePreview));
            }
        }
        public BitmapImage ImagePreview
        {
            get
            {
                if (_material.Image == null || _material.Image.Length == 0)
                {
                    return null;
                }

                using (var ms = new MemoryStream(_material.Image))
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();
                    bitmap.Freeze();
                    return bitmap;
                }
            }
        }
        public int? ReservedMaterials
        {
            get => _material.ReservedMaterials;
            set
            {
                _material.ReservedMaterials = value;
                OnPropertyChanged(nameof(ReservedMaterials));
            }
        }
        public Supplier SelectedSupplier
        {
            get => _material.Supplier;
            set
            {
                _material.Supplier = value;
                _material.SupplierId = value?.Id;
                OnPropertyChanged(nameof(SelectedSupplier));
            }
        }
        public ObservableCollection<Supplier> Suppliers { get; set; }

        public ICommand LoadImageCommand { get; }
        public ICommand EditMaterialCommand { get; }
        public ICommand CancelWindowCommand { get; }
        public ICommand DeleteCommand { get; }

        private EditMaterialViewModel(
            IMaterialService materialService,
            ISupplierService supplierService,
            INavigationService<MaterialListViewModel> navigationService)
        {
            _materialService = materialService;
            _supplierService = supplierService;

            LoadImageCommand = new LoadImageCommand(() => Image, (img) => Image = img);
            EditMaterialCommand = new EditMaterialCommand(_materialService, this);
            CancelWindowCommand = new NavigateCommand<MaterialListViewModel>(navigationService);
            DeleteCommand = new DeleteMaterialCommand(_materialService, this, navigationService);
        }

        public static EditMaterialViewModel CreateAsync(Guid id, IMaterialService materialService, ISupplierService supplierService, INavigationService<MaterialListViewModel> navigationService)
        {
            var vm = new EditMaterialViewModel(materialService, supplierService, navigationService);
            vm.LoadMaterial(id);
            vm.LoadSuppliers();
            return vm;
        }

        private void LoadMaterial(Guid id)
        {
            try
            {
                _material = _materialService.Get(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки материала.");
            }
        }

        private void LoadSuppliers()
        {
            try
            {
                Suppliers = new ObservableCollection<Supplier>(_supplierService.GetAll());
                if(Suppliers == null)
                {
                    throw new ArgumentNullException("В базе данных отсутствуют поставщики.");
                }
                SelectedSupplier = _material.Supplier;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки поставщиков.");
            }
        }
    }
}
