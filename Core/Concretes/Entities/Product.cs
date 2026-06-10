using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public int BrandId { get; set; }
        public virtual Brand? Brand { get; set; }
        public int Quantity { get; set; }
    }
}
