using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Entities;
using AutoMapper;
using NajmetAlraqee.Site.Services;
using NajmetAlraqee.Site.ViewModels;
using NajmetAlraqee.Data.Constants;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace NajmetAlraqeeSite.Controllers
{
    [Authorize]
    public class DoctorScheduleConfigurationsController : Controller
    {
        private readonly NajmetAlraqeeContext _context;
        private readonly IMapper _mapper;
        public DoctorScheduleConfigurationsController(NajmetAlraqeeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Index
        public async Task<IActionResult> Index(int? page, string Search, DateTime? FromDate, DateTime? ToDate)
        {
            var doctorconfiguration = _context.DoctorScheduleConfigurations.Include(d => d.Doctor).Include(d => d.Hospital);
            if (FromDate != null && ToDate != null)
            {
                doctorconfiguration = doctorconfiguration.Where(x => x.StartOn > FromDate && x.EndOn <= ToDate).Include(d => d.Doctor).Include(d => d.Hospital);
            }
            else if (!string.IsNullOrEmpty(Search))
            {
                doctorconfiguration = doctorconfiguration.Where(x => x.Doctor.EnglishName.Contains(Search) || x.Doctor.ArabicName.Contains(Search)).Include(d => d.Doctor).Include(d => d.Hospital);
            }
            else
            {
                doctorconfiguration = _context.DoctorScheduleConfigurations.Include(d => d.Doctor).Include(d => d.Hospital);
            }
            if (doctorconfiguration.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View(await PaginatedList<DoctorScheduleConfiguration>.CreateAsync(doctorconfiguration.AsNoTracking(), page ?? 1, pageSize));
        }

        public async Task<IActionResult> HospitalDoctorScheduleConfigurations(int? page)
        {
            var username = User.Identity.Name;
            string useridentity = _context.Users.Where(x => x.UserName.Contains(username)).SingleOrDefault().Id;
            var Get = _context.Doctors.Where(x => x.UserId.Contains(useridentity)).SingleOrDefault();
            var doctorconfiguration = _context.DoctorScheduleConfigurations.Include(d => d.Doctor).Include(d => d.Hospital).Where(x => x.HospitalId == Get.HospitalId);
            if (doctorconfiguration.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View("Index", await PaginatedList<DoctorScheduleConfiguration>.CreateAsync(doctorconfiguration.AsNoTracking(), page ?? 1, pageSize));
        }
        #endregion 
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorScheduleConfiguration = await _context.DoctorScheduleConfigurations
                .Include(d => d.Doctor)
                .Include(d => d.Hospital)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (doctorScheduleConfiguration == null)
            {
                return NotFound();
            }

            return View(doctorScheduleConfiguration);
        }

        #region Add
        public IActionResult Add(int id)
        {
            DoctorScheduleConfigurationViewModels co = new DoctorScheduleConfigurationViewModels();
            var doctor = _context.Doctors.Where(x => x.Id == id).SingleOrDefault();
            var hospital = _context.Hospitals.Where(x => x.Id == doctor.HospitalId).SingleOrDefault();
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "Id", "EnglishName");
            co.HospitalId = doctor.HospitalId;
            co.HospitalName = hospital.EnglishName;
            co.StartOn = DateTime.Now;
            co.EndOn = DateTime.Now;
            co.MorningStartingTime = DateTime.Now;
            co.MorningEndingTime = DateTime.Now;
            co.EveningStartingTime = DateTime.Now;
            co.EveningEndingTime = DateTime.Now;
            //dateGap = .TotalHours
            co.DoctorId = id;
            return View(co);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddPost(DoctorScheduleConfigurationViewModels Configurationviewmodels)
        //{

        //    // Schedule 
        //    if (Configurationviewmodels.EndOn.Date < Configurationviewmodels.StartOn.Date) { ModelState.AddModelError("", "Please End Date must be greater than Start Date"); }
        //    if (Configurationviewmodels.MorningEndingTime < Configurationviewmodels.MorningStartingTime) { ModelState.AddModelError("", "Please Morning Ending Time must be greater than Morning start  Time"); }
        //    if (Configurationviewmodels.EveningEndingTime < Configurationviewmodels.EveningStartingTime) { ModelState.AddModelError("", "Please Evening Ending Time must be greater than Evening start Time"); }

        //    TimeSpan Morningperiods, Eveningperiods;
        //      var periodinYears = (Configurationviewmodels.EndOn - Configurationviewmodels.StartOn).TotalHours;
        //   // Configurationviewmodels.PeroidInMintues = (int)(Configurationviewmodels.EndOn - Configurationviewmodels.StartOn).TotalMinutes;
        //    var configuration = _mapper.Map<DoctorScheduleConfiguration>(Configurationviewmodels);
        //    if (Configurationviewmodels.MorningStartingTime != null && Configurationviewmodels.MorningEndingTime != null)
        //    {
        //        Morningperiods = ((DateTime)Configurationviewmodels.MorningEndingTime - (DateTime)Configurationviewmodels.MorningStartingTime);
        //    }
        //    if (Configurationviewmodels.EveningStartingTime != null && Configurationviewmodels.EveningEndingTime != null)
        //    {
        //        Eveningperiods = ((DateTime)Configurationviewmodels.EveningEndingTime - (DateTime)Configurationviewmodels.EveningStartingTime);
        //    }
        //    //if (Morningperiods.TotalHours == 0 && Eveningperiods.TotalHours == 0) { ModelState.AddModelError("", "Please insert Working time "); }

        //    // Configuration

        //    if (ModelState.IsValid)
        //    {

        //        var periodinhours = (int)(Math.Round(Morningperiods.TotalHours) + Math.Round(Eveningperiods.TotalHours));
        //        var periods = Configurationviewmodels.PeroidInMintues;
        //       // Configurationviewmodels.PeroidInMintues = (int)(Configurationviewmodels.EndOn - Configurationviewmodels.StartOn).TotalMinutes;

        //        for (DateTime day = Configurationviewmodels.StartOn; day < Configurationviewmodels.EndOn;)
        //        {
        //            if (Morningperiods.Hours != 0)
        //            {
        //                for (DateTime Mhour = (DateTime)Configurationviewmodels.MorningStartingTime; Mhour < Configurationviewmodels.MorningEndingTime;)
        //                {
        //                    var schedule = new DoctorSchedule();
        //                    schedule.CreatedOn = DateTime.Now;
        //                    schedule.DoctorId = Configurationviewmodels.DoctorId;
        //                    schedule.HospitalId = Configurationviewmodels.HospitalId;
        //                    schedule.Time = Mhour.ToShortTimeString();
        //                    schedule.ScheduleStatusId = (long)ScheduleStatusEnum.Free;
        //                    schedule.Date = day;
        //                    _context.Add(schedule);
        //                    Mhour = Mhour.AddMinutes(periods);
        //                }

        //                await _context.SaveChangesAsync();
        //            }

        //            if (Eveningperiods.Hours != 0)
        //            {
        //                for (DateTime Ehour = (DateTime)Configurationviewmodels.EveningStartingTime; Ehour < Configurationviewmodels.EveningEndingTime;)
        //                {
        //                    var schedule = new DoctorSchedule();
        //                    schedule.CreatedOn = DateTime.Now;
        //                    schedule.DoctorId = Configurationviewmodels.DoctorId;
        //                    schedule.HospitalId = Configurationviewmodels.HospitalId;
        //                    schedule.Time = Ehour.ToShortTimeString();
        //                    schedule.ScheduleStatusId = (long)ScheduleStatusEnum.Free;
        //                    schedule.Date = day;
        //                    _context.Add(schedule);

        //                    Ehour = Ehour.AddMinutes(periods);
        //                }

        //                await _context.SaveChangesAsync();
        //            }
        //            day = day.AddDays(1);
        //        }
        //        _context.Add(configuration);
        //        await _context.SaveChangesAsync();
        //        if (User.IsInRole("Hospital")) { return RedirectToAction(nameof(HospitalDoctorScheduleConfigurations)); } else { return RedirectToAction(nameof(Index)); }
        //    }
        //    ViewData["HospitalId"] = new SelectList(_context.Hospitals, "Id", "EnglishName");
        //    return View("Add", Configurationviewmodels);
        //}

        #endregion



        #region Delete
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var doctorScheduleConfiguration = await _context.DoctorScheduleConfigurations
        //        .Include(d => d.Doctor)
        //        .Include(d => d.Hospital)
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (doctorScheduleConfiguration == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(doctorScheduleConfiguration);
        //}


        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id)
        {
            var doctorScheduleConfiguration = await _context.DoctorScheduleConfigurations.SingleOrDefaultAsync(m => m.Id == id);
            _context.DoctorScheduleConfigurations.Remove(doctorScheduleConfiguration);
            await _context.SaveChangesAsync();
            if (User.IsInRole("Hospital")) { return RedirectToAction(nameof(HospitalDoctorScheduleConfigurations)); } else { return RedirectToAction(nameof(Index)); }
        }

        #endregion

        private bool DoctorScheduleConfigurationExists(long id)
        {
            return _context.DoctorScheduleConfigurations.Any(e => e.Id == id);
        }

        //
        //UpdatePrice((int)Configurationviewmodels.DoctorId, Configurationviewmodels.EndOn, (DateTime)Configurationviewmodels.EveningStartingTime, (DateTime)Configurationviewmodels.EveningEndingTime, (int)Configurationviewmodels.HospitalId, (DateTime)Configurationviewmodels.MorningEndingTime,
        //    (DateTime)Configurationviewmodels.MorningStartingTime, Configurationviewmodels.StartOn);

        //public int UpdatePrice(int doctorId, DateTime enddate, DateTime eveningstart, DateTime eveningenddate, int hospitalid, DateTime morninggending, DateTime morningstart, DateTime starton)
        //{
        //    SqlConnection sqlConnection1 = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-NajmetAlraqeeSite-6EB2DF22-CB01-483C-9FFB-FE8B9F0EE5C8;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //    SqlCommand cmd = new SqlCommand();
        //    //  SqlDataReader reader;

        //    cmd.CommandText = "dbo.UpdateUser";
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Connection = sqlConnection1;

        //    cmd.Parameters.Add("@DoctorId", SqlDbType.BigInt);
        //    cmd.Parameters["@DoctorId"].Value = doctorId;


        //    cmd.Parameters.Add("@StartOn", SqlDbType.DateTime2);
        //    cmd.Parameters["@StartOn"].Value = starton;


        //    cmd.Parameters.Add("@EndOn", SqlDbType.DateTime2);
        //    cmd.Parameters["@EndOn"].Value = enddate;

        //    cmd.Parameters.Add("@EveningStartingTime", SqlDbType.DateTime2);
        //    cmd.Parameters["@EveningStartingTime"].Value = eveningstart;

        //    cmd.Parameters.Add("@EveningEndingTime", SqlDbType.DateTime2);
        //    cmd.Parameters["@EveningEndingTime"].Value = eveningenddate;

        //    cmd.Parameters.Add("@HospitalId", SqlDbType.BigInt);
        //    cmd.Parameters["@HospitalId"].Value = hospitalid;

        //    cmd.Parameters.Add("@MorningStartingTime", SqlDbType.DateTime2);
        //    cmd.Parameters["@MorningStartingTime"].Value = morningstart;

        //    cmd.Parameters.Add("@MorningEndingTime", SqlDbType.DateTime2);
        //    cmd.Parameters["@MorningEndingTime"].Value = morninggending;

        //    sqlConnection1.Open();

        //    cmd.ExecuteNonQuery();
        //    // Data is accessible through the DataReader object here.

        //    sqlConnection1.Close();

        //    return 0;
        //}
    }
}
