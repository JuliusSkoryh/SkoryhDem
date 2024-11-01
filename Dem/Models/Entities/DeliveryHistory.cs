using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Models.Entities
{
    public class DeliveryHistory : Entity
    {
        public DateOnly Date { get; set; }
        public int QuantityOfMaterials { get; set; }
        public decimal Price { get; set; }

        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public Guid MaterialId { get; set; }
        public Material Material { get; set; }

        private DeliveryHistory() { }
        public DeliveryHistory(Guid id, DateOnly date, int quantityOfMaterials, decimal price, Guid supplierId, Guid materialId)
        {
            Id = id;
            Date = date;
            QuantityOfMaterials = quantityOfMaterials;
            Price = price;
            SupplierId = supplierId;
            MaterialId = materialId;
        }
    }
}
