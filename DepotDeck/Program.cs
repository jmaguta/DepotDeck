using DepotDeck.Data;
using DepotDeck.Infrastructure.Data;
using Autofac.Extensions.DependencyInjection;
using DepotDeck;
using DepotDeck.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

var connectionString = builder.Configuration.GetConnectionString("DepotDeckDb");

builder.Services.AddDbContext(connectionString);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


// Seed Database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<DepotDeckDbContext>();

        context.Database.EnsureCreated();

        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occured seeding the DB.");
    }
}


app.Run();
