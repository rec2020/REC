using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.Services;
using NajmetAlraqeeSite.ViewModels;
using NajmetAlraqee.Data.Constants;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using IdentityServer4.Extensions;

namespace NajmetAlraqeeSite.Controllers
{
    [Authorize]
    public class DoctorVacationsController : Controller
    {
        private readonly NajmetAlraqeeContext _context;
        private readonly IDoctorVacationRepository _vacation;
        private readonly IMapper _mapper;

        public DoctorVacationsController(NajmetAlraqeeContext context, IDoctorVacationRepository vacation, IMapper mapper)
        {
            _context = context;
            _vacation = vacation;
            _mapper = mapper;
        }


        #region Index 
        public async Task<IActionResult> Index(int? page, string Search, DateTime? FromDate, DateTime? ToDate)
        {
            var vacation = _vacation.GetDoctorVacation();
            if (FromDate != null && ToDate != null)
            {
                vacation = _vacation.GetDoctorVacation().Where(x => x.StartingOn > FromDate && x.EndingOn <= ToDate);
            }
            else if (!string.IsNullOrEmpty(Search))
            { vacation = _vacation.GetDoctorVacation().Where(x => x.Doctor.EnglishName.Contains(Search) || x.Doctor.ArabicName.Contains(Search)); }
            else
            {
                vacation = _vacation.GetDoctorVacation();
            }
            ViewBag.FromDate = DateTime.Now;
            ViewBag.ToDate = DateTime.Now.AddMonths(1);
            if (vacation.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View(await PaginatedList<DoctorVacation>.CreateAsync(vacation.AsNoTracking(), page ?? 1, pageSize));
        }

        public async Task<IActionResult> MyVacation(int? page, string Search, DateTime? FromDate, DateTime? ToDate)
        {
            var currentDoctor = User.Identity.Name;
            var getdoctorId = _context.Users.Where(x => x.UserName.Contains(currentDoctor)).SingleOrDefault();
            var vacation = _vacation.GetDoctorVacation().Where(x => x.Doctor.UserId.Contains(getdoctorId.Id));
            if (FromDate != null && ToDate != null)
            {
                vacation = vacation.Where(x => x.StartingOn > FromDate && x.EndingOn <= ToDate);
            }
            else if (!string.IsNullOrEmpty(Search))
            { vacation = _vacation.GetDoctorVacation().Where(x => x.Doctor.EnglishName.Contains(Search) || x.Doctor.ArabicName.Contains(Search)); }
            else
            {
                vacation = _vacation.GetDoctorVacation().Where(x => x.Doctor.UserId.Contains(getdoctorId.Id));
            }
            ViewBag.FromDate = DateTime.Now.ToString("mm/dd/yyyy");
            ViewBag.ToDate = DateTime.Now.AddMonths(1).ToString("mm/dd/yyyy");
            if (vacation.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View("Index", await PaginatedList<DoctorVacation>.CreateAsync(vacation.AsNoTracking(), page ?? 1, pageSize));
        }
        public async Task<IActionResult> HospitalVacationIndex(int? page, string Search, DateTime? FromDate, DateTime? ToDate)
        {
            var username = User.Identity.Name;
            string useridentity = _context.Users.Where(x => x.UserName.Contains(username)).SingleOrDefault().Id;
            var Get = _context.Doctors.Where(x => x.UserId.Contains(useridentity)).SingleOrDefault();
            var vacation = _vacation.GetDoctorVacation().Where(x => x.HospitalId == Get.HospitalId);
            if (FromDate != null && ToDate != null)
            {
                vacation = vacation.Where(x => x.StartingOn > FromDate && x.EndingOn <= ToDate);
            }
            else if (!string.IsNullOrEmpty(Search))
            { vacation = _vacation.GetDoctorVacation().Where(x => x.Doctor.EnglishName.Contains(Search) || x.Doctor.ArabicName.Contains(Search)); }
            else
            {
                vacation = _vacation.GetDoctorVacation().Where(x => x.HospitalId == Get.HospitalId);
            }
            ViewBag.FromDate = DateTime.Now.ToString("mm/dd/yyyy");
            ViewBag.ToDate = DateTime.Now.AddMonths(1).ToString("mm/dd/yyyy");
            if (vacation.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View("Index", await PaginatedList<DoctorVacation>.CreateAsync(vacation.AsNoTracking(), page ?? 1, pageSize));
        }
        #endregion


        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorVacation = await _context.DoctorVacations
                .Include(d => d.Doctor)
                .Include(d => d.Hospital)
                .Include(d => d.VacationStatus)
                .Include(d => d.VacationType)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (doctorVacation == null)
            {
                return NotFound();
            }

            return View(doctorVacation);
        }

        // GET: DoctorVacations/Create
        public IActionResult Add(int DoctorId)
        {
            var doctor = _context.Doctors.Where(x => x.Id == DoctorId).SingleOrDefault();
            var hospital = _context.Hospitals.Where(x => x.Id == doctor.HospitalId).SingleOrDefault();
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "Id", "EnglishName");

            DoctorVacationViewModel doctorVacationviewmodel = new DoctorVacationViewModel();
            doctorVacationviewmodel.HospitalId = doctor.HospitalId;
            doctorVacationviewmodel.HospitalName = hospital.EnglishName;
            doctorVacationviewmodel.DoctorId = DoctorId;
            doctorVacationviewmodel.StartingOn = DateTime.Now;
            doctorVacationviewmodel.EndingOn = DateTime.Now;
            doctorVacationviewmodel.VacationStatusId = (long)VacationStatusEnum.Pending;
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "Id", "EnglishName");
            ViewData["VacationTypeId"] = new SelectList(_context.VacationTypes, "Id", "EnglishName");
            return View(doctorVacationviewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(DoctorVacationViewModel doctorVacationviewmodel)
        {
            if (doctorVacationviewmodel.EndingOn.Date < doctorVacationviewmodel.StartingOn.Date)
            {
                ModelState.AddModelError("", "Please Make Sure End Date greater than start Date");
            }
            if (ModelState.IsValid)
            {
                doctorVacationviewmodel.CreatedOn = DateTime.Now;
                var vacation = _mapper.Map<DoctorVacation>(doctorVacationviewmodel);
                _context.Add(vacation);
                await _context.SaveChangesAsync();
                if (User.IsInRole("Hospital")) { return RedirectToAction(nameof(HospitalVacationIndex)); }
                else if (User.IsInRole("Doctor")) { return RedirectToAction(nameof(MyVacation)); }
                else { return RedirectToAction(nameof(Index)); }
            }
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "Id", "EnglishName", doctorVacationviewmodel.HospitalId);
            ViewData["VacationTypeId"] = new SelectList(_context.VacationTypes, "Id", "EnglishName", doctorVacationviewmodel.VacationTypeId);
            return View(doctorVacationviewmodel);
        }


        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorVacation = _vacation.GetDoctorVacation((long)id);
            var vacationviewmodel = _mapper.Map<DoctorVacationViewModel>(doctorVacation);
            if (doctorVacation == null)
            {
                return NotFound();
            }

            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "Id", "EnglishName", vacationviewmodel.HospitalId);
            ViewData["VacationTypeId"] = new SelectList(_context.VacationTypes, "Id", "EnglishName", vacationviewmodel.VacationTypeId);
            return View(vacationviewmodel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, DoctorVacationViewModel doctorVacationViewmodel)
        {
            if (id != doctorVacationViewmodel.Id)
            {
                return NotFound();
            }
            if (doctorVacationViewmodel.EndingOn.Date < doctorVacationViewmodel.StartingOn.Date)
            {
                ModelState.AddModelError("", "Please Make Sure End Date greater than start Date");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    doctorVacationViewmodel.CreatedOn = DateTime.Now;
                    var vacation = _mapper.Map<DoctorVacation>(doctorVacationViewmodel);
                    _context.Update(vacation);
                    await _context.SaveChangesAsync();
                    if (doctorVacationViewmodel.VacationStatusId == (long)VacationStatusEnum.Accepted)
                    {
                        //
                        var doctorSchedule = _context.DoctorSchedules.Where(x => x.Date.Month >= doctorVacationViewmodel.StartingOn.Month && x.Date.Month <= doctorVacationViewmodel.EndingOn.Month).ToList();
                        foreach (var item in doctorSchedule)
                        {
                            item.ScheduleStatusId = (long)ScheduleStatusEnum.Vaction;
                            _context.DoctorSchedules.Update(item);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorVacationExists(doctorVacationViewmodel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (User.IsInRole("Hospital")) { return RedirectToAction(nameof(HospitalVacationIndex)); } else { return RedirectToAction(nameof(Index)); }
            }
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "Id", "EnglishName", doctorVacationViewmodel.HospitalId);
            ViewData["VacationTypeId"] = new SelectList(_context.VacationTypes, "Id", "EnglishName", doctorVacationViewmodel.VacationTypeId);
            return View(doctorVacationViewmodel);
        }


        public async Task<IActionResult> Delete(long id)
        {
            var doctorVacation = await _context.DoctorVacations.SingleOrDefaultAsync(m => m.Id == id);
            _context.DoctorVacations.Remove(doctorVacation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Approve(long id)
        {
            var doctorVacation = await _context.DoctorVacations.SingleOrDefaultAsync(m => m.Id == id);
            doctorVacation.VacationStatusId = (long)VacationStatusEnum.Accepted;
            _context.DoctorVacations.Update(doctorVacation);
            await _context.SaveChangesAsync();
            //
          var doctorschedule = _context.DoctorSchedules.Where(x => x.DoctorId == doctorVacation.DoctorId && x.Date >= doctorVacation.StartingOn && x.Date <= doctorVacation.EndingOn).ToList();
            if (doctorschedule.Count()>0)
            {

                foreach (var item in doctorschedule)
                {
                    item.ScheduleStatusId = (long)ScheduleStatusEnum.Vaction;
                    _context.DoctorSchedules.Update(item);
                    await _context.SaveChangesAsync();
                }
            }

            if (User.IsInRole("Hospital")) { return RedirectToAction(nameof(HospitalVacationIndex)); } else { return RedirectToAction(nameof(Index)); }
        }
        public async Task<IActionResult> Rject(long id)
        {
            var doctorVacation = await _context.DoctorVacations.SingleOrDefaultAsync(m => m.Id == id);
            doctorVacation.VacationStatusId = (long)VacationStatusEnum.Rejected;
            _context.DoctorVacations.Update(doctorVacation);
            await _context.SaveChangesAsync();
            if (User.IsInRole("Hospital")) { return RedirectToAction(nameof(HospitalVacationIndex)); } else { return RedirectToAction(nameof(Index)); }
        }
        private bool DoctorVacationExists(long id)
        {
            return _context.DoctorVacations.Any(e => e.Id == id);
        }
    }
}
