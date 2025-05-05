using Dem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Services.DbServices.DbServiceInterfaces
{
    public interface IEmployeeService
    {
        public void Add(Employee employee);
        public void Update(Employee employee);
        public void Delete(Guid id);

        public List<Employee> GetAll();

        public Employee Get(Guid id);
        public Employee GetByEmail(string email);
    }
}
