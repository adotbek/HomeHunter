using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(o => o.SecondName).IsRequired().HasMaxLength(50);
        builder.Property(o => o.UserName).IsRequired().HasMaxLength(50);
        builder.Property(o => o.Email).IsRequired().HasMaxLength(100);
        builder.Property(o => o.PhoneNumber).IsRequired().HasMaxLength(20);

        builder.HasOne(o => o.Role)
               .WithMany(r => r.Owners)
               .HasForeignKey(o => o.RoleId);

        builder.HasMany(o => o.RefreshTokens)
               .WithOne(rt => rt.Owner)  
               .HasForeignKey(rt => rt.OwnerId);

        builder.HasMany(o => o.Homes)
               .WithOne(); 
    }
}
