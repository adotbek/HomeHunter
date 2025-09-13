using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> UserRoles { get; set; }
    public DbSet<Home> Homes { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Category> Categories{ get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
