using AssiT.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssiT.BackEnd.Infra.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            
            builder.Property(u => u.Name)
                .HasMaxLength(100)
                   .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(100)
                   .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Perfil)
                   .IsRequired();

            builder.Property(u => u.Password)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
