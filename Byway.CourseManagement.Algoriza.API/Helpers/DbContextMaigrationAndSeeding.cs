using Byway.Domain.Entities.Identity;
using Byway.Domain.Repositoies.Contract;
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

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                await _bywayDbContext.Database.MigrateAsync();
                var _roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var _userManeger = services.GetRequiredService<UserManager<ApplicationUser>>();
                await BywayContextSeed.SeedIdentityDataAsync(_userManeger,_roleManager);
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
