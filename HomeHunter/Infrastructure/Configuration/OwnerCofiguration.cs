using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(o => o.SecondName)
            .HasMaxLength(100);

        builder.Property(o => o.UserName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(o => o.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(o => o.PhoneNumber)    
            .HasMaxLength(20);

        builder.Property(o => o.PasswordHash)
            .IsRequired();

        builder.Property(o => o.PasswordSalt)
            .IsRequired();

        builder.HasMany(o => o.Homes)
            .WithOne(h => h.Owner)
            .HasForeignKey(h => h.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(o => o.RefreshTokens)
            .WithOne(r => r.Owner)
            .HasForeignKey(r => r.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(o => o.Role)
            .WithMany(r => r.Owners)
            .HasForeignKey(o => o.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
