using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using HeseTazegi.Application;
using HeseTazegi.Persistance;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HeseTazegi.Api", Version = "v1" });
});

var app = builder.Build();

await MigrateAndSeedAsync(app);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HeseTazegi.Api v1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

static async Task MigrateAndSeedAsync(IHost host)
{
    using var scope = host.Services.CreateScope();

    try
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<ApplicationDbContext>();
        if (context.Database.IsRelational())
        {
            context.Database.Migrate();
        }

        await ApplicationDbContextSeed.SeedCategoryAsync(context);
        await ApplicationDbContextSeed.SeedIngredientsAsync(context);
        await ApplicationDbContextSeed.SeedEquipmentsAsync(context);
        await ApplicationDbContextSeed.SeedNutrientsAsync(context);

        await ApplicationDbContextSeed.SeedFoodsAsync(context);
        await ApplicationDbContextSeed.SeedFoodIngredientsAsync(context);
        await ApplicationDbContextSeed.SeedFoodEquipmentsAsync(context);
        await ApplicationDbContextSeed.SeedFoodNutritionFactsAsync(context);

        await ApplicationDbContextSeed.SeedUsersAsync(context);
        await ApplicationDbContextSeed.SeedUserAllergicIngredientsAsync(context);

    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        logger.LogError(ex, "An error occured while migrating or seeding the database");

        throw;
    }
}
