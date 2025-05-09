﻿using Dem.Commands;
using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services;
using Dem.Services.DbServices.DbServiceInterfaces;
using System.Windows.Input;

namespace Dem.ViewModels
{
    public class RequestViewModel : ViewModelBase
    {
        private Request _request; 

        public Guid Id => _request.Id;
        public int QuantityOfProduct
        {
            get => _request.QuantityOfProduct;
            set
            {
                _request.QuantityOfProduct = value;
                OnPropertyChanged(nameof(QuantityOfProduct));
            }
        }
        public decimal Price
        {
            get => _request.Price;
            set
            {
                _request.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public DateOnly DateOfCreation
        {
            get => _request.DateOfCreation;
            set
            {
                _request.DateOfCreation = value;
                OnPropertyChanged(nameof(DateOfCreation));
            }
        }
        public DateOnly? DateOfClosing
        {
            get => _request?.DateOfClosing;
            set
            {
                _request.DateOfClosing = value;
                OnPropertyChanged(nameof(DateOfClosing));
            }
        }
        public bool IsPrepayment
        {
            get => _request.IsPrepayment;
            set
            {
                _request.IsPrepayment = value;
                OnPropertyChanged(nameof(IsPrepayment));
            }
        }
        public Product Product
        {
            get => _request.Product;
            set
            {
                _request.Product = value;
                OnPropertyChanged(nameof(Product));
            }
        }
        public Partner Partner
        {
            get => _request.Partner;
            set
            {
                _request.Partner = value;
                OnPropertyChanged(nameof(Partner));
            }
        }

        public ICommand CloseRequest { get; set; }

        public RequestViewModel(Request request, IRequestService requestService, NavigationService<RequestListViewModel> requestListnavigationService)
        {
            _request = request;
            var navigateCommand = new NavigateCommand<RequestListViewModel>(requestListnavigationService);

            CloseRequest = new CloseRequestCommand(requestService, this, navigateCommand);
        }
    }
}
