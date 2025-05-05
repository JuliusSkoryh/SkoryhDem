using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Exceptions.NotFoundExceptions
{
    public class SupplierNotFoundException : Exception
    { 
        public SupplierNotFoundException() : base("Поставщик не найден") { }
        public SupplierNotFoundException(Guid supplierId) : base($"Поставщик с ID {supplierId} не найден.") { }
    }
}
