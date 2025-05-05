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
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(Guid id);

        public List<Product> GetAll();
        public List<Product> GetAllWithDetails();

        public Product Get(Guid id);
        public Product GetWithDetails(Guid id);
    }
}
