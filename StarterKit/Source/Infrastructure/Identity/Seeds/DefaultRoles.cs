using Application.Enums;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedRoleAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            
                if (roleManager.Roles.All(r => r.Name != Roles.Admin.ToString()))
                {
                    //Seed Roles
                    await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
                    await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
                    await roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
                    await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
                }            
        }
    }
}