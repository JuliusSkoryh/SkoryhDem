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
        public byte[]? Image { get; set; }
        public decimal Cost { get; set; }
        public int QuantityInStorage { get; set; }
        public int? ReservedMaterials { get; set; }


        public Guid? SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public ICollection<Product> Products { get; set; }


        private Material() { }

        public Material(Guid id, string name, string type, int quantityInPackaging, string measurement, byte[]? image, decimal cost, Guid? supplierId) : base(id)
        {
            Name = name;
            Type = type;
            QuantityInPackaging = quantityInPackaging;
            Measurement = measurement;
            Image = image;
            Cost = cost;
            SupplierId = supplierId;
            QuantityInStorage = 0;
        }
    }
}
