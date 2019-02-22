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
    public class DoctorLanguagesController : Controller
    {
        private readonly NajmetAlraqeeContext _context;

        public DoctorLanguagesController(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        // GET: DoctorLanguages
        public async Task<IActionResult> Index()
        {
            var NajmetAlraqeeContext = _context.DoctorLanguages.Include(d => d.Language);
            return View(await NajmetAlraqeeContext.ToListAsync());
        }

        // GET: DoctorLanguages/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctorLanguage = await _context.DoctorLanguages
                .Include(d => d.Language)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (doctorLanguage == null)
            {
                return NotFound();
            }

            return View(doctorLanguage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(DoctorViewModel doctorviewmodel)
        {
            DoctorLanguage docsp = new DoctorLanguage();
            if (doctorviewmodel.LanguageId == null)
            {
                ModelState.AddModelError("invalid speciality", "Please be Sure to select Speciality");
                return RedirectToAction(nameof(Details), "Doctors", new { id = doctorviewmodel.Id });
            }

            docsp.DoctorId = doctorviewmodel.Id;
            docsp.LanguageId = (long)doctorviewmodel.LanguageId;
            _context.Add(docsp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), "Doctors", new { id = doctorviewmodel.Id });
        }

        private bool DoctorLanguageExists(long id)
        {
            return _context.DoctorLanguages.Any(e => e.Id == id);
        }
    }
}
