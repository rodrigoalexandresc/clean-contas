using Clean.Domain;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContasDbContext _dbContext;

        public UnitOfWork(ContasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}
