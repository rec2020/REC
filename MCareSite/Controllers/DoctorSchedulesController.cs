using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Site.Services;
using Microsoft.AspNetCore.Authorization;
using NajmetAlraqee.Data.Constants;

namespace NajmetAlraqeeSite.Controllers
{
    [Authorize]
    public class DoctorSchedulesController : Controller
    {
        private readonly NajmetAlraqeeContext _context;

        public DoctorSchedulesController(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        // GET: DoctorSchedules
        public async Task<IActionResult> Index(int? page, string Search, DateTime? FromDate, DateTime? ToDate)
        {
            var doctorSchedules = _context.DoctorSchedules.Include(d => d.Doctor).Include(d => d.Hospital).Include(d => d.ScheduleStatus);
            if (FromDate != null && ToDate != null)
            {
                doctorSchedules = _context.DoctorSchedules.Where(x => x.Date>=FromDate && x.Date <= ToDate).Include(x => x.Doctor).Include(x => x.Hospital).Include(x => x.ScheduleStatus);
            }
            else if (!string.IsNullOrEmpty(Search))
            {
                doctorSchedules = _context.DoctorSchedules.Where(x => x.Doctor.ArabicName.Contains(Search) || x.Doctor.EnglishName.Contains(Search)).Include(x => x.Doctor).Include(x => x.Hospital).Include(x => x.ScheduleStatus);
            }
            else
            {
                doctorSchedules = _context.DoctorSchedules.Include(d => d.Doctor).Include(d => d.Hospital).Include(d => d.ScheduleStatus);
            }
            if (doctorSchedules.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View(await PaginatedList<DoctorSchedule>.CreateAsync(doctorSchedules.AsNoTracking(), page ?? 1, pageSize));
        }
        public async Task<IActionResult> HospitalDoctorSchedule(int? page, string Search, DateTime? FromDate, DateTime? ToDate)
        {
            var username = User.Identity.Name;
            string useridentity = _context.Users.Where(x => x.UserName.Contains(username)).SingleOrDefault().Id;
            var Get = _context.Doctors.Where(x => x.UserId.Contains(useridentity)).SingleOrDefault();
            var doctorSchedules = _context.DoctorSchedules.Include(d => d.Doctor).Include(d => d.Hospital).Include(d => d.ScheduleStatus).Where(x => x.HospitalId == Get.HospitalId);
            if (FromDate != null && ToDate != null)
            {
                doctorSchedules = doctorSchedules.Where(x => x.Date >= FromDate && x.Date <= ToDate).Include(x => x.Doctor).Include(x => x.Hospital).Include(x => x.ScheduleStatus);
            }
            else if (!string.IsNullOrEmpty(Search))
            {
                doctorSchedules = doctorSchedules.Where(x => x.Doctor.ArabicName.Contains(Search) || x.Doctor.EnglishName.Contains(Search)).Include(x => x.Doctor).Include(x => x.Hospital).Include(x => x.ScheduleStatus);
            }
            else
            {
                doctorSchedules = _context.DoctorSchedules.Include(d => d.Doctor).Include(d => d.Hospital).Include(d => d.ScheduleStatus).Where(x => x.HospitalId == Get.HospitalId);
            }
            if (doctorSchedules.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View("Index", await PaginatedList<DoctorSchedule>.CreateAsync(doctorSchedules.AsNoTracking(), page ?? 1, pageSize));
        }
        public async Task<IActionResult> Activate(long id)
        {
            var schedule = await _context.DoctorSchedules.SingleOrDefaultAsync(m => m.Id == id);
            schedule.ScheduleStatusId = (long)ScheduleStatusEnum.Booked;
            _context.DoctorSchedules.Update(schedule);
            await _context.SaveChangesAsync();
            if (User.IsInRole("Hospital")) { return RedirectToAction(nameof(HospitalDoctorSchedule)); } else { return RedirectToAction(nameof(Index)); }
        }
        public async Task<IActionResult> Deactivate(long id)
        {
            var schedule = await _context.DoctorSchedules.SingleOrDefaultAsync(m => m.Id == id);
            schedule.ScheduleStatusId = (long)ScheduleStatusEnum.NotAllowed;
            _context.DoctorSchedules.Update(schedule);
            await _context.SaveChangesAsync();
            if (User.IsInRole("Hospital")) { return RedirectToAction(nameof(HospitalDoctorSchedule)); } else { return RedirectToAction(nameof(Index)); }
        }
    }
}
