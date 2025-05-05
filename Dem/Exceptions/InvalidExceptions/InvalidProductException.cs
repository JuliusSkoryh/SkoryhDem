using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Exceptions.InvalidExceptions
{
    public class InvalidProductException : Exception
    { 
        public InvalidProductException() : base("Неверные параметры у продукта.") { }
        public InvalidProductException(string message) : base($"Неверные параметры у продукта: {message}") { }
    }
}
