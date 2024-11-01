using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Models.Entities
{
    public class Material : Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int QuantityInPackaging { get; set; }
        public string Measurement { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public decimal Cost { get; set; }
        //public int QuantityInStock { get; set; }
        public decimal MinimumQuantityAllowed { get; set; }
        public int QuantityInStorage { get; set; }
        public int ReservedMaterials { get; set; }


        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; }


        public ICollection<MaterialHistory> MaterialHistories { get; set; }
        public ICollection<DeliveryHistory> DeliveryHistories { get; set; }
        public ICollection<Product> Products { get; set; }


        private Material() { }

        public Material(Guid id, string name, string type, int quantityInPackaging, string measurement, string description, byte[] image, decimal cost,
            decimal minimumQuantityAllowed, Guid supplierId, int quantityInStorage)
        {
            Id = id;
            Name = name;
            Type = type;
            QuantityInPackaging = quantityInPackaging;
            Measurement = measurement;
            Description = description;
            Image = image;
            Cost = cost;
            MinimumQuantityAllowed = minimumQuantityAllowed;
            SupplierId = supplierId;
            QuantityInStorage = quantityInStorage;
        }
    }
}
