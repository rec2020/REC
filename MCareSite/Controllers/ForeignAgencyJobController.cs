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
    public class ForeignAgencyJobController : Controller
    {
        #region Filed 
        private readonly IForeignAgencyRepository _agency;
        private readonly IForeignAgencyJobRepository _agency_job;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly INationalityRepository _nationality;
        private readonly IJobTypeReository _jobtype;
        private readonly ICurrencyRepository _currency;


        #endregion
        public ForeignAgencyJobController(IForeignAgencyRepository agency,
            IMapper mapper, IForeignAgencyJobRepository agency_job,
            IToastNotification toastNotification
            , INationalityRepository nationality, IBankDetailRepository bank, ICurrencyRepository currency, IJobTypeReository jobtype)
        {
            _agency = agency;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _nationality = nationality;
            _jobtype = jobtype;
            _currency = currency;
            _agency_job = agency_job;
        }

        #region Index 
        public IActionResult Index(int? page, string SearchString , int? ForeignAgencyJobId,int? Id)
        {
          
            ForeignAgencyJobViewModel select = new ForeignAgencyJobViewModel
            {
                ForeignAgencyId = ForeignAgencyJobId,
            };

            if (Id!=null) {
                var agencyjob = _agency_job.GetForeignAgencyJobById((int)Id);
                var agencyjobViewModels = _mapper.Map<ForeignAgencyJobViewModel>(agencyjob);
                select.Price = agencyjobViewModels.Price;
                select.NationalityId = agencyjobViewModels.NationalityId;
                select.JobTypeId = agencyjobViewModels.JobTypeId;
                select.CurrencyId = agencyjobViewModels.CurrencyId;
            } 


            var agencyList =  _agency_job.GetForeignAgencyJobs().Where(x=>x.ForeignAgencyId== ForeignAgencyJobId);
            ViewBag.Agency = agencyList;

            ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name", select.NationalityId);
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name", select.JobTypeId);
            ViewBag.CurrencyId = new SelectList(_currency.GetCurrencies(), "Id", "Name", select.CurrencyId);
            return View(select);
        }
        #endregion

        //#region Details
        //public IActionResult Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var agency = _agency.GetAgencyById((int)id);
        //    //var agencyViewModel = _mapper.Map<ForeignAgencyTransferViewModel>(agency);
        //    if (agency == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(agency);
        //}
        //#endregion

        #region Add

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name");
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name");
            ViewBag.CurrencyId = new SelectList(_currency.GetCurrencies(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ForeignAgencyJobViewModel agencyjobViewModels)
        {
            ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name");
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name");
            ViewBag.CurrencyId = new SelectList(_currency.GetCurrencies(), "Id", "Name");
            agencyjobViewModels.IsActive = true;
            if (agencyjobViewModels.NationalityId == null) { ModelState.AddModelError("", "الرجاء ادخال جنسية المندوب"); }
            if (agencyjobViewModels.JobTypeId == null) { ModelState.AddModelError("", "الرجاء ادخال الوظيفة "); }
            if (agencyjobViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("JobTypeId");
                ModelState.Remove("NationalityId");
                ModelState.Remove("CurrencyId");
                if (ModelState.IsValid)
                {

                    var agencyjob = _mapper.Map<ForeignAgencyJob>(agencyjobViewModels);
                    _agency_job.AddForeignAgencyJob(agencyjob);
                    _toastNotification.AddSuccessToastMessage("تم أضافة الوظيفة الوكالة الخارجية");
                    return RedirectToAction(nameof(Index), new { ForeignAgencyJobId = agencyjobViewModels.ForeignAgencyId });
                }

                return View(agencyjobViewModels);
            }
            else
            {
                ModelState.Remove("JobTypeId");
                ModelState.Remove("NationalityId");
                ModelState.Remove("CurrencyId");
                if (ModelState.IsValid)
                {
                    var agencyjob = _mapper.Map<ForeignAgencyJob>(agencyjobViewModels);
                    _agency_job.UpdateForeignAgencyJob(agencyjobViewModels.Id, agencyjob);
                    _toastNotification.AddSuccessToastMessage("تم تعديل الوظيفة الوكالة الخارجية بنجاح");
                    return RedirectToAction(nameof(Index), new { ForeignAgencyJobId = agencyjobViewModels.ForeignAgencyId });
                }
                return View("Add", agencyjobViewModels);
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

            var agencyjob = _agency_job.GetForeignAgencyJobById((int)id);
            var agencyjobViewModels = _mapper.Map<ForeignAgencyJobViewModel>(agencyjob);
            if (agencyjob == null)
            {
                return NotFound();
            }

            var agencyList = _agency_job.GetForeignAgencyJobs().Where(x => x.ForeignAgencyId == agencyjob.ForeignAgencyId);
            ViewBag.Agency = agencyList;
            ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name", agencyjobViewModels.NationalityId);
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name", agencyjobViewModels.JobTypeId);
            ViewBag.CurrencyId = new SelectList(_currency.GetCurrencies(), "Id", "Name", agencyjobViewModels.CurrencyId);
            return RedirectToAction(nameof(Index), new { ForeignAgencyJobId = agencyjobViewModels.ForeignAgencyId , Id= agencyjobViewModels.Id });
        }
        #endregion

        //#region Delete

        //public IActionResult Delete(int id)
        //{
        //    _agency.RemoveAggency(id);
        //    _toastNotification.AddSuccessToastMessage("تم حذف الوكالة الخارجية بنجاح");
        //    return RedirectToAction(nameof(Index));
        //}
        public IActionResult Activated(int id)
        {
            var item = _agency_job.GetForeignAgencyJobById(id);
            //item.IsActive = true;
            _agency_job.UpdateForeignAgencyJob(id, item);
            _toastNotification.AddSuccessToastMessage("تم التفعيل بنجاح");
            return RedirectToAction(nameof(Index), new { ForeignAgencyJobId = item.ForeignAgencyId, Id = item.Id });
        }

        public IActionResult DisActivated(int id)
        {
            var item = _agency_job.GetForeignAgencyJobById(id);
            //item.IsActive = false;
            _agency_job.UpdateForeignAgencyJob(id, item);
            _toastNotification.AddSuccessToastMessage("تم الايقاف بنجاح");
            return RedirectToAction(nameof(Index), new { ForeignAgencyJobId = item.ForeignAgencyId, Id = item.Id });
        }


        //#endregion
    }
}