using Core.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IProductService
    {
        Task<ProductDto> GetAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<IEnumerable<ProductDto>> GetAllByCategory(int categoryId);
        Task<IEnumerable<ProductDto>> GetAllByBrand(int brandId);
    }
}
