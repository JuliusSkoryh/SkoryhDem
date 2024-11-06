using Dem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Services.DbServices.DbServiceInterfaces
{
    public interface IMaterialService
    {
        public void AddAsync(Material material);
        public void UpdateAsync(Material material);
        public void DeleteAsync(Guid id);

        public ICollection<Material> GetAllAsync();
        public ICollection<Material> GetAllWithDetailsAsync();

        public Material GetAsync(Guid id);
        public Material GetWithDetailsAsync(Guid id);
    }
}
