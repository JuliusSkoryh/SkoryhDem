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
    public class SupplierService : GenericRepository<Supplier>, ISupplierService
    {
        public SupplierService(ApplicationDbContext db) : base(db) { }

        public override void AddAsync(Supplier supplier)
        {
            ValidateSupplier(supplier);
            base.AddAsync(supplier);
        }

        public override void UpdateAsync(Supplier supplier)
        {
            ValidateSupplier(supplier);
            base.UpdateAsync(supplier);
        }
        public ICollection<Supplier> GetAllWithDetailsAsync()
        {
            return _db.Suppliers.Include(p => p.Materials).ToList();
        }

        public Supplier GetAsync(Guid id)
        {
            Supplier? supplier = GetByIdAsync(id);

            return supplier == null ? throw new SupplierNotFoundException(id) : supplier;
        }
        public Supplier GetWithDetailsAsync(Guid id)
        {
            Supplier? supplier = _db.Suppliers.Include(p => p.Materials).FirstOrDefault(p => p.Id == id);

            return supplier == null ? throw new SupplierNotFoundException(id) : supplier;
        }

        private void ValidateSupplier(Supplier supplier)
        {
            if (supplier == null)
            {
                throw new InvalidSupplierException();
            }
            if (
                String.IsNullOrEmpty(supplier.Type)
                || String.IsNullOrEmpty(supplier.Name)
                || String.IsNullOrEmpty(supplier.TIN))
            {
                throw new InvalidPartnerException();
            }
        }
    }
}
