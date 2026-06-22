using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;

namespace Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(string name)
        {
            var category = new Category { Name = name };
            await unitOfWork.Categories.CreateAsync(category);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await unitOfWork.Categories.FindOneAsync(id);
            if (category != null)
            {
                await unitOfWork.Categories.DeleteAsync(category);
                await unitOfWork.CommitAsync();
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await unitOfWork.Categories.FindManyAsync();
            return from c in categories.ToList()
                   select new CategoryDto
                   {
                       Id = c.Id,
                       Name = c.Name
                   };
        }

        public async Task<CategoryDto?> GetAsync(int id)
        {
            var category = await unitOfWork.Categories.FindOneAsync(id);
            if (category != null)
            {
                return new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
            return null;
        }

        public async Task UpdateAsync(CategoryDto updatedCategory)
        {
            var category = await unitOfWork.Categories.FindOneAsync(updatedCategory.Id);
            if (category != null)
            {
                category.Name = updatedCategory.Name;
                await unitOfWork.Categories.UpdateAsync(category);
            }
        }
    }
}
