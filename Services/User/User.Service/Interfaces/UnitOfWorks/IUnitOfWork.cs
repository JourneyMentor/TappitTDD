using User.Service.Interfaces.Repositories;

namespace User.Service.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, new();
        Task<int> SaveAsync();
        int Save();
    }
}
