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
            dash.DoctorLanguages =0;
            dash.Doctors = 0;
            dash.Hospitals = 0;
            dash.HospitalTypes =0;
            dash.PatientAppointments = 0;
            dash.ConfirmAppointment = 0;
            dash.CanceledAppointment =0;
            dash.Patients = 0;
            dash.Specialties = 0;
            return View(dash);
        }

        public IActionResult HospitalDashboard()
        {
            var username = User.Identity.Name;
            string useridentity =  _context.Users.Where(x=>x.UserName.Contains(username)).SingleOrDefault().Id ;
           var Get =  "";
            HospitalDashBoardViewModels dash = new HospitalDashBoardViewModels();
            if (Get!=null) { 
           
            dash.Doctors = 0;
            dash.Offers = 0;
            //dash.Patients = _context.PatientAppointments.Where(x => x.DoctorSchedule.HospitalId == gethospital).Count();
            dash.PatientAppointments = 0;
               // dash.Specialties = _context.Doctors.Where(x => x.HospitalId == gethospital).Select(x => x.DoctorSpecialtys).Count();
            }
            return View(dash);
        }
    }
}