using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Description).HasMaxLength(1000);

        builder.HasOne<Owner>() // Reporter sifatida
               .WithMany()
               .HasForeignKey(r => r.ReporterId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Home>() // Report qilingan uy
               .WithMany()
               .HasForeignKey(r => r.ReportedHomeId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
