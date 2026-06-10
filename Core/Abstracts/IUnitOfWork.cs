using Core.Abstracts.IRepositories;

namespace Core.Abstracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IBrandRepository Brands { get; }
        IStockDetailRepository StockDetails { get; }

        Task CommitAsync();
    }
}
