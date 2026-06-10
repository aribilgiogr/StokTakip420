using Core.Abstracts.Bases;
using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;

namespace Data.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(StockDb context) : base(context)
        {

        }
    }
}
