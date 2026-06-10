namespace Core.Concretes.DTOs
{
    public class StockDetailDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string MovementType { get; set; } = null!; // "In" or "Out"
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
