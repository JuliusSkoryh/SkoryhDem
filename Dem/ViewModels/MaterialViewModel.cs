using Dem.Models.Entities;
using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public MaterialViewModel(Material material)
        {
            _material = material;
        }
    }
}
