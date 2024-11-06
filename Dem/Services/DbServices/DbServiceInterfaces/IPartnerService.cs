using Dem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Services.DbServices.DbServiceInterfaces
{
    public interface IPartnerService
    {
        public void AddAsync(Partner partner);
        public void UpdateAsync(Partner partner);
        public void DeleteAsync(Guid id);

        public ICollection<Partner> GetAllAsync();
        public ICollection<Partner> GetAllWithDetailsAsync();

        public Partner GetAsync(Guid id);
        public Partner GetWithDetailsAsync(Guid id);
    }
}
