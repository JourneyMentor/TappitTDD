using Microsoft.EntityFrameworkCore;
using User.Service.Interfaces.Repositories;

namespace User.Service.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, new()
    {
        private readonly DbContext dbContext;

        public WriteRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }
        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }
        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task SoftDeleteAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
        }

        public async Task HardDeleteRangeAsync(IList<T> entity)
        {
            await Task.Run(() => Table.RemoveRange(entity));
        }
    }

}
