using crud_based_baltaio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crud_based_baltaio.Data.Maps
{
  public class CategoryMap : IEntityTypeConfiguration<Category>
  {
    public void Configure(EntityTypeBuilder<Category> builder)
    {
      builder.ToTable("Categories");
      builder.HasKey(category => category.Id);
      builder.Property(category => category.Title).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
    }
  }
}
