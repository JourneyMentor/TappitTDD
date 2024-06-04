namespace User.Service.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class, new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task<T> UpdateAsync(T entity);
        Task HardDeleteAsync(T entity);
        Task HardDeleteRangeAsync(IList<T> entity);

    }
}
