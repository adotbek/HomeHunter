using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class HomeConfiguration : IEntityTypeConfiguration<Home>
{
    public void Configure(EntityTypeBuilder<Home> builder)
    {
        builder.HasKey(h => h.Id);

        builder.Property(h => h.Location).IsRequired();
        builder.Property(h => h.OwnerNumber).IsRequired().HasMaxLength(20);
        builder.Property(h => h.Bio).HasMaxLength(1000);
        //builder.Property(h => h.Price).hascol("decimal(18,2)");
        builder.Property(h => h.Type).IsRequired().HasMaxLength(50);
        builder.Property(h => h.Status).IsRequired().HasMaxLength(50);

        builder.HasOne(h => h.Category)
               .WithMany(c => c.Homes);

        builder.HasOne(h => h.Image)
               .WithOne(i => i.Home)
               .HasForeignKey<Image>(i => i.HomeId);

        builder.HasOne<Location>(/* navigation property Home ichida yo‘q bo‘lsa, qo‘shish kerak */);
        builder.HasOne<Owner>(/* Home ga Owner qo‘shilsa, relationshipni bu yerga yozamiz */);
    }
}
