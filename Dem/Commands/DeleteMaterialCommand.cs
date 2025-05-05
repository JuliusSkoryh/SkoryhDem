using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.Services;
using Dem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dem.Services.DbServices;
using System.Windows;

namespace Dem.Commands
{
    public class DeleteMaterialCommand : CommandBase
    {
        private IMaterialService _materialService;
        private EditMaterialViewModel _editMaterialViewModel;
        private readonly INavigationService<MaterialListViewModel> _navigationService;

        public DeleteMaterialCommand(IMaterialService materialService, EditMaterialViewModel editMaterialViewModel, INavigationService<MaterialListViewModel> navigationService)
        {
            _materialService = materialService;
            _editMaterialViewModel = editMaterialViewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            var result = MessageBox.Show("Вы уверены, что хотите удалить этот материал?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
            {
                return;
            }


            try
            {
                _materialService.Delete(_editMaterialViewModel.Id);
                MessageBox.Show("Материал успешно удален", "Success");
                _navigationService.Navigate(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
