using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Exceptions.NotFoundExceptions
{ 
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException() : base("Работник не найден") { }
        public EmployeeNotFoundException(Guid employeeId) : base($"Работник с ID {employeeId} не найден.") { }
    }
}
