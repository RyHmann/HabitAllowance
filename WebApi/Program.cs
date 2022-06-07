using Microsoft.OpenApi.Models;
using Application;
using Persistence;
using Persistence.Context;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using WebApi;
using Microsoft.AspNetCore.Identity;
using Persistence.Identity;

public class Program
{
    public async static Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();

                if (context.Database.IsSqlServer())
                {
                    context.Database.Migrate();
                }
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

                await ApplicationDbContextSeed.SeedSampleDataAsync(context);
                await ApplicationDbContextSeed.SeedDefaultUserAsync(userManager);
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                logger.LogError(ex, "An error occurred while migrating or seeding the database");

                throw;
            }
        }

        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    });
}





