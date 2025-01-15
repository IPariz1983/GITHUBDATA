using GitHubRepoApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GitHubRepoApp.Infrastructure
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<RepositoryUser> Repositories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RepositoryUser>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Description);
                entity.Property(e => e.Url).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.Stars).IsRequired();
                entity.Property(e => e.Username).IsRequired();
            });
        }
    }
}
