using Core.Abstracts.Bases;
using Core.Concretes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IRepositories
{
    public interface IProductRepository : IRepository<Product> { }
    public interface ICategoryRepository : IRepository<Category> { }
    public interface IBrandRepository : IRepository<Brand> { }
    public interface IStockDetailRepository : IRepository<StockDetail> { }
}
