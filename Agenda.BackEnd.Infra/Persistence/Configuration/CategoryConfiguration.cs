using AssiT.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssiT.BackEnd.Infra.Persistence.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            
            builder.Property(C => C.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(c => c.Assets)
                .WithOne(a=>a.Category)
                .HasForeignKey(a=>a.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
