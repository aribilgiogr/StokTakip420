using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Abstracts.Bases
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _set;

        protected Repository(DbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public async Task CreateAsync(T entity) => await _set.AddAsync(entity);

        public async Task DeleteAsync(T entity) => await Task.Run(() => _set.Remove(entity));

        public async Task<T?> FindFirstAsync(Expression<Func<T, bool>>? where = null) => await _set.FirstOrDefaultAsync(where ?? (x => true));

        public async Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>>? where = null, params string[] includes)
        {
            var data = _set.Where(where ?? (x => true));

            foreach (var include in includes)
            {
                data = data.Include(include);
            }

            return await data.ToListAsync();
        }

        public async Task<T?> FindOneAsync(int id) => await _set.FindAsync(id);

        public async Task UpdateAsync(T entity) => await Task.Run(() => _set.Update(entity));
    }
}
