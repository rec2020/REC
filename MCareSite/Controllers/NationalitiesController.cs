using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.ViewModels;
using NajmetAlraqee.Site.Services;
using NajmetAlraqee.Data.Entities;
using NToastNotify;
using Microsoft.AspNetCore.Authorization;
//using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    [Authorize]
    public class NationalitiesController : Controller
    {
        private readonly NajmetAlraqeeContext _context;
        private readonly INationalityRepository _nationality;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        public NationalitiesController(NajmetAlraqeeContext context, INationalityRepository nationality, IMapper mapper, IToastNotification toastNotification)
        {
            _context = context;
            _nationality = nationality;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        #region Index 
        public IActionResult Index(int? page)
        {
            var nationality = _nationality.GetNationalities();
            ViewBag.Nationality = nationality;

            //if (nationality.Count() <= 10) { page = 1; }
            //int pageSize = 10;
            return View();
        }
        #endregion

        #region Details
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = _nationality.GetNationality((long)id);
            var nationalityviewModels = _mapper.Map<NationalityViewModel>(nationality);
            if (nationalityviewModels == null)
            {
                return NotFound();
            }

            return View(nationalityviewModels);
        }
        #endregion


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddPost(NationalityViewModel nationalityViewModel)
        {
            var nationalityList = _nationality.GetNationalities();
            ViewBag.Nationality = nationalityList;
            if (nationalityViewModel.Id == 0)
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    var nationality = _mapper.Map<Nationality>(nationalityViewModel);
                    _nationality.AddNationality(nationality);
                    _toastNotification.AddSuccessToastMessage("تم أضافةالجنسية بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), nationalityViewModel);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var nationality = _mapper.Map<Nationality>(nationalityViewModel);
                    _nationality.UpdateNationality(nationalityViewModel.Id, nationality);
                    _toastNotification.AddSuccessToastMessage("تم تعديل الجنسية بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), nationalityViewModel);
            }

        }
        //return View("Index",NationalityViewModel);




        #region Edit
        // GET: Doctors1/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = _nationality.GetNationality((int)id);
            var nationalityViewModel = _mapper.Map<NationalityViewModel>(nationality);
            if (nationality == null)
            {
                return NotFound();
            }
            var nationalityList = _nationality.GetNationalities();
            ViewBag.Nationality = nationalityList;
            return View("Index", nationalityViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, NationalityViewModel nationalityViewModel)
        {
            if (id != nationalityViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var nationality = _mapper.Map<Nationality>(nationalityViewModel);
                    _context.Update(nationality);
                     _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NationalityExists(nationalityViewModel.Id))
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
            return View(nationalityViewModel);
        }
        #endregion

        #region Delete

        public IActionResult Delete(long id)
        {
            _nationality.RemoveNationality(id);
            _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion


        private bool NationalityExists(long id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}