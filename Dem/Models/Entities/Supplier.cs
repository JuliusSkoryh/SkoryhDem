using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Models.Entities
{
    public class Supplier : Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string TIN { get; set; }

        public IEnumerable<Material> Materials { get; set; }

        private Supplier() { }

        public Supplier(Guid id, string name, string type, string tIN) : base(id)
        {
            Name = name;
            Type = type;
            TIN = tIN;
        }
    }
}
