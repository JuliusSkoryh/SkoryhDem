using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Exceptions.NotFoundExceptions
{
    public class MaterialNotFoundException : Exception
    {
        public MaterialNotFoundException() : base("Материал не найден") { }
        public MaterialNotFoundException(Guid materialId) : base($"Материал с ID {materialId} не найден.") { }
    }
}
