using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Squeeze.Models;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Lemonade> Lemonades { get; set; }
    public DbSet<Kunde> Kunder { get; set; }
    public DbSet<Bestilling> Bestillinger { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Bestilling>(entity =>
        {
            entity.Property(e => e.TotalPris)
                  .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Status)
                  .IsRequired()
                  .HasColumnType("VARCHAR(255)");

            entity.HasOne(d => d.Kunde)
                  .WithMany()
                  .HasForeignKey(d => d.KundeId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Kunde>(entity =>
        {
            entity.Property(e => e.Navn)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnType("VARCHAR(100)");

            entity.Property(e => e.Epost)
                  .IsRequired()
                  .HasMaxLength(255)
                  .HasColumnType("VARCHAR(255)");

            entity.Property(e => e.Telefon)
                  .HasMaxLength(25)
                  .HasColumnType("VARCHAR(25)");
        });

        modelBuilder.Entity<Lemonade>(entity =>
        {
            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasColumnType("VARCHAR(255)");

            entity.Property(e => e.Price)
                  .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.IsAvailable)
                  .HasColumnType("tinyint(1)");

            entity.Property(e => e.Stock)
                  .HasColumnType("int");
        });

        // Ekstra konfigurasjoner for Identity-tabeller
        modelBuilder.Entity<IdentityUser>()
            .Property(u => u.UserName)
            .HasMaxLength(256);

        modelBuilder.Entity<IdentityUser>()
            .Property(u => u.NormalizedUserName)
            .HasMaxLength(256);

        modelBuilder.Entity<IdentityUser>()
            .Property(u => u.Email)
            .HasMaxLength(256);

        modelBuilder.Entity<IdentityUser>()
            .Property(u => u.NormalizedEmail)
            .HasMaxLength(256);
    }
}
