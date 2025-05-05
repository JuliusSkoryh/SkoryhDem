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
        public void Add(Partner partner);
        public void Update(Partner partner);
        public void Delete(Guid id);

        public List<Partner> GetAll();
        public List<Partner> GetAllWithDetails();

        public Partner Get(Guid id);
        public Partner GetWithDetails(Guid id);
    }
}
