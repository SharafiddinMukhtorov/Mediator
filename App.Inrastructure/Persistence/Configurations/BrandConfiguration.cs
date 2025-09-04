using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Inrastructure.Persistence.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasMany(b => b.Cars)
               .WithOne(c => c.Brand)
               .HasForeignKey(c => c.BrandId);
    }
}
