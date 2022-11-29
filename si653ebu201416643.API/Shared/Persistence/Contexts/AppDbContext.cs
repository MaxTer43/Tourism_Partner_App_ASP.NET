using si653ebu201416643.API.Training.Domain.Models;
using si653ebu201416643.API.Painting.Domain.Models;
using si653ebu201416643.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace si653ebu201416643.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Provider> Providers { get; set; }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Authors
        
        builder.Entity<Author>().ToTable("Authors");
        builder.Entity<Author>().HasKey(p => p.Id);
        builder.Entity<Author>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Author>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
        builder.Entity<Author>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
        builder.Entity<Author>().Property(p => p.Nickname).IsRequired().HasMaxLength(30);
        builder.Entity<Author>().Property(p => p.PhotoUrl).HasMaxLength(200);

        // Providers

        builder.Entity<Provider>().ToTable("Providers");
        builder.Entity<Provider>().HasKey(p => p.Id);
        builder.Entity<Provider>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Provider>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Provider>().Property(p => p.ApiUrl).IsRequired().HasMaxLength(30);
        builder.Entity<Provider>().Property(p => p.KeyRequired).HasMaxLength(30);
        builder.Entity<Provider>().Property(p => p.ApiKey).HasMaxLength(200);
        

        // Apply Snake Case Naming Conventions
        
        builder.UseSnakeCaseNamingConvention();
    }
}