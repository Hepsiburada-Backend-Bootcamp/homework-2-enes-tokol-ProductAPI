using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id).UseMySqlIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}