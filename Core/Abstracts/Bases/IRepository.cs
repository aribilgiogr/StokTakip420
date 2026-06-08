using System.Linq.Expressions;

namespace Core.Abstracts.Bases
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task<T?> FindOneAsync(int id);
        Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>>? where = null, params string[] includes);
        Task<T?> FindFirstAsync(Expression<Func<T, bool>>? where = null);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
