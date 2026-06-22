using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;

namespace Business.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork unitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(string name)
        {
            var brand = new Brand { Name = name };
            await unitOfWork.Brands.CreateAsync(brand);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var brand = await unitOfWork.Brands.FindOneAsync(id);
            if (brand != null)
            {
                await unitOfWork.Brands.DeleteAsync(brand);
                await unitOfWork.CommitAsync();
            }
        }

        public async Task<IEnumerable<BrandDto>> GetAllAsync()
        {
            var brands = await unitOfWork.Brands.FindManyAsync();
            return from b in brands.ToList()
                   select new BrandDto
                   {
                       Id = b.Id,
                       Name = b.Name
                   };
        }

        public async Task<BrandDto> GetAsync(int id)
        {
            var brand = await unitOfWork.Brands.FindOneAsync(id);
            if (brand != null)
            {
                return new BrandDto
                {
                    Id = brand.Id,
                    Name = brand.Name
                };
            }
            return null;
        }

        public async Task UpdateAsync(BrandDto updatedBrand)
        {
            var brand = await unitOfWork.Brands.FindOneAsync(updatedBrand.Id);
            if (brand != null)
            {
                await unitOfWork.Brands.UpdateAsync(brand);
                await unitOfWork.CommitAsync();
            }
        }
    }
}