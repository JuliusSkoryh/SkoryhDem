using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Models.Entities
{
    public class Request : Entity
    {
        public int QuantityOfProduct { get; set; }
        public decimal Price { get; set; }
        public DateOnly DateOfProductCreation { get; set; }
        public DateOnly DateOfCreation { get; set; }
        public bool IsPrepayment { get; set; }


        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid PartnerId { get; set; }
        public Partner Partner { get; set; }

        private Request() { }

        public Request(Guid id, int quantityOfProduct, decimal price, DateOnly dateOfProductCreation, DateOnly dateOfCreation, bool isPrepayment, Guid productId, Guid partnerId)
        {
            Id = id;
            QuantityOfProduct = quantityOfProduct;
            Price = price;
            DateOfProductCreation = dateOfProductCreation;
            DateOfCreation = dateOfCreation;
            IsPrepayment = isPrepayment;
            ProductId = productId;
            PartnerId = partnerId;
        }
    }
}
