using DepotDeck.Core;
using DepotDeck.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DepotDeck;

public class SeedData
{
    // Checks on the existance of the DB
    // Should be either here or in Program.cs in DepotDeck.Web
    //CreateDbIfNotExists(app);

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var dbContext = new DepotDeckDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<DepotDeckDbContext>>()))
        {
            if (dbContext.Inspections.Any())
            {
                return;   // DB has been seeded
            }



            PopulateTestData(dbContext);



        }

    }
    public static void PopulateTestData(DepotDeckDbContext dbContext)
    {
        var inspections = new List<InspectionModel>
        {
            new InspectionModel {
                Id = 1,
                Registration = "MW57FRK",
                Make = "Ford",
                Model = "FireTruck",
                Description = "Something is wrong with it..."
            }
        };

        foreach (InspectionModel i in inspections)
        {
            dbContext.Inspections.Add(i);
        }

        dbContext.SaveChanges();
    }
}