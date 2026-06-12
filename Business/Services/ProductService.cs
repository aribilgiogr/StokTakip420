using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddAsync(NewProductDto newProduct)
        {
            Product product = new Product
            {
                Name = newProduct.Name,
                BrandId = newProduct.BrandId,
                CategoryId = newProduct.CategoryId,
                Quantity = newProduct.Quantity,
                Description = newProduct.Description
            };

            await unitOfWork.Products.CreateAsync(product);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await unitOfWork.Products.FindOneAsync(id);
            if (product != null)
            {
                await unitOfWork.Products.DeleteAsync(product);
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await unitOfWork.Products.FindManyAsync(null, "Category", "Brand");
            return from p in products.ToList()
                   select new ProductDto
                   {
                       Id = p.Id,
                       Name = p.Name,
                       BrandId = p.BrandId,
                       BrandName = p.Brand!.Name,
                       CategoryId = p.CategoryId,
                       CategoryName = p.Category!.Name,
                       Quantity = p.Quantity,
                       LastUpdatedTime = p.UpdatedAt ?? p.CreatedAt
                   };
        }

        public async Task<IEnumerable<ProductDto>> GetAllByBrandAsync(int brandId)
        {
            var products = await unitOfWork.Products.FindManyAsync(x => x.BrandId == brandId, "Category", "Brand");
            return from p in products.ToList()
                   select new ProductDto
                   {
                       Id = p.Id,
                       Name = p.Name,
                       BrandId = p.BrandId,
                       BrandName = p.Brand!.Name,
                       CategoryId = p.CategoryId,
                       CategoryName = p.Category!.Name,
                       Quantity = p.Quantity,
                       LastUpdatedTime = p.UpdatedAt ?? p.CreatedAt
                   };
        }

        public async Task<IEnumerable<ProductDto>> GetAllByCategoryAsync(int categoryId)
        {
            var products = await unitOfWork.Products.FindManyAsync(x => x.CategoryId == categoryId, "Category", "Brand");
            return from p in products.ToList()
                   select new ProductDto
                   {
                       Id = p.Id,
                       Name = p.Name,
                       BrandId = p.BrandId,
                       BrandName = p.Brand!.Name,
                       CategoryId = p.CategoryId,
                       CategoryName = p.Category!.Name,
                       Quantity = p.Quantity,
                       LastUpdatedTime = p.UpdatedAt ?? p.CreatedAt
                   };
        }

        public async Task<ProductDto?> GetAsync(int id)
        {
            var p = await unitOfWork.Products.FindOneAsync(id);
            if (p != null)
            {
                return new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    BrandId = p.BrandId,
                    BrandName = p.Brand!.Name,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category!.Name,
                    Quantity = p.Quantity,
                    LastUpdatedTime = p.UpdatedAt ?? p.CreatedAt
                };
            }
            return null;
        }

        public Task UpdateAsync(int id, NewProductDto updatedProduct)
        {
            throw new NotImplementedException();
        }
    }
}
