using System;
using System.Collections.Generic;
using System.Globalization;
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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace NajmetAlraqeeSite.Controllers
{
    [Authorize]
    public class HospitalOffersController : Controller
    {
        #region  Filed & Construct
        private readonly NajmetAlraqeeContext _context;
        private readonly IHospitalOfferRepository _hospitaloffer;
        private readonly IHospitalRepository _hospital;
        private readonly IHostingEnvironment _environment;
        private readonly IMapper _mapper;


        public HospitalOffersController(NajmetAlraqeeContext context, IHospitalOfferRepository hospitaloffer, IHostingEnvironment environment, IMapper mapper, IHospitalRepository hospital)
        {
            _context = context;
            _hospitaloffer = hospitaloffer;
            _environment = environment;
            _mapper = mapper;
            _hospital = hospital;
        }

        #endregion 

        #region Index
        public async Task<IActionResult> Index(int Id, string Search, DateTime? FromDate, DateTime? ToDate)
        {
            int? page = null;
            var hospitaloffer = _hospitaloffer.GetOffers().Where(x => x.HospitalId == Id).Include(x=>x.Hospital);
            if (FromDate != null && ToDate != null)
            {
                hospitaloffer = _hospitaloffer.GetOffers().Where(x => x.HappendOn > FromDate && x.EndOn <= ToDate).Include(x => x.Hospital);
            }
            else if (!string.IsNullOrEmpty(Search))
            { hospitaloffer = _hospitaloffer.GetOffers().Where(x => x.Hospital.EnglishName.Contains(Search) || x.Hospital.ArabicName.Contains(Search)).Include(x => x.Hospital); }
            else
            {
                hospitaloffer = _hospitaloffer.GetOffers().Include(x => x.Hospital);
            }
            if (hospitaloffer.Count() <= 10) { page = 1; }
            int pageSize = 10;
            ViewBag.HospitalId = Id;
            return View(await PaginatedList<HospitalOffer>.CreateAsync(hospitaloffer.AsNoTracking(), page ?? 1, pageSize));
        }
        public async Task<IActionResult> AllOfferIndex(string Search, DateTime? FromDate, DateTime? ToDate)
        {
            int? page = null;
            var hospitaloffer = _hospitaloffer.GetOffers().Include(x => x.Hospital);
            if (FromDate != null && ToDate != null)
            {
                hospitaloffer = _hospitaloffer.GetOffers().Where(x => x.HappendOn > FromDate && x.EndOn <= ToDate).Include(x => x.Hospital);
            }
            else if (!string.IsNullOrEmpty(Search))
            { hospitaloffer = _hospitaloffer.GetOffers().Where(x => x.Hospital.EnglishName.Contains(Search) || x.Hospital.ArabicName.Contains(Search)).Include(x => x.Hospital); }
            else
            {
                hospitaloffer = _hospitaloffer.GetOffers().Include(x => x.Hospital);
            }
            if (hospitaloffer.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View("Index", await PaginatedList<HospitalOffer>.CreateAsync(hospitaloffer.AsNoTracking(), page ?? 1, pageSize));
        }
        #endregion

        #region Details
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitaloffer = _hospitaloffer.GetOffer((long)id);
            var hospital = _hospital.GetHospital(hospitaloffer.HospitalId);

            var hospaitalofferviewmodels = _mapper.Map<HospitalOfferViewModel>(hospitaloffer);
            hospaitalofferviewmodels.CityName = hospital.City.EnglishName;
            hospaitalofferviewmodels.CountryName = hospital.Country.EnglishName;
            if (hospitaloffer == null)
            {
                return NotFound();
            }

            return View(hospaitalofferviewmodels);
        }
        #endregion 

        #region Add
        public IActionResult Add(int id)
        {
            HospitalOfferViewModel offerviewmodel = new HospitalOfferViewModel();
            offerviewmodel.HospitalId = id;
            var hospital = _hospital.GetHospital(id);
            if (hospital != null)
            {
                offerviewmodel.CountryName = hospital.Country.EnglishName;
                offerviewmodel.CityName = hospital.City.EnglishName;
            }
            offerviewmodel.HappendOn = DateTime.Now;
            offerviewmodel.EndOn = DateTime.Now.AddDays(7);

            return View(offerviewmodel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(HospitalOfferViewModel hospitalofferviewmodel)
        {
            hospitalofferviewmodel.CreatedOn = DateTime.Now.ToString();

            if (ModelState.IsValid)
            {
                string ArabicImagePathFileValue = null;
                string EnglishImagePathFileValue = null;
                if (hospitalofferviewmodel.ArabicImagePathFile.Length > 0)
                {
                    ArabicImagePathFileValue = await FileService.UploadFileAsync(hospitalofferviewmodel.ArabicImagePathFile, _environment);
                    EnglishImagePathFileValue = await FileService.UploadFileAsync(hospitalofferviewmodel.EnglishImagePathFile, _environment);
                    hospitalofferviewmodel.ArabicImagePath = ArabicImagePathFileValue;
                    hospitalofferviewmodel.EnglishImagePath = EnglishImagePathFileValue;

                    var hospitaloffer = _mapper.Map<HospitalOffer>(hospitalofferviewmodel);
                    _hospitaloffer.AddOffer(hospitaloffer);
                    return RedirectToAction(nameof(Index), new { Id = hospitalofferviewmodel.HospitalId });
                }
                else
                {
                    ModelState.AddModelError("", "Please Insert Hospital Offer Image ");
                }
            }
            return View("Add", hospitalofferviewmodel);
        }

        #endregion

        #region Edit
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var hospitaloffer = _hospitaloffer.GetOffer((long)id);
            var hospaitofferviewmodel = _mapper.Map<HospitalOfferViewModel>(hospitaloffer);
            hospaitofferviewmodel.CityName = hospitaloffer.Hospital.City.EnglishName;
            hospaitofferviewmodel.CountryName = hospitaloffer.Hospital.Country.EnglishName;
            if (hospitaloffer == null)
            {
                return NotFound();
            }

            return View(hospaitofferviewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(long id, HospitalOfferViewModel hospitalofferviewmodel)
        {
            if (id != hospitalofferviewmodel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string ArabicImagePathFileValue = null;
                string EnglishImagePathFileValue = null;
                if (hospitalofferviewmodel.ArabicImagePathFile.Length > 0)
                {
                    ArabicImagePathFileValue = await FileService.UploadFileAsync(hospitalofferviewmodel.ArabicImagePathFile, _environment);
                    EnglishImagePathFileValue = await FileService.UploadFileAsync(hospitalofferviewmodel.EnglishImagePathFile, _environment);
                    hospitalofferviewmodel.ArabicImagePath = ArabicImagePathFileValue;
                    hospitalofferviewmodel.EnglishImagePath = EnglishImagePathFileValue;
                    var hospitaloffer = _mapper.Map<HospitalOffer>(hospitalofferviewmodel);
                    _context.Update(hospitaloffer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else { ModelState.AddModelError("", "Please Insert Hospital Image "); }
            }
            return View(hospitalofferviewmodel);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitaloffer = _hospitaloffer.GetOffer((long)id);
            var hospaitalofferviewmodels = _mapper.Map<HospitalOfferViewModel>(hospitaloffer);
            if (hospitaloffer == null)
            {
                return NotFound();
            }

            return View(hospaitalofferviewmodels);
        }

        // POST: Hospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            _hospitaloffer.RemoveHospitalOffer(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        private bool HospitalOfferExists(long id)
        {
            return _context.HospitalOffers.Any(e => e.Id == id);
        }
    }
}