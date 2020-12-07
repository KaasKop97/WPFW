using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Week_13.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<IdentityUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        
        public async Task<IActionResult> Add()
        {
            ViewBag.Roles = _roleManager.Roles.ToList();
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(IdentityRole role)
        {
            if (string.IsNullOrEmpty(role.Name)) return View(role.Name);
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole(string RoleName)
        {
            Console.WriteLine(RoleName);
            var GetUser = await _userManager.GetUserAsync(HttpContext.User);
            await _userManager.AddToRoleAsync(GetUser, RoleName);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public async Task<IActionResult> RemoveUserFromRole(IdentityRole role)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }

            return RedirectToAction("Index");
        }
    }
}