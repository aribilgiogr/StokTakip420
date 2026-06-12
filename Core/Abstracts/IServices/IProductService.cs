using Core.Concretes.DTOs;

namespace Core.Abstracts.IServices
{
    public interface IProductService
    {
        Task<ProductDto?> GetAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<IEnumerable<ProductDto>> GetAllByCategoryAsync(int categoryId);
        Task<IEnumerable<ProductDto>> GetAllByBrandAsync(int brandId);

        Task AddAsync(NewProductDto newProduct);
        Task UpdateAsync(int id, NewProductDto updatedProduct);
        Task DeleteAsync(int id);
    }
}
