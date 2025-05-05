using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Exceptions.NotFoundExceptions
{
    public class RequestNotFoundException : Exception
    { 
        public RequestNotFoundException() : base("Продукт не найден") { }
        public RequestNotFoundException(Guid requestId) : base($"Продукт с ID {requestId} не найден.") { }
    }
}
