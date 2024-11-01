using Dem.Models.Enums;
using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Models.Entities
{
    public class ProductHistory : Entity
    {
        public DateOnly Date { get; set; }
        public int QuantityOfProduct { get; set; }
        public decimal Price { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid PartnerId { get; set; }
        public Partner Partner { get; set; }

        private ProductHistory() { }
        public ProductHistory(Guid id, DateOnly date, int quantityOfProduct, decimal price, Guid productId, Guid partnerId)
        {
            Id = id;
            Date = date;
            QuantityOfProduct = quantityOfProduct;
            Price = price;
            ProductId = productId;
            PartnerId = partnerId;
        }
    }
}
