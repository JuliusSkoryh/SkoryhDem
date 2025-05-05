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
        public void Add(Request request);
        public void Update(Request request);
        public void Delete(Guid id);

        public List<Request> GetAll();
        public List<Request> GetAllWithDetails();

        public Request Get(Guid id);
        public Request GetWithDetails(Guid id);
    }
}
