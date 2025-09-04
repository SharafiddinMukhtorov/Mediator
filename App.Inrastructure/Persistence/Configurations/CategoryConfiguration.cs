using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Inrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(cat => cat.Id);

        builder.Property(cat => cat.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasMany(cat => cat.Cars)
               .WithOne(c => c.Category)
               .HasForeignKey(c => c.CategoryId);
    }
}
