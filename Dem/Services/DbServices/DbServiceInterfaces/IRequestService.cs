using Dem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Services.DbServices.DbServiceInterfaces
{
    public interface IRequestService
    {
        public void AddAsync(Request request);
        public void UpdateAsync(Request request);
        public void DeleteAsync(Guid id);

        public ICollection<Request> GetAllAsync();
        public  ICollection<Request> GetAllWithDetailsAsync();

        public Request GetAsync(Guid id);
        public Request GetWithDetailsAsync(Guid id);
    }
}
