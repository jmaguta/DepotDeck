using Microsoft.EntityFrameworkCore;
using DepotDeck.Core;

namespace DepotDeck.Infrastructure.Data;
public class DepotDeckDbContext : DbContext
{
    public DepotDeckDbContext(DbContextOptions<DepotDeckDbContext> options) 
        : base(options) {}
    public DbSet<InspectionModel> Inspections => Set<InspectionModel>();


    //public DbSet<TechnicianModel> Technicians { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<InspectionModel>().ToTable("Inspection");
        //modelBuilder.Entity<TechnicianModel>().ToTable("Technician");
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
