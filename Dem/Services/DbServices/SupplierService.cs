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

        public override void Add(Supplier supplier)
        {
            ValidateSupplier(supplier);
            base.Add(supplier);
        }

        public override void Update(Supplier supplier)
        {
            ValidateSupplier(supplier);
            base.Update(supplier);
        }
        public List<Supplier> GetAllWithDetails()
        {
            return _db.Suppliers.Include(p => p.Materials).ToList();
        }

        public Supplier Get(Guid id)
        {
            Supplier? supplier = GetById(id);

            return supplier == null ? throw new SupplierNotFoundException(id) : supplier;
        }
        public Supplier GetWithDetails(Guid id)
        {
            Supplier? supplier = _db.Suppliers.Include(p => p.Materials).FirstOrDefault(p => p.Id == id);

            return supplier == null ? throw new SupplierNotFoundException(id) : supplier;
        }

        public List<Supplier> GetAll()
        {
            var suppliers = base.GetAll();
            return suppliers;
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

        public bool SuppliersExist()
        {
            return _db.Suppliers.Any();
        }
    }
}
