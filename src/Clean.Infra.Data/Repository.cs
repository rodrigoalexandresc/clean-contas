using Clean.Domain;

namespace Clean.Infra.Data
{
    public class Repository<T, Id> : ReadOnlyRepository<T, Id>, IRepository<T, Id> where T : Entity<Id>
    {
        public Repository(ContasDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Id> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity.Id;
        }

        public async Task Delete(Id id)
        {
            var entity = await _dbContext.FindAsync<T>(id);
            _dbContext.Remove<T>(entity);
        }

        public async Task Update(T entity)
        {
            //var entity = await _dbContext.FindAsync<T>(id);
            _dbContext.Update<T>(entity);
        }
    }
}
