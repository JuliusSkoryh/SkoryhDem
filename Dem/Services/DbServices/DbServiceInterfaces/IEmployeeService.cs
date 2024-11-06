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
        public void AddAsync(Employee employee);
        public void UpdateAsync(Employee employee);
        public void DeleteAsync(Guid id);

        public ICollection<Employee> GetAllAsync();
        public ICollection<Employee> GetAllWithDetailsAsync();

        public Employee GetAsync(Guid id);
    }
}
