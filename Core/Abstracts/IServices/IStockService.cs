using Core.Concretes.DTOs;

namespace Core.Abstracts.IServices
{

    public interface IStockService
    {
        Task InboundStockAsync(int productId, int quantity = 1);
        Task OutboundStockAsync(int productId, int quantity = 1);
        Task<IEnumerable<StockDetailDto>> GetAllStockMovements();
        Task<IEnumerable<StockDetailDto>> GetAllStockMovementsForProduct(int productId);
    }
}
