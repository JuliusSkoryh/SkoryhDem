using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Exceptions.InvalidExceptions
{
    public class InvalidSupplierException : Exception
    {
        public InvalidSupplierException() : base("Неверные параметры у поставщика.") { }
        public InvalidSupplierException(string message) : base($"Неверные параметры у поставщика: {message}") { }
    }
}
