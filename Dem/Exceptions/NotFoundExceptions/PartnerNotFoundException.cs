using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Exceptions.NotFoundExceptions
{
    public class PartnerNotFoundException : Exception
    {
        public PartnerNotFoundException() : base("Партнер не найден") { }
        public PartnerNotFoundException(Guid partnerId) : base($"Партнер с ID {partnerId} не найден.") { }
    }
}
