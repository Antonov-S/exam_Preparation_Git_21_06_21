namespace Git.Data
{
    using Microsoft.EntityFrameworkCore;

    public class GitDbContext : DbContext
    {
        public DbSet<User> Users { get; init; }
        public DbSet<Repository> Repositories { get; init; }
        public DbSet<Commit> Commits { get; init; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Git;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Repository>()
                .HasOne(r => r.Owner)
                .WithMany(o => o.Repositories)
                .HasForeignKey(r => r.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Commit>()
                .HasOne(r => r.Creator)
                .WithMany(c => c.Commits)
                .HasForeignKey(a => a.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Commit>()
                .HasOne(c => c.Repository)
                .WithMany(r => r.Commits)
                .HasForeignKey(c => c.RepositoryId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
