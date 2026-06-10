using Core.Abstracts;
using Core.Abstracts.IRepositories;
using Data.Repositories;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StockDb context;

        public UnitOfWork(StockDb context)
        {
            this.context = context;
        }

        private IProductRepository? products;
        public IProductRepository Products => products ??= new ProductRepository(context);


        private ICategoryRepository? categories;
        public ICategoryRepository Categories => categories ??= new CategoryRepository(context);


        private IBrandRepository? brands;
        public IBrandRepository Brands => brands ??= new BrandRepository(context);


        private IStockDetailRepository? stockDetails;
        public IStockDetailRepository StockDetails => stockDetails ??= new StockDetailRepository(context);


        public async Task CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async ValueTask DisposeAsync()
        {
            await context.DisposeAsync();
        }
    }
}
