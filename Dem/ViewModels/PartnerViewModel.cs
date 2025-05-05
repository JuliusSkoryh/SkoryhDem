using Dem.Commands;
using Dem.Models.Entities;
using Dem.Models.Enums;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices;
using Dem.Services.DbServices.DbServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace Dem.ViewModels
{
    public class PartnerViewModel : ViewModelBase 
    {
        private readonly IPartnerService _partnerService;
        private Partner _partner;

        private ObservableCollection<Request> _partnerRequests;

        public Guid Id => _partner.Id;
        public string Type
        {
            get => _partner.Type;
            set
            {
                _partner.Type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        public string Name
        {
            get => _partner.Name;
            set
            {
                _partner.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Director
        {
            get => _partner.Director;
            set
            {
                _partner.Director = value;
                OnPropertyChanged(nameof(Director));
            }
        }
        public string Email
        {
            get => _partner.Email;
            set
            {
                _partner.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Phone
        {
            get => _partner.Phone;
            set
            {
                _partner.Phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        public string LegalAddress
        {
            get => _partner.LegalAddress;
            set
            {
                _partner.LegalAddress = value;
                OnPropertyChanged(nameof(LegalAddress));
            }
        }
        public string TIN
        {
            get => _partner.TIN;
            set
            {
                _partner.TIN = value;
                OnPropertyChanged(nameof(TIN));
            }
        }
        public int Rating
        {
            get => _partner.Rating;
            set
            {
                _partner.Rating = value;
                OnPropertyChanged(nameof(Rating));
            }
        }



        public ObservableCollection<Request> PartnerRequests
        { 
            get => _partnerRequests; 
            set
            {
                _partnerRequests = value;
                OnPropertyChanged(nameof(PartnerRequests));
            }
        }
        public ICommand EditPartnerCommand { get; }



        private PartnerViewModel(IPartnerService partnerService, INavigationService<EditPartnerViewModel> navigationService, Guid partnerId)
        {
            _partnerService = partnerService;
            EditPartnerCommand = new NavigateCommand<EditPartnerViewModel>(navigationService, partnerId);
        }


        private void InitializeAsync(Guid partnerId)
        {
            try
            {
                _partner = _partnerService.GetWithDetails(partnerId);

                if (_partner.Requests is null)
                {
                    _partnerRequests = new ObservableCollection<Request>();
                }
                else
                {
                    _partnerRequests = new ObservableCollection<Request>(_partner.Requests);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public static PartnerViewModel CreateAsync(IPartnerService partnerService, INavigationService<EditPartnerViewModel> navigationService, Guid partnerId)
        {
            var viewModel = new PartnerViewModel(partnerService, navigationService, partnerId);
            viewModel.InitializeAsync(partnerId);
            return viewModel;
        }
    }
}
