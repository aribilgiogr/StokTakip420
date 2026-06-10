using Core.Abstracts.Bases;
using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;

namespace Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(StockDb context) : base(context)
        {
        }
    }
}
