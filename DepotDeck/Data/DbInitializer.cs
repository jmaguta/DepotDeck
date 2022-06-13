using DepotDeck.Core;
using DepotDeck.Infrastructure.Data;

namespace DepotDeck.Data;

public static class DbInitializer
{
    public static void Initializer(DepotDeckDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Inspections.Any())
        {
            return;
        }

        var inspections = new InspectionModel[]
        {
            new InspectionModel { Id = 1, Description = "Twisted axel", Make = "Ford", Model = "camper van", Registration = "MW57FRK"},
            new InspectionModel { Id = 2, Description = "Burned clutch", Make = "Mercedes", Model = "Gclass", Registration = "IJ20IPK"},
            new InspectionModel { Id = 3, Description = "Flat Tires", Make = "Scania", Model = "L", Registration = "WE22OUI"},
            new InspectionModel { Id = 4, Description = "Poor Alignment", Make = "Scania", Model = "L", Registration = "AO20JIJ"},
            new InspectionModel { Id = 5, Description = "Rusting", Make = "Scania", Model = "P", Registration = "MW57FRK"},
            new InspectionModel { Id = 6, Description = "Burned clutch", Make = "Scania", Model = "G", Registration = "ZA69EWR"},
            new InspectionModel { Id = 7, Description = "Bad Brakes", Make = "Scania", Model = "R", Registration = "MW57FRK"},
            new InspectionModel { Id = 8, Description = "Warning Lights", Make = "Scania", Model = "L", Registration = "IJ20IPK"},
            new InspectionModel { Id = 9, Description = "Overheating", Make = "Mercedes", Model = "Actross L", Registration = "MW57FRK"},
            new InspectionModel { Id = 10, Description = "Broken tail lights", Make = "Mercedes", Model = "eActros", Registration = "PL21QWE"},
            new InspectionModel { Id = 11, Description = "Broken Head lights", Make = "Mercedes", Model = "Actross", Registration = "MW59OEE"},
            new InspectionModel { Id = 12, Description = "Faulty air bags", Make = "Mercedes", Model = "Gclass", Registration = "OL22OPO"},
            new InspectionModel { Id = 13, Description = "Broken AC/heat", Make = "Mercedes", Model = "eEconic", Registration = "MW57FRK"},
            new InspectionModel { Id = 14, Description = "Dead battery", Make = "Scania", Model = "Gclass", Registration = "AO20JIJ"},
            new InspectionModel { Id = 15, Description = "Fuel tank leak", Make = "Mercedes", Model = "Atego", Registration = "BH59OEK"}
        };

        foreach (InspectionModel i in inspections)
        {
            context.Inspections.Add(i);
        }

        context.SaveChanges();
    }
}
