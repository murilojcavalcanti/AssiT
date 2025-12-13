using AssiT.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssiT.BackEnd.Infra.Persistence.Configuration
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(c => c.Id);

/*            builder.Property(c => c.Alias)
                   .IsRequired()
                   .HasMaxLength(15);
            
            builder.Property(c => c.PhoneNumber)
                    .HasMaxLength(16)
                   .IsRequired();
            
            builder.Property(c => c.EmailAdress)
                   .IsRequired();
            
            builder.HasOne(c => c.User)
                   .WithMany(u => u.Contacts)
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
  */      }
    }
}
