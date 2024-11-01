using Dem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.ViewModels
{
    public class ProductViewModel
    {
        private readonly Product _product;

        public string Type => _product.Type;
        public string Name => _product.Name;
        public string Article => _product.Article;
        public string? Description => _product.Description;
        public byte[]? Image => null;
        public decimal? MinPriceForPartners => _product.MinPriceForPartners;
        public int StandartNumber => _product.StandartNumber;
        public string? ProductionType => _product.ProductionType;
        public decimal Cost => _product.Cost;
        public int? WorkShopNumber => _product.WorkShopNumber;
        public int QuantityInStorage => _product.QuantityInStorage;

        public ICollection<Material>? Materials => _product.Materials;
        public ICollection<Request> Requests => _product.Requests;

        public ProductViewModel(Product product)
        {
            _product = product;
        }
    }
}
