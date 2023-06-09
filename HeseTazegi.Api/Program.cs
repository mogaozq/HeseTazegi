using HeseTazegi.Persistance;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Writers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace HeseTazegi.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            await MigrateAndSeedAsync(host);

            host.Run();
        }

        private static async Task MigrateAndSeedAsync(IHost host)
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

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
