using System.Linq.Expressions;

namespace Clean.Domain
{
    public interface IRepository<T, Id> where T : class
    {
        Task<Id> Add(T entity);
        Task Delete(Id id);
        Task Update(T entity);
    }

    public interface IReadOnlyRepository<T, Id> where T : class
    {
        Task<T?> GetAsync(Id id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> Query();
    }
}
