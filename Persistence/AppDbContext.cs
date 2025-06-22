using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<Seller> Sellers { get; set; }
    public required DbSet<Sale> Sales { get; set; }
    public required DbSet<Rule> Rules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Seller>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<Sale>()
           .HasKey(sa => sa.Id);

        modelBuilder.Entity<Rule>()
           .HasKey(r => r.Id);


        modelBuilder.Entity<Sale>()
          .HasOne(se => se.Seller);

        modelBuilder.Entity<Sale>()
          .HasOne(r => r.Rule);
    }
}
