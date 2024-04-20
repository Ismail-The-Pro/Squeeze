using Microsoft.EntityFrameworkCore;
using Squeeze.Models;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext  // Use the full namespace
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
        // Model configuration code
    }
}
