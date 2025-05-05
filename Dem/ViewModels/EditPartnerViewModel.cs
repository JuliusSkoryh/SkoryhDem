using Dem.Commands;
using Dem.Models.Entities;
using Dem.Models.Enums;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices.DbServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Dem.ViewModels
{
    public class EditPartnerViewModel : ViewModelBase
    {
        private readonly IPartnerService _partnerService;
        private Partner _partner;

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
        public int SelectedRating
        {
            get => _partner.Rating;
            set
            {
                _partner.Rating = value;
                OnPropertyChanged(nameof(SelectedRating));
            }
        }

        public ObservableCollection<int> Ratings { get; set; }

        public ICommand EditPartnerCommand { get; }
        public ICommand CancelWindowCommand { get; }
        public ICommand DeleteCommand { get; }
        private EditPartnerViewModel(IPartnerService partnerService, INavigationService<PartnerListViewModel> navigationService)
        {
            _partnerService = partnerService;

            EditPartnerCommand = new EditPartnerCommand(_partnerService, this);
            CancelWindowCommand = new NavigateCommand<PartnerListViewModel>(navigationService);
            DeleteCommand = new DeletePartnerCommand(_partnerService, this, navigationService);
        }

        public static EditPartnerViewModel CreateAsync(Guid id, IPartnerService partnerService, INavigationService<PartnerListViewModel> navigationService)
        {
            var viewModel = new EditPartnerViewModel(partnerService, navigationService);
            viewModel.InitializeAsync(id);
            return viewModel;
        }

        private void InitializeAsync(Guid id)
        {
            try
            {
                _partner = _partnerService.Get(id);
                SelectedRating = _partner.Rating;
                Ratings = new ObservableCollection<int>(Enumerable.Range(1, 10));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
