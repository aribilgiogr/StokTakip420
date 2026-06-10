using Core.Concretes.DTOs;

namespace Core.Abstracts.IServices
{
    public interface IBrandService
    {
        Task CreateAsync(string name);
        Task<BrandDto> GetAsync(int id);
        Task<IEnumerable<BrandDto>> GetAllAsync();
        Task UpdateAsync(BrandDto updatedBrand);
        Task DeleteAsync(int id);
    }
}
