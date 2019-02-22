using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;
//using NajmetAlraqeeSite.Data;
using NajmetAlraqeeSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace NajmetAlraqeeSite.Controllers
{
    [Authorize]
    public class DashBoardsController : Controller
    {

        private NajmetAlraqeeContext _context;
        
        public DashBoardsController(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            AdminDashBoardViewModels dash = new AdminDashBoardViewModels();
            dash.Cities = _context.Cities.Count();
            dash.Countries = _context.Countries.Count();
            dash.DoctorLanguages = _context.DoctorLanguages.Count();
            dash.Doctors = _context.Doctors.Count();
            dash.Hospitals = _context.Hospitals.Count();
            dash.HospitalTypes = _context.HospitalTypes.Count();
            dash.PatientAppointments = _context.PatientAppointments.Count();
            dash.ConfirmAppointment = _context.PatientAppointments.Where(x=>x.AppointementStatusId== (long)ScheduleStatusEnum.Booked).Count();
            dash.CanceledAppointment = _context.PatientAppointments.Where(x => x.AppointementStatusId == (long)ScheduleStatusEnum.NotAllowed).Count();
            dash.Patients = _context.Patients.Count();
            dash.Specialties = _context.Specialties.Count();
            return View(dash);
        }

        public IActionResult HospitalDashboard()
        {
            var username = User.Identity.Name;
            string useridentity =  _context.Users.Where(x=>x.UserName.Contains(username)).SingleOrDefault().Id ;
           var Get =  _context.Doctors.Where(x => x.UserId.Contains(useridentity)).SingleOrDefault();
            HospitalDashBoardViewModels dash = new HospitalDashBoardViewModels();
            if (Get!=null) { 
            var gethospital = Get.HospitalId;
            dash.Doctors = _context.Doctors.Where(x=>x.HospitalId== gethospital).Count();
            dash.Offers = _context.HospitalOffers.Where(x => x.HospitalId == gethospital).Count();
            //dash.Patients = _context.PatientAppointments.Where(x => x.DoctorSchedule.HospitalId == gethospital).Count();
            dash.PatientAppointments = _context.DoctorSchedules.Where(x => x.HospitalId == gethospital && x.ScheduleStatusId == (long)ScheduleStatusEnum.Booked).Count();
               // dash.Specialties = _context.Doctors.Where(x => x.HospitalId == gethospital).Select(x => x.DoctorSpecialtys).Count();
            }
            return View(dash);
        }
    }
}