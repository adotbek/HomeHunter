using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    internal class LocationCategory
    {
    }
}
public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Country).IsRequired().HasMaxLength(100);
        builder.Property(l => l.City).IsRequired().HasMaxLength(100);
        builder.Property(l => l.District).HasMaxLength(100);
        builder.Property(l => l.Street).HasMaxLength(200);
        builder.Property(l => l.ZipCode).HasMaxLength(20);
        builder.Property(l => l.Landmark).HasMaxLength(200);

        builder.HasMany(l => l.Homes)
               .WithOne() // Home ichida Location navigation bo‘lishi kerak
               .OnDelete(DeleteBehavior.Restrict);
    }
}
