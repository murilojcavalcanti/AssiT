using AssiT.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssiT.BackEnd.Infra.Persistence.Configuration
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.AcquisitionValue)
                   .IsRequired();
            builder.Property(a => a.AcquisitionDate)
                    .IsRequired();

            builder.Property(a => a.AssetStatus)
                    .IsRequired();

            builder.Property(a => a.SerialNumber)
                    .HasMaxLength(15)
                   .IsRequired();
            builder.HasIndex(a => a.SerialNumber)
                .IsUnique();
            
            builder.HasOne(A => A.Category)
                   .WithMany(C => C.Assets)
                   .HasForeignKey(A => A.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
