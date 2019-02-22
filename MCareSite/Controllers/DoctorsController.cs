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
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.Services;
using NajmetAlraqee.Site.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using NajmetAlraqeeSite.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace NajmetAlraqeeSite.Controllers
{
    [Authorize]
    public class DoctorsController : Controller
    {
        private readonly NajmetAlraqeeContext _context;
        private readonly IDoctorRepository _doctor;
        private readonly IHostingEnvironment _environment;
        private readonly IMapper _mapper;
        private readonly IDoctorLanguageRepository _language;
        private readonly IDoctorSpecialtyRepository _speaclist;
        private readonly IDoctorEducationLevelRepository _education;
      

        public DoctorsController(NajmetAlraqeeContext context, IDoctorRepository doctor, IHostingEnvironment environment, IMapper mapper , IDoctorLanguageRepository language , IDoctorSpecialtyRepository speaclist, IDoctorEducationLevelRepository education)
        {
            _context = context;
            _doctor = doctor;
            _environment = environment;
            _mapper = mapper;
            _language = language;
            _speaclist = speaclist;
            _education = education;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page,string SearchString)
        {
            var doctor = _doctor.GetDoctors();
            if (SearchString != null)
            {
                 doctor = _doctor.GetDoctors().Where(x => x.EnglishName.Contains(SearchString));
            }
            else
            {
                 doctor = _doctor.GetDoctors();
            }
           
            if (doctor.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View(await PaginatedList<Doctor>.CreateAsync(doctor.AsNoTracking(), page ?? 1, pageSize));
        }


        public async Task<IActionResult> HospitalDoctorIndex(int? page)
        {
            var username = User.Identity.Name;
            string useridentity = _context.Users.Where(x => x.UserName.Contains(username)).SingleOrDefault().Id;
            var Get = _context.Doctors.Where(x => x.UserId.Contains(useridentity)).SingleOrDefault();
            var doctor = _doctor.GetDoctors().Where(x=>x.HospitalId==Get.HospitalId);
            if (doctor.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View("Index",await PaginatedList<Doctor>.CreateAsync(doctor.AsNoTracking(), page ?? 1, pageSize));
        }
        #endregion 

        #region Details
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = _doctor.GetDoctor((long)id);

            var doctorviewmodel = _mapper.Map<DoctorViewModel>(doctor);
            doctorviewmodel.ImagePath = doctor.ImagePath;
            doctorviewmodel.CVPath = doctor.ArabicCVPath;
            doctorviewmodel.GenderName = doctor.Gender.EnglishName;
            doctorviewmodel.NationalityName = doctor.Nationality.Name;
            doctorviewmodel.UserName = doctor.User.UserName;
            doctorviewmodel.HospitalName = doctor.Hospital.EnglishName;
            if (doctor == null)
            {
                return NotFound();
            }
            ViewBag.language = _language.GetDoctorLanguages((long)id);
            ViewBag.Speacialist = _speaclist.GetDoctorSpecialties((long)id);
            ViewBag.EducationLevel =_education.GetDoctorEducationLevels((long)id);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "Id", "EnglishName");
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "EnglishName");
            ViewData["EducationLevelId"] = new SelectList(_context.EducationLevels, "Id", "EnglishName");
            return View(doctorviewmodel);
        }

        public async Task<IActionResult> Profile(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = _doctor.GetDoctors().Where(x=>x.User.Email.Contains(id)).SingleOrDefault();

            var doctorviewmodel = _mapper.Map<DoctorViewModel>(doctor);
            doctorviewmodel.ImagePath = doctor.ImagePath;
            doctorviewmodel.CVPath = doctor.ArabicCVPath;
            doctorviewmodel.GenderName = doctor.Gender.EnglishName;
            doctorviewmodel.NationalityName = doctor.Nationality.Name;
            doctorviewmodel.UserName = doctor.User.UserName;
            doctorviewmodel.HospitalName = doctor.Hospital.EnglishName;
            if (doctor == null)
            {
                return NotFound();
            }
            ViewBag.language = _language.GetDoctorLanguages((long)doctor.Id);
            ViewBag.Speacialist = _speaclist.GetDoctorSpecialties((long)doctor.Id);
            ViewBag.EducationLevel = _education.GetDoctorEducationLevels((long)doctor.Id);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialties, "Id", "EnglishName");
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "EnglishName");
            ViewData["EducationLevelId"] = new SelectList(_context.EducationLevels, "Id", "EnglishName");
            return View("Details",doctorviewmodel);
        }
        #endregion


        [HttpGet]
        public IActionResult Add()
        {
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "EnglishName");
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "Id", "EnglishName");
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "EnglishName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName", "Select Doctor");
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(DoctorViewModel doctorviewmodel)
        {
            if (ModelState.IsValid)
            {
                string imagepathValue = null;
                string CVPathFileValue = null;
                if (doctorviewmodel.ImagePathFile.Length > 0 && doctorviewmodel.CVPathFile.Length > 0)
                {
                    imagepathValue = await FileService.UploadFileAsync(doctorviewmodel.ImagePathFile, _environment);
                    CVPathFileValue = await FileService.UploadFileAsync(doctorviewmodel.CVPathFile, _environment);

                    doctorviewmodel.ImagePath = imagepathValue;
                    doctorviewmodel.CVPath = CVPathFileValue;
                    var doctor = _mapper.Map<Doctor>(doctorviewmodel);
                    doctor.ArabicCVPath = doctorviewmodel.CVPath;
                    doctor.EnglishCVPath = doctorviewmodel.CVPath;
                    _doctor.AddDoctor(doctor);
                    if (User.IsInRole("Hospital")) { return RedirectToAction(nameof(HospitalDoctorIndex)); } else { return RedirectToAction(nameof(Index)); }
                }
                else
                {
                    ModelState.AddModelError("", "Please Insert Doctor Image And Cv ");
                }
            }
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "EnglishName");
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "Id", "EnglishName");
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "EnglishName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");
            return View(doctorviewmodel);
        }



        #region Edit
        // GET: Doctors1/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors.SingleOrDefaultAsync(m => m.Id == id);
            var doctorviewmodel = _mapper.Map<DoctorViewModel>(doctor);
            doctorviewmodel.CVPath = doctor.ArabicCVPath;
            if (doctorviewmodel == null)
            {
                return NotFound();
            }
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "EnglishName", doctorviewmodel.GenderId);
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "Id", "EnglishName", doctorviewmodel.HospitalId);
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "EnglishName", doctorviewmodel.NationalityId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName", doctorviewmodel.UserId);
            return View(doctorviewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, DoctorViewModel doctorviewmodel)
        {
            if (ModelState.IsValid)
            {

                string imagepathValue = null;
                string CVPathFileValue = null;
                if (doctorviewmodel.ImagePathFile.Length > 0 && doctorviewmodel.CVPathFile.Length > 0)
                {
                    imagepathValue = await FileService.UploadFileAsync(doctorviewmodel.ImagePathFile, _environment);
                    CVPathFileValue = await FileService.UploadFileAsync(doctorviewmodel.ImagePathFile, _environment);

                    doctorviewmodel.ImagePath = imagepathValue;
                    doctorviewmodel.CVPath = CVPathFileValue;
                    var doctor = _mapper.Map<Doctor>(doctorviewmodel);
                    doctor.ArabicCVPath = doctorviewmodel.CVPath;
                    doctor.EnglishCVPath = doctorviewmodel.CVPath;
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                    var email = _context.Users.Where(x => x.Id == doctorviewmodel.UserId).SingleOrDefault();
                    if (User.IsInRole("Hospital")) { return RedirectToAction(nameof(HospitalDoctorIndex)); }
                    else if (User.IsInRole("Doctor")) { return RedirectToAction("Profile", "Doctors", new { id = email.Email }); }
                    else { return RedirectToAction(nameof(Index)); }
                }
                else
                {
                    ModelState.AddModelError("", "Please Insert Doctor Image And Cv ");
                }
            }
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "EnglishName", doctorviewmodel.GenderId);
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "Id", "EnglishName", doctorviewmodel.HospitalId);
            ViewData["NationalityId"] = new SelectList(_context.Nationalities, "Id", "EnglishName", doctorviewmodel.NationalityId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName", doctorviewmodel.UserId);
            return View(doctorviewmodel);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = _doctor.GetDoctor((long)id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            _doctor.RemoveDoctor(id);
            //var doctor = await _context.Doctors.SingleOrDefaultAsync(m => m.Id == id);
            //_context.Doctors.Remove(doctor);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion 


        private bool DoctorExists(long id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }


        
        public async Task<IActionResult> RemoveLanguage(long id)
        {
            var doctorlanguage = await _context.DoctorLanguages.SingleOrDefaultAsync(m => m.Id == id);

            if (doctorlanguage !=null )
            {
                _context.DoctorLanguages.Remove(doctorlanguage);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Details), "Doctors", new { id = doctorlanguage.DoctorId });
        }
        public async Task<IActionResult> Removespeaclist(long id)
        {
           
            var doctorspeaclist = await _context.DoctorSpecialties.SingleOrDefaultAsync(m => m.Id == id);
            if (doctorspeaclist != null)
            {
                _context.DoctorSpecialties.Remove(doctorspeaclist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Doctors", new { id = doctorspeaclist.DoctorId });
            }
            return RedirectToAction(nameof(Details), "Doctors", new { id = doctorspeaclist.DoctorId });
        }
        public async Task<IActionResult> RemoveEducationlevel(long id)
        {
            var doctorseducationlevel = await _context.DoctorEducationLevels.SingleOrDefaultAsync(m => m.Id == id);
            if (doctorseducationlevel != null)
            {
                _context.DoctorEducationLevels.Remove(doctorseducationlevel);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Details), "Doctors", new { id = doctorseducationlevel.DoctorId });
        }
    }
}
