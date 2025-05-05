using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public virtual List<TEntity> GetAll()
        {
            return  _db.Set<TEntity>().ToList();
        }

        public virtual TEntity? GetById(Guid id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            _db.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _db.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public virtual void Delete(Guid id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _db.Set<TEntity>().Remove(entity);
                _db.SaveChanges();
            }
        }
    }
}
