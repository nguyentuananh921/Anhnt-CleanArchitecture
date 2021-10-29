
using Application.Enums;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            

            //Seed Default User
            var basicUser = new ApplicationUser
            {
                UserName = "basicuser",
                Email = "basicuser@gmail.com",
                FirstName = "John",
                LastName = "Doe",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                IsActive = true
            };
            if (userManager.Users.All(u => u.Id != basicUser.Id))
            {
                var user = await userManager.FindByEmailAsync(basicUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(basicUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(basicUser, Roles.Basic.ToString());
                }
            }
        }
    }
}