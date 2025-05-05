using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Exceptions.InvalidExceptions
{
    public class InvalidEmployeeException : Exception
    {
        public InvalidEmployeeException() : base("Неверные параметры у работника.") { }
        public InvalidEmployeeException(string message) : base($"Неверные параметры у работника: {message}") { } 
    }
}
