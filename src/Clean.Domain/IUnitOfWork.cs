namespace Clean.Domain
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}