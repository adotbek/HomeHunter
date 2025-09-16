using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.RoleId);

        builder.Property(r => r.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(r => r.Description)
               .HasMaxLength(500);

        builder.HasMany(r => r.Users)
               .WithOne(u => u.Role)
               .HasForeignKey(u => u.RoleId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(r => r.Owners)
               .WithOne(o => o.Role)
               .HasForeignKey(o => o.RoleId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
