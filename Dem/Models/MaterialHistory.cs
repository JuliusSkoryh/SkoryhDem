using Dem.Models.Enums;
using Dem.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Models
{
    public class MaterialHistory : Entity
    {
        public DateOnly Date { get; set; }
        public OperationType OperationType { get; set; }
        public int QuantityOfPackaging { get; set; }

        public Guid MaterialId { get; set; }
        public Material Material { get; set; }

        private MaterialHistory() { }

        public MaterialHistory(Guid id, DateOnly date, OperationType operationType, int quantityOfPackaging, Guid materialId, Material material)
        {
            Id = id;
            Date = date;
            OperationType = operationType;
            QuantityOfPackaging = quantityOfPackaging;
            MaterialId = materialId;
            Material = material;
        }
    }
}
