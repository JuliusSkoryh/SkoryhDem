using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Models.Entities
{
    public class Product : Entity
    { 
        public string Type { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public byte[]? Image { get; set; }
        public int StandartNumber { get; set; }
        public decimal Cost { get; set; }
        public int QuantityInStorage { get; set; }



        public ICollection<Material> Materials { get; set; }
        public ICollection<Request>? Requests { get; set; }


        private Product() { }

        public Product(Guid id, string type, string name, string article, byte[]? image, int standartNumber, decimal cost, ICollection<Material> materials) : base(id)
        {
            Type = type;
            Name = name;
            Article = article;
            Image = image;
            StandartNumber = standartNumber;
            Cost = cost;
            Materials = materials;
        }
    }
}
