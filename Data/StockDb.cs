using Core.Concretes.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class StockDb : DbContext
    {
        public StockDb(DbContextOptions<StockDb> options) : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<StockDetail> StockDetails { get; set; }
    }
}
