using Dem.Exceptions.InvalidExceptions;
using Dem.Exceptions.NotFoundExceptions;
using Dem.Models.Entities;
using Dem.Primitives;
using Dem.Services.DbServices.DbServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Dem.Services.DbServices
{
    public class MaterialService : GenericRepository<Material>, IMaterialService
    {
        public MaterialService(ApplicationDbContext db) : base(db) { }

        public override void AddAsync(Material material)
        {
            ValidateMaterial(material);
            base.AddAsync(material);
        }

        public override void UpdateAsync(Material material)
        {
            ValidateMaterial(material);
            base.UpdateAsync(material);
        }
        public ICollection<Material> GetAllWithDetailsAsync()
        {
            return _db.Materials.Include(p => p.Supplier).Include(p => p.Products).ToList();
        }

        public Material GetAsync(Guid id)
        {
            Material? material = GetByIdAsync(id);

            return material == null ? throw new MaterialNotFoundException(id) : material;
        }
        public Material GetWithDetailsAsync(Guid id)
        {
            Material? material = _db.Materials.Include(p => p.Supplier).Include(p => p.Products).FirstOrDefault();
            return material == null ? throw new MaterialNotFoundException(id) : material;
        }

        private void ValidateMaterial(Material material)
        {
            if (material == null)
            {
                throw new InvalidMaterialException();
            }
            if (material.QuantityInPackaging < 0)
            {
                throw new InvalidMaterialException("количество материала в упаковке не может быть ниже нуля");
            }
            if (material.Cost < 0)
            {
                throw new InvalidMaterialException("цена не может быть ниже нуля");
            }
            if (material.QuantityInStorage < 0)
            {
                throw new InvalidMaterialException("количество материала на складе не может быть ниже нуля");
            }
            if (
                String.IsNullOrEmpty(material.Type)
                || String.IsNullOrEmpty(material.Name)
                || String.IsNullOrEmpty(material.Measurement))
            {
                throw new InvalidMaterialException();
            }
        }
    }
}
