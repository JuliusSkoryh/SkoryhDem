using Dem.Exceptions.NotFoundExceptions;
using Dem.Models.Entities;
using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Services.DbServices.DbServiceInterfaces
{
    public interface IProductService
    {
        public void AddAsync(Product product);
        public void UpdateAsync(Product product);
        public void DeleteAsync(Guid id);

        public ICollection<Product> GetAllAsync();
        public  ICollection<Product> GetAllWithDetailsAsync();

        public Product GetAsync(Guid id);
        public Product GetWithDetailsAsync(Guid id);
    }
}
