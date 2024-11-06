using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Exceptions.InvalidExceptions
{
    public class InvalidPartnerException : Exception
    {
        public InvalidPartnerException() : base("Неверные параметры у партнера.") { }
        public InvalidPartnerException(string message) : base($"Неверные параметры у партнера: {message}") { }
    }
}
