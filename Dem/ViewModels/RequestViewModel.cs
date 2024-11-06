using Dem.Commands;
using Dem.Models.Entities;
using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dem.ViewModels
{
    public class RequestViewModel : ViewModelBase
    {
        private Request _request;
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

        public RequestViewModel(Request request, CloseRequestCommand closeRequestCommand)
        {
            _request = request;
            CloseRequest = closeRequestCommand;
        }
    }
}
