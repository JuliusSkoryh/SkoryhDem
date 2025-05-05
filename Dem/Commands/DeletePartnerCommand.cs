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
    public class DeletePartnerCommand : AsyncCommandBase
    {
        private IPartnerService _partnerService;
        private EditPartnerViewModel _editPartnerViewModel;
        private readonly INavigationService<PartnerListViewModel> _navigationService;

        public DeletePartnerCommand(IPartnerService partnerService, EditPartnerViewModel editPartnerViewModel, INavigationService<PartnerListViewModel> navigationService)
        {
            _partnerService = partnerService;
            _editPartnerViewModel = editPartnerViewModel;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var result = MessageBox.Show("Вы уверены, что хотите удалить этого партнера?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
            {
                return;
            }


            try
            {
                _partnerService.Delete(_editPartnerViewModel.Id);
                MessageBox.Show("Партнер успешно удален", "Success");
                _navigationService.Navigate(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
