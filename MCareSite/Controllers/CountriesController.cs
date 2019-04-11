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
using NToastNotify;

namespace NajmetAlraqeeSite.Controllers
{
    [Authorize]
    public class CountriesController : Controller
    {


        private readonly NajmetAlraqeeContext _context;
        private readonly ICountryRepository _country;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public CountriesController(NajmetAlraqeeContext context, IToastNotification toastNotification ,  ICountryRepository country, IMapper mapper)
        {
            _context = context;
            _toastNotification = toastNotification;
            _country = country;
            _mapper = mapper;
        }

        #region Index 
        public IActionResult Index(int? page)
          {
            var country =  _country.GetCountries(); 
            ViewBag.Country = country;
           
            return View();
        }
        #endregion

      


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AddPost(CountryViewModel countryViewModels)
        {
            var CountryList = _country.GetCountries();
            ViewBag.Country = CountryList;
            if (countryViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    var country = _mapper.Map<Country>(countryViewModels);
                    _country.AddCountry(country);
                    _toastNotification.AddSuccessToastMessage("تم أضافةالبلد بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), countryViewModels);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var country = _mapper.Map<Country>(countryViewModels);
                    _country.UpdateCountry(countryViewModels.Id, country);
                    _toastNotification.AddSuccessToastMessage("تم تعديل البلد بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), countryViewModels);
            }
        }



        

        #region Delete
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _country.RemoveCountry((int)id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = _country.GetById((int)id);
            var countryViewModel = _mapper.Map<CountryViewModel>(country);
            if (country == null)
            {
                return NotFound();
            }
            var countryList = _country.GetCountries();
            ViewBag.Country = countryList;
            return View("Index", countryViewModel);
        }



        #endregion


    }
}