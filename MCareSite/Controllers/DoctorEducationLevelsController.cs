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
    public class DoctorEducationLevelsController : Controller
    {
        private readonly NajmetAlraqeeContext _context;

        public DoctorEducationLevelsController(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        // GET: DoctorEducationLevels
        public async Task<IActionResult> Index()
        {
            var NajmetAlraqeeContext = _context.DoctorEducationLevels.Include(d => d.EducationLevel);
            return View(await NajmetAlraqeeContext.ToListAsync());
        }

        // GET: DoctorEducationLevels/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorEducationLevel = await _context.DoctorEducationLevels
                .Include(d => d.EducationLevel)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (doctorEducationLevel == null)
            {
                return NotFound();
            }

            return View(doctorEducationLevel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(DoctorViewModel doctorviewmodel)
        {
            DoctorEducationLevel docsp = new DoctorEducationLevel();
            if (doctorviewmodel.EducationlevelId == null)
            {
                ModelState.AddModelError("invalid Education level", "Please be Sure to select Education level");
                return RedirectToAction(nameof(Details), "Doctors", new { id = doctorviewmodel.Id });
            }

            docsp.DoctorId = doctorviewmodel.Id;
            docsp.EducationLevelId = (long)doctorviewmodel.EducationlevelId;
            _context.Add(docsp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), "Doctors", new { id = doctorviewmodel.Id });
        }
       

       

       

        private bool DoctorEducationLevelExists(long id)
        {
            return _context.DoctorEducationLevels.Any(e => e.Id == id);
        }
    }
}
