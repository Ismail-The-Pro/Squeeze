using Microsoft.EntityFrameworkCore;
using Squeeze.Models;

public class AppDbContext : DbContext
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

        // Definer desimal presisjon og lengder for strengtyper for MySQL
        modelBuilder.Entity<Bestilling>(entity =>
        {
            entity.Property(e => e.TotalPris)
                  .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Status)
                  .IsRequired()
                  .HasColumnType("VARCHAR(255)");  // Setter en grense for Statusfeltets lengde

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
                  .HasColumnType("VARCHAR(255)");  // Definerer VARCHAR for Navn

            entity.Property(e => e.Price)
                  .HasColumnType("decimal(18, 2)");  // Angir presisjon for Pris

            entity.Property(e => e.IsAvailable)
                  .HasColumnType("tinyint(1)");  // Bruker tinyint for boolean-verdier i MySQL

            entity.Property(e => e.Stock)
                  .HasColumnType("int");
        });
    }
}

