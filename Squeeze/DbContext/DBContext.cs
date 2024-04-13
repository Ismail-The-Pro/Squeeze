using Microsoft.EntityFrameworkCore;
using Squeeze.Models;

namespace Squeeze.DbContext
{
    
    using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Produkt> Produkter { get; set; }
    public DbSet<Kunde> Kunder { get; set; }
    public DbSet<Bestilling> Bestillinger { get; set; }
    public DbSet<Bestillingsdetalj> Bestillingsdetaljer { get; set; }
    public DbSet<Rabatt> Rabatter { get; set; }
}

   
}
