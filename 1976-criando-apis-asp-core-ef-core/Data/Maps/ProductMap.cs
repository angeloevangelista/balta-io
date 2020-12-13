using crud_based_baltaio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crud_based_baltaio.Data.Maps
{
  public class ProductMap : IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.ToTable("Products");
      builder.HasKey(product => product.Id);

      builder.Property(product => product.CreateDate).IsRequired();
      builder.Property(product => product.LastUpdateDate).IsRequired();
      builder.Property(product => product.Quantity).IsRequired();
      builder.Property(product => product.Price).IsRequired().HasColumnType("decimal(10, 2)");
      builder.Property(product => product.Title).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
      builder.Property(product => product.Image).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
      builder.Property(product => product.Description).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");

      builder.HasOne(product => product.Category).WithMany(category => category.Products);
    }
  }
}
