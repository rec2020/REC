using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.Services;
using NajmetAlraqee.Site.ViewModels;
using NajmetAlraqeeSite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace NajmetAlraqeeSite.Controllers
{
    [Authorize]
    public class CitiesController : Controller
    {
        private readonly NajmetAlraqeeContext _context;
        private readonly ICityRepository _city;
        private readonly ICountryRepository _country;
        private readonly IMapper  _mapper;

        public CitiesController(NajmetAlraqeeContext context, ICityRepository city , IMapper mapper , ICountryRepository country )
        {
            _context = context;
            _city = city;
            _mapper = mapper;
            _country = country;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page)
        {
            var city = _city.GetCities();
            if (city.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View(await PaginatedList<City>.CreateAsync(city.AsNoTracking(), page ?? 1, pageSize));
        }
        #endregion 

      


        [HttpGet]
        public IActionResult Add()
        {
            CityViewModel ob = new CityViewModel();
           ViewBag.City = _city.GetCities();
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "EnglishName");
            return View(ob);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Add(CityViewModel cityviewmodel)
        {
            if (ModelState.IsValid)
            {
                var city = _mapper.Map<City>(cityviewmodel);
                _context.Add(city);
                _context.SaveChangesAsync();
                ViewBag.SuccessMsg = "successfully added";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "EnglishName");
            return View(cityviewmodel);
        }

        #region Delete
       
        public IActionResult Delete(long id)
        {
            _city.RemoveCity(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion 


        private bool CityExists(long id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}