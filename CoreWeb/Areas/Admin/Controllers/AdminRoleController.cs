﻿using CoreWeb.Areas.Admin.Models;
using CoreWeb.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles="Admin")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = model.name
                };

                var result = await _roleManager.CreateAsync(role);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }

            return View(model);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(values);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult UserRoleList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();

            foreach(var item in roles)
            {
                RoleAssignViewModel m = new RoleAssignViewModel();

                m.RoleID = item.Id;
                m.Name = item.Name;
                m.Exists = userRoles.Contains(item.Name);

                model.Add(m);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userid = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);

            foreach(var item in model)
            {
                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }

            return RedirectToAction("UserRoleList");
        }


    }
}
