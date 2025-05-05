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
        public void Add(Supplier supplier);
        public void Update(Supplier supplier);
        public void Delete(Guid id);

        public List<Supplier>  GetAll();

        public Supplier Get(Guid id);
        public Supplier GetWithDetails(Guid id);

        bool SuppliersExist();
    }
}
