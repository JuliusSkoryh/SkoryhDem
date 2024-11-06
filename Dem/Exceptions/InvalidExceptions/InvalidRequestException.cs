using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Exceptions.InvalidExceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException() : base("Неверные параметры у заказа.") { }
        public InvalidRequestException(string message) : base($"Неверные параметры у заказа: {message}") { }
    }
}
