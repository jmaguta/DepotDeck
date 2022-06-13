using Microsoft.EntityFrameworkCore;
using DepotDeck.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DepotDeck.Infrastructure;
public static class StartupSetup
{
    public static void AddDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<DepotDeckDbContext>((options =>
            options.UseSqlServer(connectionString))); // will be created in web project root
}
