using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.Services;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    [Authorize]
    public class ForeginAgenciesController : Controller
    {
        #region Filed 
        private readonly IForeignAgencyRepository _agency;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly INationalityRepository _nationality;
        private readonly IBankDetailRepository _bank;
        private readonly IJobTypeReository _jobtype;
        private readonly ICurrencyRepository _currency;
        private readonly IForeignAgencyJobRepository _jobs;


        #endregion
        public ForeginAgenciesController(IForeignAgencyRepository agency, IForeignAgencyJobRepository jobs,
            IMapper mapper, 
            IToastNotification toastNotification
            , INationalityRepository nationality, IBankDetailRepository bank, ICurrencyRepository currency, IJobTypeReository jobtype)
        {
            _agency = agency;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _nationality = nationality;
            _bank = bank;
            _jobtype = jobtype;
            _currency = currency;
            _jobs = jobs;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page, string SearchString)
        {
            var agencyList = _agency.GetAgencies();
            if (SearchString != null)
            {
                agencyList = _agency.GetAgencies().Where(x => x.OfficeName.Contains(SearchString));
            }
            else
            {
                agencyList = _agency.GetAgencies();
            }
            if (agencyList.Count() <= 10) { page = 1; }
            int pageSize = 10;
            var agencypaging = await PaginatedList<ForeignAgency>.CreateAsync((agencyList).AsNoTracking(), page ?? 1, pageSize);
            ViewBag.Agency = agencypaging;
            return View(agencypaging);
        }
        #endregion

        #region Details
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var agency = _agency.GetAgencyById((int)id);
            //var agencyViewModel = _mapper.Map<ForeignAgencyTransferViewModel>(agency);
            ViewBag.Jobs =_jobs.GetForeignAgencyJobs().Where(x => x.ForeignAgencyId == agency.Id);
            if (agency == null)
            {
                return NotFound();
            }
            return View(agency);
        }
        #endregion

        #region Add

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name");
            ViewBag.BankDetailId = new SelectList(_bank.GetBankDetails(), "Id", "Name");
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name");
            ViewBag.CurrencyId = new SelectList(_currency.GetCurrencies(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ForeignAgencyViewModel agencyViewModels)
        {
            ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name");
            ViewBag.BankDetailId = new SelectList(_bank.GetBankDetails(), "Id", "Name");
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name");
            ViewBag.CurrencyId = new SelectList(_currency.GetCurrencies(), "Id", "Name");
            //agencyViewModels.IsActive = true;
            //if (agencyViewModels.NationalityId == null) { ModelState.AddModelError("", "الرجاء ادخال جنسية المندوب"); }
            //if (agencyViewModels.BankDetailId == null) { ModelState.AddModelError("", "الرجاء ادخال نوع البنك"); }
            //if (agencyViewModels.JobTypeId == null) { ModelState.AddModelError("", "الرجاء ادخال الوظيفة "); }
            if (agencyViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("BankDetailId");
                ModelState.Remove("JobTypeId");
                ModelState.Remove("NationalityId");
                ModelState.Remove("CurrencyId");
                if (ModelState.IsValid)
                {

                    var agency = _mapper.Map<Data.Entities.ForeignAgency>(agencyViewModels);
                    _agency.AddAgency(agency);
                    _toastNotification.AddSuccessToastMessage("تم أضافة  الوكالة الخارجية");
                    return RedirectToAction(nameof(Index));
                }

                return View(agencyViewModels);
            }
            else
            {
                ModelState.Remove("DelegateTypeId");
                ModelState.Remove("NationalityId");
                if (ModelState.IsValid)
                {
                    var agency = _mapper.Map<ForeignAgency>(agencyViewModels);
                    _agency.UpdateAgency(agencyViewModels.Id, agency);
                    _toastNotification.AddSuccessToastMessage("تم تعديل الوكالة الخارجية بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View("Add", agencyViewModels);
            }

        }

        #endregion

        #region Edit 
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agency = _agency.GetAgencyById((int)id);
            var agencyViewModels = _mapper.Map<ForeignAgencyViewModel>(agency);
            if (agency == null)
            {
                return NotFound();
            }
            //ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name" , agencyViewModels.NationalityId);
            ViewBag.BankDetailId = new SelectList(_bank.GetBankDetails(), "Id", "Name", agencyViewModels.BankDetailId);
            //ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name", agencyViewModels.JobTypeId); 
            //    ViewBag.CurrencyId = new SelectList(_currency.GetCurrencies(), "Id", "Name", agencyViewModels.CurrencyId);
            return View("Add", agencyViewModels);
        }
        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            _agency.RemoveAggency(id);
            _toastNotification.AddSuccessToastMessage("تم حذف الوكالة الخارجية بنجاح");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Activated(int id)
        {
          var item =  _agency.GetAgencyById(id);
            //item.IsActive = true;
            _agency.UpdateAgency(id,item);
            _toastNotification.AddSuccessToastMessage("تم التفعيل بنجاح");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DisActivated(int id)
        {
            var item = _agency.GetAgencyById(id);
            //item.IsActive = false;
            _agency.UpdateAgency(id, item);
            _toastNotification.AddSuccessToastMessage("تم الايقاف بنجاح");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult JobActivated(int id)
        {
            var item = _jobs.GetForeignAgencyJobById(id);
            item.IsActive = true;
            _jobs.UpdateForeignAgencyJob(id, item);
            _toastNotification.AddSuccessToastMessage("تم التفعيل بنجاح");
            return RedirectToAction(nameof(Details), new { Id = item.ForeignAgencyId });
        }

        public IActionResult JobDisActivated(int id)
        {
            var item = _jobs.GetForeignAgencyJobById(id);
            item.IsActive = false;
            _jobs.UpdateForeignAgencyJob(id, item);
            _toastNotification.AddSuccessToastMessage("تم الايقاف بنجاح");
            return RedirectToAction(nameof(Details), new { Id = item.ForeignAgencyId });
        }

        #endregion
    }
}