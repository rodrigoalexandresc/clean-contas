using Clean.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Clean.Infra.Data
{
    public class ReadOnlyRepository<T, Id> : IReadOnlyRepository<T, Id> where T : Entity<Id>
    {
        protected ContasDbContext _dbContext;

        public ReadOnlyRepository(ContasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T?> GetAsync(Id id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().Where(expression).ToListAsync();
        }

        public IQueryable<T> Query() 
        {
            return _dbContext.Set<T>().AsQueryable();
        }
    }
}
