using Dem.Commands;
using Dem.Models.Enums;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices.DbServiceInterfaces;
using System.IO;
using System.Windows.Input;

namespace Dem.ViewModels
{
    public class AddPartnerViewModel : ViewModelBase
    {
        private readonly IPartnerService _partnerService;

        public string Type { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Email {  get; set; }
        public string Phone {  get; set; }
        public string LegalAddress { get; set; }
        public string TIN { get; set; }

        public ICommand AddPartnerCommand { get; }
        public ICommand CancelWindowCommand { get; }

        public AddPartnerViewModel(IPartnerService partnerService, INavigationService<PartnerListViewModel> navigationService)
        {
            _partnerService = partnerService;

            AddPartnerCommand = new AddPartnerCommand(partnerService, navigationService, this);
            CancelWindowCommand = new NavigateCommand<PartnerListViewModel>(navigationService);
        }
    }
}
