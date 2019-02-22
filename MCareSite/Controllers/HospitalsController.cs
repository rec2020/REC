using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using NajmetAlraqeeSite.Data;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data;
using NajmetAlraqee.Site.ViewModels;
using NajmetAlraqee.Data.Repositories;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using NajmetAlraqee.Site.Services;
using Microsoft.AspNetCore.Authorization;
using NajmetAlraqeeSite.Services;

namespace NajmetAlraqeeSite.Controllers
{   /* [Authorize ( Roles ="")]*/
    [Authorize]
    public class HospitalsController : BaseController
    {
        #region  Filed & Construct
        private readonly NajmetAlraqeeContext _context;
        private readonly IHospitalRepository _hospital;
        private readonly IHospitalOfferRepository _offer;
        private readonly IHostingEnvironment _environment;
        private readonly IMapper _mapper;


        public HospitalsController(NajmetAlraqeeContext context, IHospitalRepository hospital, IHostingEnvironment environment, IMapper mapper, IHospitalOfferRepository offer)
        {
            _context = context;
            _hospital = hospital;
            _environment = environment;
            _mapper = mapper;
            _offer =offer;
        }

        #endregion 

        #region Index
        public async Task<IActionResult> Index(int? page, string SearchString)
        {
            var hospital = _hospital.GetHospitals();
            if (SearchString != null)
            {
                hospital = _hospital.GetHospitals().Where(x => x.EnglishName.Contains(SearchString));
            }
            else
            {
                hospital = _hospital.GetHospitals();
            }
            if (hospital.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View(await PaginatedList<Hospital>.CreateAsync(hospital.AsNoTracking(), page ?? 1, pageSize));
        }
        #endregion

        #region Details
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospital = _hospital.GetHospital((long)id);
            var hospaitalviewmodels = _mapper.Map<HospitalViewModel>(hospital);
            hospaitalviewmodels.CountryName = hospital.Country.EnglishName;
            hospaitalviewmodels.cityName = hospital.City.EnglishName;
            hospaitalviewmodels.HospitalTypeName = hospital.HospitalType.EnglishName;
            if (hospital == null)
            {
                return NotFound();
            }
            ViewBag.Offers = _context.HospitalOffers.Where(x => x.HospitalId == id).ToList();
            return View(hospaitalviewmodels);
        }
        #endregion 

        #region Add
        public IActionResult Add()
        {
            
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "EnglishName");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "EnglishName");
            ViewData["HospitalTypeId"] = new SelectList(_context.HospitalTypes, "Id", "EnglishName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(HospitalViewModel hospitalviewmodel)
        {
            ModelState.Remove("HospitalTypeId");
            ModelState.Remove("CountryId");
            ModelState.Remove("CityId");
            if (hospitalviewmodel.HospitalTypeId == null) { ModelState.AddModelError("", "Please Insert Hospital Type"); }
            if (hospitalviewmodel.CountryId == null) { ModelState.AddModelError("", "Please Insert country "); }
            if (hospitalviewmodel.CityId == null) { ModelState.AddModelError("", "Please Insert city "); }
            if (ModelState.IsValid)
            {
                string ImagePathFileValue = null;
                string LogoPathFileValue = null;
                if (hospitalviewmodel.ImagePathFile.Length > 0 && hospitalviewmodel.LogoPathFile.Length > 0)
                {
                    ImagePathFileValue = await FileService.UploadFileAsync(hospitalviewmodel.ImagePathFile, _environment);
                    LogoPathFileValue = await FileService.UploadFileAsync(hospitalviewmodel.LogoPathFile, _environment);

                    hospitalviewmodel.ImagePath = ImagePathFileValue;
                    hospitalviewmodel.LogoPath = LogoPathFileValue;
                    var hospait = _mapper.Map<Hospital>(hospitalviewmodel);
                    _hospital.AddHospital(hospait);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Please Insert Hospital Image And Logo ");
                }
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "EnglishName");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "EnglishName");
            ViewData["HospitalTypeId"] = new SelectList(_context.HospitalTypes, "Id", "EnglishName");
            return View(hospitalviewmodel);
        }

        #endregion

        #region Edit
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var hospital = await _context.Hospitals.SingleOrDefaultAsync(m => m.Id == id);
            var hospaitviewmodel = _mapper.Map<HospitalViewModel>(hospital);
            if (hospital == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "EnglishName", hospaitviewmodel.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "EnglishName", hospaitviewmodel.CountryId);
            ViewData["HospitalTypeId"] = new SelectList(_context.HospitalTypes, "Id", "EnglishName", hospaitviewmodel.HospitalTypeId);
            return View(hospaitviewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, HospitalViewModel hospitalviewmodel)
        {
            if (id != hospitalviewmodel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string ImagePathFileValue = null;
                string LogoPathFileValue = null;
                if (hospitalviewmodel.ImagePathFile.Length > 0 && hospitalviewmodel.LogoPathFile.Length > 0)
                {
                    ImagePathFileValue = await FileService.UploadFileAsync(hospitalviewmodel.ImagePathFile, _environment);
                    LogoPathFileValue = await FileService.UploadFileAsync(hospitalviewmodel.LogoPathFile, _environment);

                    hospitalviewmodel.ImagePath = ImagePathFileValue;
                    hospitalviewmodel.LogoPath = LogoPathFileValue;
                    var hospital = _mapper.Map<Hospital>(hospitalviewmodel);
                    _context.Update(hospital);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else { ModelState.AddModelError("", "Please Insert Hospital Image And Logo "); }
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "EnglishName", hospitalviewmodel.CityId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "EnglishName", hospitalviewmodel.CountryId);
            ViewData["HospitalTypeId"] = new SelectList(_context.HospitalTypes, "Id", "EnglishName", hospitalviewmodel.HospitalTypeId);
            return View(hospitalviewmodel);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospital = _hospital.GetHospital((long)id);
            var hospaitalviewmodels = _mapper.Map<HospitalViewModel>(hospital);
            if (hospital == null)
            {
                return NotFound();
            }

            return View(hospaitalviewmodels);
        }

        // POST: Hospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            _hospital.RemoveHospital(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        private bool HospitalExists(long id)
        {
            return _context.Hospitals.Any(e => e.Id == id);
        }
    }
}
