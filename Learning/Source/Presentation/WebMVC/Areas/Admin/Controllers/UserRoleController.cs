using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Abstractions;
using WebMVC.Areas.Admin.Models;
using WebMVC.Controllers.Common;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserRoleController : BaseController<UserRoleController>
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesViewModel>();
            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UserRolesViewModel();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.FirstName = user.FirstName;
                thisViewModel.LastName = user.LastName;
                thisViewModel.Roles = await GetUserRoles(user);
                userRolesViewModel.Add(thisViewModel);
            }
            return View(userRolesViewModel);
        }
        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        //public async Task<IActionResult> Index(string userId)
        //{
        //    var viewModel = new List<UserRolesViewModel>();
        //    var user = await _userManager.FindByIdAsync(userId);
        //    ViewData["Title"] = $"{user.UserName} - Roles";
        //    ViewData["Caption"] = $"Manage {user.Email}'s Roles.";
        //    foreach (var role in _roleManager.Roles)
        //    {
        //        var userRolesViewModel = new UserRolesViewModel
        //        {
        //            RoleName = role.Name
        //        };
        //        if (await _userManager.IsInRoleAsync(user, role.Name))
        //        {
        //            userRolesViewModel.Selected = true;
        //        }
        //        else
        //        {
        //            userRolesViewModel.Selected = false;
        //        }
        //        viewModel.Add(userRolesViewModel);
        //    }
        //    var model = new ManageUserRolesViewModel()
        //    {
        //        UserId = userId,
        //        UserRoles = viewModel
        //    };

        //    return View(model);
        //}

        //public async Task<IActionResult> Update(string id, ManageUserRolesViewModel model)
        //{
        //    var user = await _userManager.FindByIdAsync(id);
        //    var roles = await _userManager.GetRolesAsync(user);
        //    var result = await _userManager.RemoveFromRolesAsync(user, roles);
        //    result = await _userManager.AddToRolesAsync(user, model.UserRoles.Where(x => x.Selected).Select(y => y.RoleName));
        //    var currentUser = await _userManager.GetUserAsync(User);
        //    await _signInManager.RefreshSignInAsync(currentUser);
        //    await Infrastructure.Identity.Seeds.DefaultSuperAdminUser.SeedSuperAdminAsync(_userManager, _roleManager);
        //    _notify.Success($"Updated Roles for User '{user.Email}'");
        //    return RedirectToAction("Index", new { userId = id });
        //}
        public async Task<IActionResult> Update(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }
            ViewBag.UserName = user.UserName;
            var model = new List<UserRolesEditViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var userRolesEditViewModel = new UserRolesEditViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesEditViewModel.Selected = true;
                }
                else
                {
                    userRolesEditViewModel.Selected = false;
                }
                model.Add(userRolesEditViewModel);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(List<UserRolesEditViewModel> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View();
            }
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }
            result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}