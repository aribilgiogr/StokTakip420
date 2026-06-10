using Core.Concretes.DTOs;

namespace Core.Abstracts.IServices
{
    public interface ICategoryService
    {
        Task CreateAsync(string name);
        Task<CategoryDto> GetAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task UpdateAsync(CategoryDto updatedCategory);
        Task DeleteAsync(int id);
    }
}
