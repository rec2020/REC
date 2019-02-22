using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Site.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace NajmetAlraqeeSite.Controllers
{
    [Authorize]
    public class DoctorSpecialtiesController : Controller
    {
        private readonly NajmetAlraqeeContext _context;

        public DoctorSpecialtiesController(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        // GET: DoctorSpecialties
        public async Task<IActionResult> Index()
        {
            var NajmetAlraqeeContext = _context.DoctorSpecialties.Include(d => d.Specialty);
            return View(await NajmetAlraqeeContext.ToListAsync());
        }

        // GET: DoctorSpecialties/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorSpecialty = await _context.DoctorSpecialties
                .Include(d => d.Specialty)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (doctorSpecialty == null)
            {
                return NotFound();
            }

            return View(doctorSpecialty);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add( DoctorViewModel doctorviewmodel  )
        {
            DoctorSpecialty docsp = new DoctorSpecialty();
            if (doctorviewmodel.SpecialtyId == null)
            {
                ModelState.AddModelError("invalid speciality", "Please be Sure to select Speciality");
                return RedirectToAction(nameof(Details), "Doctors", new { id = doctorviewmodel.Id });
            }
       
            docsp.DoctorId = doctorviewmodel.Id;
            docsp.SpecialtyId =(long) doctorviewmodel.SpecialtyId;
                _context.Add(docsp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details),"Doctors",new {id= doctorviewmodel.Id });
        }


        private bool DoctorSpecialtyExists(long id)
        {
            return _context.DoctorSpecialties.Any(e => e.Id == id);
        }
    }
}
