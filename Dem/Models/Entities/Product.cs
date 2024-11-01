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
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public decimal? MinPriceForPartners { get; set; }
        public double? PackageLength { get; set; }
        public double? PackageWidth { get; set; }
        public double? PackageHeight { get; set; }
        public double? GrossWeight { get; set; }
        public int StandartNumber { get; set; }
        public string? ProductionType { get; set; }
        public decimal Cost { get; set; }
        public int? WorkShopNumber { get; set; }
        public int QuantityInStorage { get; set; }



        public DateTime? TimeToMakeProduct { get; set; }


        public ICollection<Material> Materials { get; set; }
        public ICollection<ProductHistory> ProductHistories { get; set; }
        public ICollection<Request> Requests { get; set; }


        private Product() { }



        public Product(Guid id, string type, string name, string article, string description, byte[] image, decimal minPriceForPartners, double packageLength,
            double packageWidth, double packageHeight, double grossWeight, int standartNumber, string productionType, decimal cost,
            int workShopNumber, ICollection<Material> materials, DateTime timeToMakeProduct, int quantityInStorage)
        {
            Id = id;
            Type = type;
            Name = name;
            Article = article;
            Description = description;
            Image = image;
            MinPriceForPartners = minPriceForPartners;
            PackageLength = packageLength;
            PackageWidth = packageWidth;
            PackageHeight = packageHeight;
            GrossWeight = grossWeight;
            StandartNumber = standartNumber;
            ProductionType = productionType;
            Cost = cost;
            WorkShopNumber = workShopNumber;
            Materials = materials;
            TimeToMakeProduct = timeToMakeProduct;
            QuantityInStorage = quantityInStorage;
        }

        public Product(string type, string name, string article, int standartNumber, decimal cost)
        {
            Type = type;
            Name = name;
            Article = article;
            StandartNumber = standartNumber;
            Cost = cost;
        }
    }
}
