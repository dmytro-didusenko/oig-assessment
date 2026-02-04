using Infrastructure.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class OrganizationDbContext : DbContext
    {
        public OrganizationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Wasn't implemented
        }
    }
}
