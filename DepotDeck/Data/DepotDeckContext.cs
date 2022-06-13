using Microsoft.EntityFrameworkCore;
using DepotDeck.Models;

namespace DepotDeck.Data;

public class DepotDeckContext : DbContext
{
    public DepotDeckContext(DbContextOptions<DepotDeckContext> options) : base(options)
    { }
    public DbSet<InspectionModel> Inspections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InspectionModel>().ToTable("Inspection");
    }
}
