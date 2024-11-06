using Dem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Services.DbServices.DbServiceInterfaces
{
    public interface ISupplierService
    {
        public void AddAsync(Supplier supplier);
        public void UpdateAsync(Supplier supplier);
        public void DeleteAsync(Guid id);

        public ICollection<Supplier>  GetAllAsync();
        public ICollection<Supplier> GetAllWithDetailsAsync();

        public Supplier GetAsync(Guid id);
        public Supplier GetWithDetailsAsync(Guid id);
    }
}
