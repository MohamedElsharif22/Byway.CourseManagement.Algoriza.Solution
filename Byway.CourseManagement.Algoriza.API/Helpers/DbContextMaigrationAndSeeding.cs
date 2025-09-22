using Byway.Infrastructure._Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Byway.CourseManagement.Algoriza.API.Helpers
{
    public static class DbContextMaigrationAndSeeding
    {
        public static async Task<WebApplication> MiagrateAndSeedDatabasesAsync(this WebApplication webApplication)
        {
            using var scope = webApplication.Services.CreateScope();

            var services = scope.ServiceProvider;

            var _bywayDbContext = services.GetRequiredService<BywayDbContext>();

            //var _identityDbContext = services.GetRequiredService<AppIdentityDbContext>();

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await _bywayDbContext.Database.MigrateAsync();
                //await BywayContextSeed.SeedDatabaseAsync(_bywayDbContext);
                //await _identityDbContext.Database.MigrateAsync();
                //var _userManeger = services.GetRequiredService<UserManager<ApplicationUser>>();
                //var _roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                //await IdentityDbContextSeed.SeedDataAsync(_userManeger, _roleManager);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();

                logger.LogError(ex, "an error has been occured while running migration!");
            }

            return webApplication;
        }
    }
}
