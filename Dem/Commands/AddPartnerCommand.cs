using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices;
using Dem.Services.DbServices.DbServiceInterfaces;
using Dem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dem.Commands
{
    public class AddPartnerCommand : AsyncCommandBase
    {
        private readonly IPartnerService _partnerService;
        private readonly INavigationService<PartnerListViewModel> _navigationService;
        private readonly AddPartnerViewModel _viewModel;

        public AddPartnerCommand(IPartnerService partnerService, INavigationService<PartnerListViewModel> navigationService, AddPartnerViewModel viewModel)
        {
            _partnerService = partnerService;
            _navigationService = navigationService;
            _viewModel = viewModel;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            var partner = new Partner(Guid.NewGuid(), _viewModel.Type, _viewModel.Name, _viewModel.Director, _viewModel.Email, _viewModel.Phone, _viewModel.LegalAddress, _viewModel.TIN, Models.Enums.Rating.medium, null);

            try
            {
                _partnerService.AddAsync(partner);
                MessageBox.Show("Партнер успешно добавлен в базу данных", "Success");
                _navigationService.Navigate(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
