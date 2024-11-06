using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Exceptions.NotFoundExceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() : base("Продукт не найден") { }
        public ProductNotFoundException(Guid productId) : base($"Продукт с ID {productId} не найден.") { }
    }
}
