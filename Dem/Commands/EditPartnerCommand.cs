using Dem.Exceptions.NotFoundExceptions;
using Dem.Models.Entities;
using Dem.Primitives;
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
    public class EditPartnerCommand : AsyncCommandBase
    {
        private readonly IPartnerService _partnerService;
        private readonly EditPartnerViewModel _editPartnerViewModel;

        public EditPartnerCommand(IPartnerService partnerService, EditPartnerViewModel editPartnerViewModel)
        {
            _partnerService = partnerService;
            _editPartnerViewModel = editPartnerViewModel;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            var partner = _partnerService.GetAsync(_editPartnerViewModel.Id);

            if (partner == null)
            {
                throw new PartnerNotFoundException();
            }
            partner.Name = _editPartnerViewModel.Name;
            partner.TIN = _editPartnerViewModel.TIN;
            partner.Phone = _editPartnerViewModel.Phone;
            partner.Director = _editPartnerViewModel.Director;
            partner.Email = _editPartnerViewModel.Email;
            partner.LegalAddress = _editPartnerViewModel.LegalAddress;
            partner.Rating = _editPartnerViewModel.SelectedRating;

            try
            {
                _partnerService.UpdateAsync(partner);
                MessageBox.Show("Партнер успешно обновлён", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
    }
}
