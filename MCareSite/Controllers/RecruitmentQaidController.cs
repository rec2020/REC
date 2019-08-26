using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class RecruitmentQaidController : Controller
    {
        private readonly IAccountTreeRepository _tree;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IRecruitmentQaidRepository _recruitmentQaid;

        public RecruitmentQaidController(
            IRecruitmentQaidRepository recruitmentQaid,
            IAccountTreeRepository tree,
            IMapper mapper,
            IToastNotification toastNotification)
        {
            _recruitmentQaid = recruitmentQaid;
            _tree = tree;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page, string SearchString)
        {
            var recruitmentQaidList = _recruitmentQaid.GetRecruitmentQaids();
            if (SearchString != null)
            {
                //recruitmentQaidList = _recruitmentQaid.GetRecruitmentQaids().Where(x => x..Contains(SearchString));
            }
            else
            {
                recruitmentQaidList = _recruitmentQaid.GetRecruitmentQaids();
            }
            if (recruitmentQaidList.Count() <= 10) { page = 1; }
            int pageSize = 10;
            var recruitmentQaidpaging = await PaginatedList<RecruitmentQaid>.CreateAsync(recruitmentQaidList.AsNoTracking(), page ?? 1, pageSize);
            ViewBag.RecruitmentQaids = recruitmentQaidpaging;
            return View(recruitmentQaidpaging);
        }
        #endregion

        #region  Add 
        [HttpGet]
        public IActionResult Add()
        {
            RecruitmentQaidViewModel obj = new RecruitmentQaidViewModel();
            obj.QaidDate = DateTime.Now.ToString("d", CultureInfo.InvariantCulture);
            ViewBag.FromAccountId = new SelectList(_tree.GetAccountTrees(), "Id", "DescriptionAr");
            ViewBag.ToAccountId = new SelectList(_tree.GetAccountTrees(), "Id", "DescriptionAr");
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(RecruitmentQaidViewModel recruitmentQaidViewModels)
        {
            ViewBag.FromAccountId = new SelectList(_tree.GetAccountTrees(), "Id", "DescriptionAr");
            ViewBag.ToAccountId = new SelectList(_tree.GetAccountTrees(), "Id", "DescriptionAr");
            if (recruitmentQaidViewModels.FromAccountId == null) { ModelState.AddModelError("", "الرجاء ادخال من حساب"); }
            if (recruitmentQaidViewModels.ToAccountId == null) { ModelState.AddModelError("", "الرجاء ادخال الي حساب"); }
            if (recruitmentQaidViewModels.Amount == 0) { ModelState.AddModelError("", "الرجاء ادخال المبلغ "); }
            if (recruitmentQaidViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("FromAccountId");
                ModelState.Remove("ToAccountId");
                ModelState.Remove("Amount");
                if (ModelState.IsValid)
                {
                    var recruitmentQaid = _mapper.Map<RecruitmentQaid>(recruitmentQaidViewModels);
                    _recruitmentQaid.AddRecruitmentQaid(recruitmentQaid);
                    _toastNotification.AddSuccessToastMessage("تم أضافة قيد الاستقدام بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(recruitmentQaidViewModels);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var recruitmentQaid =  _mapper.Map<RecruitmentQaid>(recruitmentQaidViewModels);
                     _recruitmentQaid.UpdateRecruitmentQaid(recruitmentQaidViewModels.Id, recruitmentQaid);
                     _toastNotification.AddSuccessToastMessage("تم تعديل قيد الاستقدام بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(recruitmentQaidViewModels);
            }

        }
        #endregion

        #region  Update 
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var recruitmentQaid = _recruitmentQaid.GetRecruitmentQaidById((int)id);
            var recruitmentQaidViewModel = _mapper.Map<RecruitmentQaidViewModel>(recruitmentQaid);
            if (recruitmentQaid == null)
            {
                return NotFound();
            }
            ViewBag.FromAccountId = new SelectList(_tree.GetAccountTrees(), "Id", "DescriptionAr");
            ViewBag.ToAccountId = new SelectList(_tree.GetAccountTrees(), "Id", "DescriptionAr");
            return View("Add", recruitmentQaidViewModel);
        }
        #endregion

        #region  Details 
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var recruitmentQaid = _recruitmentQaid.GetRecruitmentQaidById((int)id);
            //var agencyViewModel = _mapper.Map<ForeignAgencyTransferViewModel>(agency);
            if (recruitmentQaid == null)
            {
                return NotFound();
            }
            return View(recruitmentQaid);
        }
        #endregion
    }
}