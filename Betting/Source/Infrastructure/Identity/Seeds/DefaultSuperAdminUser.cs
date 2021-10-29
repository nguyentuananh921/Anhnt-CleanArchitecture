using Application.Constants;
using Application.Enums;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Seeds
{
    public static class DefaultSuperAdminUser
    {
        public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsForModule(module);
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, permission));
                }
            }
        }

        private async static Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("SuperAdmin");
            await roleManager.AddPermissionClaim(adminRole, "Users");
            //await roleManager.AddPermissionClaim(adminRole, "Products");
            //await roleManager.AddPermissionClaim(adminRole, "Brands");
        }

        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed SuperAdmin User
            var superAdminUser = new ApplicationUser
            {                
                UserName = "superadmin",
                Email = "superadmin@gmail.com",
                FirstName = "Nguyễn Tuấn",
                LastName = "Anh",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                IsActive = true
            };
            if (userManager.Users.All(u => u.Id != superAdminUser.Id))
            {
                var user = await userManager.FindByEmailAsync(superAdminUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(superAdminUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(superAdminUser, Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(superAdminUser, Roles.Moderator.ToString());
                    await userManager.AddToRoleAsync(superAdminUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(superAdminUser, Roles.SuperAdmin.ToString());
                }
                await roleManager.SeedClaimsForSuperAdmin();
            }
        }
    }
}