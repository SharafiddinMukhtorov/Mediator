using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Inrastructure.Persistence.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.Price)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.HasOne(c => c.Brand)
               .WithMany(b => b.Cars)
               .HasForeignKey(c => c.BrandId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.Category)
               .WithMany(h => h.Cars)
               .HasForeignKey(c => c.CategoryId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
