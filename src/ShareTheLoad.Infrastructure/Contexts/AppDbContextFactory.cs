using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ShareTheLoad.Infrastructure.Contexts;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        // 
        var connectionString = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("store");

        return new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString).Options);
    }
}