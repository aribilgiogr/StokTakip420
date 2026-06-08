using Core.Abstracts.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int Quantity { get; set; }
    }

    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
    }

    public class Brand : BaseEntity
    {
        public string Name { get; set; } = null!;
    }

    public class StockDetail : BaseEntity
    {
        public int ProductId { get; set; }
        public string MovementType { get; set; } = null!; // "In" or "Out"
        public int Quantity { get; set; }
    }
}
