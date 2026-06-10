using Core.Abstracts.Bases;
using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;

namespace Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(StockDb context) : base(context)
        {
        }
    }
}
