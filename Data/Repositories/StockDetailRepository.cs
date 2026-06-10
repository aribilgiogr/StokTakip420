using Core.Abstracts.Bases;
using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;

namespace Data.Repositories
{
    public class StockDetailRepository : Repository<StockDetail>, IStockDetailRepository
    {
        public StockDetailRepository(StockDb context) : base(context)
        {

        }
    }
}
