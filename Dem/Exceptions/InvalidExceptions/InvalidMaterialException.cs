using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Exceptions.InvalidExceptions
{
    public class InvalidMaterialException : Exception
    {
        public InvalidMaterialException() : base("Неверные параметры у материала.") { }
        public InvalidMaterialException(string message) : base($"Неверные параметры у материала: {message}") { }
    }
}
