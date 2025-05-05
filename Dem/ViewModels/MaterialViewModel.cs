using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services.DbServices;
using Dem.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Dem.Commands;
using Dem.Services.DbServices.DbServiceInterfaces;

namespace Dem.ViewModels
{
    public class MaterialViewModel: ViewModelBase 
    {
        private readonly Material _material;
        public Material Material
        {
            get => _material;
        }

        public Guid Id => _material.Id;
        public string Name => _material.Name;

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public string Type { get => _material.Type; }
        public int QuantityInPackaging { get => _material.QuantityInPackaging; }
        public string Measurement { get => _material.Measurement; }
        public decimal Cost { get => _material.Cost; }
        public byte[]? Image { get => _material.Image; }


        public ImageSource? ImagePreview { get; }
        public Supplier Supplier { get; set; }

        public ICommand EditMaterialCommand { get; }

        public MaterialViewModel(Material material, IMaterialService materialService, INavigationService<EditMaterialViewModel> navigationService)
        {
            _material = material;

            if (material.Image != null)
            {
                var image = new BitmapImage();
                using var stream = new MemoryStream(material.Image);
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                image.Freeze();
                ImagePreview = image;
            }

            EditMaterialCommand = new NavigateCommand<EditMaterialViewModel>(navigationService, _material.Id);
        }
    }
}
