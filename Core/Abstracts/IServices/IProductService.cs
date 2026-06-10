using Core.Concretes.DTOs;

namespace Core.Abstracts.IServices
{
    public interface IProductService
    {
        Task<ProductDto?> GetAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<IEnumerable<ProductDto>> GetAllByCategoryAsync(int categoryId);
        Task<IEnumerable<ProductDto>> GetAllByBrandAsync(int brandId);
    }
}
