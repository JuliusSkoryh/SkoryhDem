using Dem.Exceptions.InvalidExceptions;
using Dem.Exceptions.NotFoundExceptions;
using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Services.DbServices
{
    public class ProductService : GenericRepository<Product>, IProductService
    {
        public ProductService(ApplicationDbContext db) : base(db) { }

        public override void AddAsync(Product product)
        {
            ValidateProduct(product);
            base.AddAsync(product);
        }

        public override void UpdateAsync(Product product)
        {
            ValidateProduct(product);
            base.UpdateAsync(product);
        }
        public ICollection<Product> GetAllWithDetailsAsync()
        {
            return _db.Products.Include(p => p.Materials).Include(p => p.Requests).ToList();
        }

        public Product GetAsync(Guid id)
        {
            Product? product = GetByIdAsync(id);

            return product == null ? throw new ProductNotFoundException(id) : product;
        }
        public Product GetWithDetailsAsync(Guid id)
        {
            Product? product = _db.Products.Include(p => p.Materials).Include(p => p.Requests).FirstOrDefault(p => p.Id == id);

            return product == null ? throw new ProductNotFoundException(id) : product;
        }

        private void ValidateProduct(Product product)
        {
            if (product == null)
            {
                throw new InvalidProductException();
            }
            if (product.Cost < 0)
            {
                throw new InvalidProductException("цена не может быть ниже нуля");
            }
            if (product.QuantityInStorage < 0)
            {
                throw new InvalidProductException("количество продукции на складе не может быть ниже нуля");
            }
            if(product.Materials == null || product.Materials.Count == 0)
            {
                throw new InvalidProductException("Отсутствует материал продукта");
            }
            if (
                String.IsNullOrEmpty(product.Type)
                || String.IsNullOrEmpty(product.Name)
                || String.IsNullOrEmpty(product.Article))
            {
                throw new InvalidProductException();
            }
        }
        
    }

}
