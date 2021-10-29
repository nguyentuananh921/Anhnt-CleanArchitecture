using Application.Enums;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Abstractions;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    //public class RoleController : BaseController<RoleController>
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            // var rolemodel = await _roleManager.Roles.FirstOrDefaultAsync();
            var checkExistRoleName = await _roleManager.RoleExistsAsync(roleName);           
            if ((roleName != null) && (!checkExistRoleName))
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    Errors(result);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                //return View(roleName);
                return RedirectToAction("Index");
            }
        }
        //Check error During 
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
        //public async Task<IActionResult> LoadAll()
        //{
        //    var roles = await _roleManager.Roles.ToListAsync();
        //    var model = 
        //    //var model = _mapper.Map<IEnumerable<RoleViewModel>>(roles);
        //    return PartialView("_ViewAll", model);
        //}

        //public async Task<IActionResult> OnGetCreate(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_Create", new RoleViewModel()) });
        //    else
        //    {
        //        var role = await _roleManager.FindByIdAsync(id);
        //        //if (role == null) _notify.Error("Unexpected Error. Role not found!");
        //        //var roleviewModel = _mapper.Map<RoleViewModel>(role);
        //        return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_Create", roleviewModel) });
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> OnPostCreate(RoleViewModel role)
        //{
        //    if (ModelState.IsValid && role.Name != "SuperAdmin" && role.Name != "Basic")
        //    {
        //        if (string.IsNullOrEmpty(role.Id))
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole(role.Name));
        //            _notify.Success("Role Created");
        //        }
        //        else
        //        {
        //            var existingRole = await _roleManager.FindByIdAsync(role.Id);
        //            existingRole.Name = role.Name;
        //            existingRole.NormalizedName = role.Name.ToUpper();
        //            await _roleManager.UpdateAsync(existingRole);
        //            //_notify.Success("Role Updated");
        //        }

        //        var roles = await _roleManager.Roles.ToListAsync();
        //        //var mappedRoles = _mapper.Map<IEnumerable<RoleViewModel>>(roles);
        //        var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", mappedRoles);
        //        return new JsonResult(new { isValid = true, html = html });
        //    }
        //    else
        //    {
        //        var html = await _viewRenderer.RenderViewToStringAsync<RoleViewModel>("_CreateOrEdit", role);
        //        return new JsonResult(new { isValid = false, html = html });
        //    }
        //}

        //public async Task<JsonResult> OnPostDelete(string id)
        //{
        //    var existingRole = await _roleManager.FindByIdAsync(id);
        //    if (existingRole.Name != "SuperAdmin" && existingRole.Name != "Basic")
        //    {
        //        //TODO Check if Any Users already uses this Role
        //        bool roleIsNotUsed = true;
        //        var allUsers = await _userManager.Users.ToListAsync();
        //        foreach (var user in allUsers)
        //        {
        //            if (await _userManager.IsInRoleAsync(user, existingRole.Name))
        //            {
        //                roleIsNotUsed = false;
        //            }
        //        }
        //        if (roleIsNotUsed)
        //        {
        //            await _roleManager.DeleteAsync(existingRole);
        //            _notify.Success($"Role {existingRole.Name} deleted.");
        //        }
        //        else
        //        {
        //            _notify.Error("Role is being Used by another User. Cannot Delete.");
        //        }
        //    }
        //    else
        //    {
        //        //_notify.Error($"Not allowed to  delete {existingRole.Name} Role.");
        //    }
        //    var roles = await _roleManager.Roles.ToListAsync();
        //    var mappedRoles = _mapper.Map<IEnumerable<RoleViewModel>>(roles);
        //    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", mappedRoles);
        //    return new JsonResult(new { isValid = true, html = html });
        //}
    }
}
