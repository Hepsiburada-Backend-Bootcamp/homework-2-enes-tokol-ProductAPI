using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id).UseMySqlIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired();
            
            builder.HasOne<Category>(x => x.Category)
                .WithMany(s => s.Products)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();
        }
    }
}