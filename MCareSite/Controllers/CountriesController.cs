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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NajmetAlraqeeSite.Controllers
{
    [Authorize]
    public class CountriesController : Controller
    {


        private readonly NajmetAlraqeeContext _context;
        private readonly ICountryRepository _country;
        private readonly IMapper _mapper;

        public CountriesController(NajmetAlraqeeContext context, ICountryRepository country, IMapper mapper)
        {
            _context = context;
            _country = country;
            _mapper = mapper;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page)
          {
            var country = _country.GetCountries(); 
            ViewBag.Country = country;
            if (country.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View(await PaginatedList<Country>.CreateAsync(country.AsNoTracking(), page ?? 1, pageSize));
        }
        #endregion

        #region Details
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = _country.GetById((long)id);
            var countryviewModels = _mapper.Map<CountryViewModel>(country);
            if (countryviewModels == null)
            {
                return NotFound();
            }

            return View(countryviewModels);
        }
        #endregion


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CountryViewModel countryviewmodel)
        {
            if (ModelState.IsValid)
            {
                var city = _mapper.Map<Country>(countryviewmodel);
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(countryviewmodel);
        }



        #region Edit
        // GET: Doctors1/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.SingleOrDefaultAsync(m => m.Id == id);
            var countryviewmodel = _mapper.Map<CountryViewModel>(country);
            if (country == null)
            {
                return NotFound();
            }
            return View(countryviewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, CountryViewModel countryviewmodel)
        {
            if (id != countryviewmodel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var country = _mapper.Map<Country>(countryviewmodel);
                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(countryviewmodel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(countryviewmodel);
        }
        #endregion

        #region Delete
        public  IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country =  _country.GetById((long)id);
            var countryviewmodel = _mapper.Map<CountryViewModel>(country);
            if (countryviewmodel == null)
            {
                return NotFound();
            }

            return View(countryviewmodel);
        }

        // POST: Doctors1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            _country.RemoveCountry(id);
            return RedirectToAction(nameof(Index));
        }

        #endregion 


        private bool CountryExists(long id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}