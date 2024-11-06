using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Primitives
{
    public abstract class GenericRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext _db;

        protected GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public virtual ICollection<TEntity> GetAllAsync()
        {
            return  _db.Set<TEntity>().ToList();
        }

        public virtual TEntity? GetByIdAsync(Guid id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public virtual void AddAsync(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            _db.SaveChanges();
        }

        public virtual void UpdateAsync(TEntity entity)
        {
            _db.Update<TEntity>(entity);
            _db.SaveChanges();
        }

        public virtual void DeleteAsync(Guid id)
        {
            var entity = GetByIdAsync(id);
            if (entity != null)
            {
                _db.Set<TEntity>().Remove(entity);
                _db.SaveChanges();
            }
        }
    }
}
