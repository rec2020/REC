using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.Services;
using NajmetAlraqee.Site.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

namespace NajmetAlraqeeSite.Controllers
{
    public class PatientAppointmentController : Controller
    {
        #region  Filed & Construct
        private readonly NajmetAlraqeeContext _context;
        private readonly IPatientAppointmentRepository _Appointment;
        private readonly IHostingEnvironment _environment;
        private readonly IMapper _mapper;


        public PatientAppointmentController(NajmetAlraqeeContext context, IPatientAppointmentRepository Appointment, IHostingEnvironment environment, IMapper mapper)
        {
            _context = context;
            _Appointment = Appointment;
            _environment = environment;
            _mapper = mapper;
        }

        #endregion 

        #region Index
        public async Task<IActionResult> Index(int? page, string SearchString)
        {
            var appoinment = _Appointment.GetAllPatientAppointment();
            if (SearchString != null)
            {
                appoinment = _Appointment.GetAllPatientAppointment().Where(x => x.Patient.EnglishName.Contains(SearchString));
            }
            else
            {
                appoinment = _Appointment.GetAllPatientAppointment();
            }
            if (appoinment.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View(await PaginatedList<PatientAppointment>.CreateAsync(appoinment.AsNoTracking(), page ?? 1, pageSize));
        }
        public async Task<IActionResult> HospitalIndex(int? page, string SearchString)
        {
            var get = User.Identity.Name;
            var usertype = _context.Users.Where(x => x.UserName.Contains(get)).SingleOrDefault();
            var gethospital = _context.Doctors.Where(x => x.UserId.Contains(usertype.Id)).SingleOrDefault();
            var appoinment = _Appointment.GetAllPatientAppointment().Where(x => x.DoctorSchedule.HospitalId == gethospital.Id);
            if (SearchString != null)
            {
                appoinment = appoinment.Where(x => x.Patient.EnglishName.Contains(SearchString));
            }
            else
            {
                appoinment = _Appointment.GetAllPatientAppointment().Where(x => x.DoctorSchedule.HospitalId == gethospital.Id);
            }
            if (appoinment.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View("Index",await PaginatedList<PatientAppointment>.CreateAsync(appoinment.AsNoTracking(), page ?? 1, pageSize));
        }
        #endregion



        #region Add

        public IActionResult Add()
        {
            ViewBag.PatientId = new SelectList(_context.Patients, "Id", "EnglishName");
            PatientAppointmentViewModel appointement = new PatientAppointmentViewModel();
            appointement.CouldCancel = false;
            return View(appointement);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(PatientAppointmentViewModel appointement)
        {
            if (ModelState.IsValid)
            {
                var doctorschhedule = _context.DoctorSchedules.Where(x => x.Id == appointement.DoctorScheduleId).SingleOrDefault();
                if (doctorschhedule != null)
                {
                    appointement.AppointementStatusId = (long)AppointmentStatusEnum.Pending;
                    appointement.AppointmentOn = doctorschhedule.Date.ToShortDateString() + "  " + doctorschhedule.Time;
                    appointement.CouldCancel = false;
                    appointement.CreatedOn = DateTime.Now; ;
                    var appoinmeentmodel = _mapper.Map<PatientAppointment>(appointement);
                    _Appointment.AddPatientAppointment(appoinmeentmodel);
                    // update doctor schedule 
                    doctorschhedule.ScheduleStatusId = (long)ScheduleStatusEnum.Booked;
                    _context.Entry(doctorschhedule).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("","Please Check Schedule No");
                }

            }
            ViewBag.PatientId = new SelectList(_context.Patients, "Id", "EnglishName");
            return View(appointement);
        }

        #endregion

        [HttpPost]
        public JsonResult GetInfo(int Id)
        {

            var sa = new JsonSerializerSettings();
            var getPatient = _context.Patients.Where(z => z.Id == Id).SingleOrDefault();

            var Name = getPatient.EnglishName;
            var GenderId = getPatient.GenderId;
            var GenderName = _context.Genders.Where(x => x.Id == GenderId).SingleOrDefault().EnglishName;
            var userid = getPatient.UserId;
            var user = _context.Users.Where(m => m.Id.Contains(userid)).SingleOrDefault();
            var email = user.Email;
            var mobile = user.Mobile;
            //var cities = db.Cities.Where(c => c.StateId == state);
            var data = new { Name = Name, GenderId = GenderId, GenderName = GenderName, email = email, mobile = mobile };

            return Json(data, sa);
        }

    }
}