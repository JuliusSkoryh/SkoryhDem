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
        public void Add(Material material);
        public void Update(Material material);
        public void Delete(Guid id);

        public List<Material> GetAll();
        public List<Material> GetAllWithDetails();

        public Material Get(Guid id);
        public Material GetWithDetails(Guid id);
    }
}
