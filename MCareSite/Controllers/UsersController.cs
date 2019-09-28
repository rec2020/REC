using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.Services;
using NajmetAlraqeeSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NajmetAlraqeeSite.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly NajmetAlraqeeContext _context;
        private readonly IUserRepository _user;
        private readonly IHostingEnvironment _environment;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
       

        public UsersController(NajmetAlraqeeContext context, IUserRepository user, IHostingEnvironment environment, IMapper mapper ,UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _environment = environment;
            _mapper = mapper;
            _user = user;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page, string SearchString)
        {
            var users = _user.GetAllUsers();
            if (SearchString != null)
            {
                users = _user.GetAllUsers().Where(x => x.UserName.Contains(SearchString));
            }
            else
            {
                users = _user.GetAllUsers();
            }
            if (users.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View(await PaginatedList<User>.CreateAsync(users.AsNoTracking(), page ?? 1, pageSize));
        }
        #endregion

        #region Add

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(UserViewModels userViewModels)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = userViewModels.Name, Email = userViewModels.Email };
                var result = await _userManager.CreateAsync(user, userViewModels.Password);
                if (result.Succeeded)
                {
                    // Add a user to the default role, or any role you prefer here
                    await _userManager.AddToRoleAsync(user, "USEREMP");
                    return RedirectToAction("Index","Users");
                }
            }
            return View(userViewModels);
        }
        #endregion
    }
}