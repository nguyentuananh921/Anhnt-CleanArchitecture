using Infrastructure.Database.DatabaseContext;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC
{
    public class Program
    {       
        public async static Task Main(string[] args)
        {
            //var host = CreateHostBuilder(args).Build();
            //https://alexcodetuts.com/2020/02/05/asp-net-core-3-1-clean-architecture-invoice-management-app-part-1/
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger("app");
                try
                {
                    var context = services.GetRequiredService<IdentityContext>();
                    var datacontext = services.GetRequiredService<ApplicationDbContext>();
                    context.Database.Migrate();
                    //Run Seeding here
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    
                    await Infrastructure.Identity.Seeds.DefaultRoles.SeedRoleAsync(userManager, roleManager);
                    await Infrastructure.Identity.Seeds.DefaultSuperAdminUser.SeedSuperAdminAsync(userManager, roleManager);
                    await Infrastructure.Identity.Seeds.DefaultBasicUser.SeedBasicUserAsync(userManager, roleManager);
                    
                    //datacontext.Database.EnsureCreated();
                    datacontext.Database.Migrate();
                    await Infrastructure.Database.DatabaseSeeds.SeedData.SeedAppLicationData(datacontext);
                    logger.LogInformation("Finished Seeding Default Data");
                    logger.LogInformation("Application Starting");
                }
                catch (Exception ex)
                {
                    logger.LogWarning(ex, "An error occurred seeding the DB");
                }
            }
            host.Run();
            
        }       
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
