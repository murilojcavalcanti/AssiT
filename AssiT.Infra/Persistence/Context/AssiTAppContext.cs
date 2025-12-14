using AssiT.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssiT.Infra.Persistence.Context
{
    public class AssiTAppContext:DbContext
    {
        public AssiTAppContext(DbContextOptions<AssiTAppContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssiTAppContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
