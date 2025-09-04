using App.Domain.Models;
using App.Inrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
namespace App.Inrastructure.Persistence;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new BrandConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    }
}
