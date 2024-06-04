using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using User.Database.Entities;



namespace User.Database.Context
{
    public class AppDbContext : IdentityDbContext<Entities.User, Role, Guid>
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        // public DbSet<Table> TableName { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
