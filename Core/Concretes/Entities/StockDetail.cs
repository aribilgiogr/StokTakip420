using Core.Abstracts.Bases;

namespace Core.Concretes.Entities
{
    public class StockDetail : BaseEntity
    {
        public int ProductId { get; set; }
        public string MovementType { get; set; } = null!; // "In" or "Out"
        public int Quantity { get; set; }
    }
}
