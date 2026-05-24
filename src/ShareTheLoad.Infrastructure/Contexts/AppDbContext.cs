using Microsoft.EntityFrameworkCore;
using ShareTheLoad.Domain.Entities;

namespace ShareTheLoad.Infrastructure.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Get all of the entities that inherit from BaseEntity
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach(var entry in entries)
        {
            if(entry.State == EntityState.Added)
                entry.Entity.CreatedAt = DateTime.UtcNow;

            if(entry.State == EntityState.Modified)
                entry.Entity.UpdatedAt = DateTime.UtcNow;
        }

        return base.SaveChangesAsync(cancellationToken);    
    }
}