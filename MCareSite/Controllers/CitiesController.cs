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
using NToastNotify;

namespace NajmetAlraqeeSite.Controllers
{
    [Authorize]
    public class CitiesController : Controller
    {
        private readonly ICityRepository _city;
        private readonly ICountryRepository _country;
        private readonly IMapper  _mapper;
        private readonly IToastNotification _toastNotification;

        public CitiesController(ICityRepository city, IToastNotification toastNotification, IMapper mapper , ICountryRepository country )
        {
            _city = city;
            _mapper = mapper;
            _country = country;
            _toastNotification = toastNotification;
        }
       
        #region Index 
        public IActionResult Index(int? page)
        {
            var cityList = _city.GetCities();
            ViewBag.Cities = cityList;
            ViewBag.CountryId = new SelectList(_country.GetCountries(), "Id", "Name");
            return View();
        }
        #endregion




        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.CountryId = new SelectList(_country.GetCountries(), "Id", "Name");
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddPost(CityViewModel cityViewModel)
        {
            ViewBag.CountryId = new SelectList(_country.GetCountries(), "Id", "Name");
            var cityList = _city.GetCities();
            ViewBag.Cities = cityList;
            if (cityViewModel.CountryId == null) { ModelState.AddModelError("", "الرجاء ادخال البلد"); }
            if (cityViewModel.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("CountryId");
                if (ModelState.IsValid)
                {
                    var city = _mapper.Map<City>(cityViewModel);
                    _city.AddCity(city);
                    _toastNotification.AddSuccessToastMessage("تم أضافةالمدينة بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), cityViewModel);
            }
            else
            {
                ModelState.Remove("CountryId");
                if (ModelState.IsValid)
                {
                    var city = _mapper.Map<City>(cityViewModel);
                    _city.UpdateCity(cityViewModel.Id, city);
                    _toastNotification.AddSuccessToastMessage("تم تعديل المدينة بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), cityViewModel);
            }
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.CountryId = new SelectList(_country.GetCountries(), "Id", "Name");
            var city = _city.GetCityById((int)id);
            var cityViewModel = _mapper.Map<CityViewModel>(city);
            if (city == null)
            {
                return NotFound();
            }
            var cityList = _city.GetCities();
            ViewBag.Cities = cityList;
            return View("Index", cityViewModel);
        }

        //#region Delete

        public IActionResult Delete(int id)
        {
            _city.RemoveCity(id);
            _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            return RedirectToAction(nameof(Index));
        }

        //#endregion



    }
}