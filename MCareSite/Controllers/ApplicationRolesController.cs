using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqeeSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NajmetAlraqeeSite.Controllers
{
    [Authorize]
    public class ApplicationRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;
        private readonly NajmetAlraqeeContext _context;
        public ApplicationRolesController(RoleManager<IdentityRole> roleManager, NajmetAlraqeeContext context , UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            ApplicationRole model = new ApplicationRole();
            var roles = _context.Roles;
            ViewBag.Roles = roles;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditApplicationRole(string id, ApplicationRole model)
        {
            if (ModelState.IsValid)
            {
                bool isExist = !String.IsNullOrEmpty(id);
                IdentityRole applicationRole = isExist ? await _context.Roles.FindAsync(id) :
               new IdentityRole
               {
               };
                applicationRole.Name = model.Name;

                IdentityResult roleRuslt = isExist ? await roleManager.UpdateAsync(applicationRole)
                                                    : await roleManager.CreateAsync(applicationRole);
                if (roleRuslt.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            bool isExist = !String.IsNullOrEmpty(id);
            if (isExist)
            {
                IdentityRole applicationRole = await _context.Roles.FindAsync(id);
                IdentityResult roleRuslt = await roleManager.DeleteAsync(applicationRole);
            }
            return RedirectToAction("Index");
        }


   
      
        public async Task<IActionResult> Premission(string id)
        {
            EditUserViewModel model = new EditUserViewModel();
            model.ApplicationRoles = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();
         
            ViewBag.ApplicationRoleId = roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();

            if (!String.IsNullOrEmpty(id))
            {
                User user = await userManager.FindByIdAsync(id);
                var userrole = await userManager.GetRolesAsync(user);
                model.UserRoles =(List<string>) userrole;
                model.UserName = user.UserName;
                if (user != null)
                {
                    model.UserId = id;
                  //  model.ApplicationRoleId = roleManager.Roles.Single(r => r.Name == userManager.GetRolesAsync(user).Result.Single()).Id;
                }
            }
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRoleToUser(EditUserViewModel model)
        {
            if (model.ApplicationRoleId!=null) { 
            var user = await userManager.FindByIdAsync(model.UserId);
                var rolename = roleManager.Roles.Where(c => c.Id == model.ApplicationRoleId).SingleOrDefault();
            if (!await userManager.IsInRoleAsync(user, model.ApplicationRoleId))
            {
                await userManager.AddToRoleAsync(user, rolename.Name);
            }
            }
            return RedirectToAction("Premission",new {id=model.UserId });
        }
        public async Task<IActionResult> DeleteRoleToUser(string item ,string UserId)
        {
            
            if (item != null)
            {
                var user = await userManager.FindByIdAsync(UserId);
                var rolename = roleManager.Roles.Where(c => c.Name.Contains(item)).SingleOrDefault();
                if (rolename!=null)
                {
                    await userManager.RemoveFromRoleAsync(user, rolename.Name);
                }
            }
            return RedirectToAction("Premission", new { id = UserId });
        }

    }
}