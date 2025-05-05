using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Commands
{
    class SaveMaterialCommand : AsyncCommandBase
    {
        private IMaterialService _materialService;
        private AddMaterialViewModel _addMaterialViewModel;
        private readonly INavigationService<MaterialListViewModel> _navigationService;

        public SaveMaterialCommand(IMaterialService materialService, AddMaterialViewModel addMaterialViewModel, INavigationService<MaterialListViewModel> navigationService)
        {
            _materialService = materialService;
            _addMaterialViewModel = addMaterialViewModel;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Guid? supplierId = _addMaterialViewModel.SelectedSupplier.Id;

            if (supplierId == Guid.Empty)
            {
                supplierId = null;
            }

            var material = new Material(Guid.NewGuid(), _addMaterialViewModel.Name, _addMaterialViewModel.Type, _addMaterialViewModel.QuantityInPackaging, 
                _addMaterialViewModel.Measurement, _addMaterialViewModel.Image, _addMaterialViewModel.Cost, supplierId);

            _materialService.Add(material);
            _navigationService.Navigate(null);
        }
    }
}
