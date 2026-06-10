namespace Core.Concretes.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public int Quantity { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
