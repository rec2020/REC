using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class RecruitmentQaidController : Controller
    {
        private readonly IRecruitmentQaidTypeRepository _type;
        private readonly IRecruitmentQaidStatusRepository _status;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IRecruitmentQaidRepository _recruitmentQaid;
        private readonly IRecruitmentQaidDetailRepository _recruitmentQaidDetail;

        public RecruitmentQaidController(
            IRecruitmentQaidRepository recruitmentQaid,
            IRecruitmentQaidDetailRepository recruitmentQaidDetail,
            IRecruitmentQaidTypeRepository type,
            IRecruitmentQaidStatusRepository status,
            IMapper mapper,
            IToastNotification toastNotification)
        {
            _recruitmentQaid = recruitmentQaid;
            _type = type;
            _status = status;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _recruitmentQaidDetail = recruitmentQaidDetail;
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
            ViewBag.TypeId = new SelectList(_type.GetRecruitmentQaidTypes(), "Id", "Name");
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(RecruitmentQaidViewModel recruitmentQaidViewModels)
        {
            ViewBag.TypeId = new SelectList(_type.GetRecruitmentQaidTypes(), "Id", "Name");
            if (recruitmentQaidViewModels.TypeId == null) { ModelState.AddModelError("", "الرجاء تحديد نوع القيد "); }
            if (recruitmentQaidViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("TypeId");
                if (ModelState.IsValid)
                {
                    var recruitmentQaid = _mapper.Map<RecruitmentQaid>(recruitmentQaidViewModels);
                    _recruitmentQaid.AddRecruitmentQaid(recruitmentQaid);
                    _toastNotification.AddSuccessToastMessage("تم أضافة القيد  بنجاح");
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
                     _toastNotification.AddSuccessToastMessage("تم تعديل القيد  بنجاح");
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
            ViewBag.TypeId = new SelectList(_type.GetRecruitmentQaidTypes(), "Id", "Name", recruitmentQaid.TypeId);
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
            ViewBag.QaidDetail = _recruitmentQaidDetail.GetRecruitmentQaidDetails().Where(x=>x.QaidId== recruitmentQaid.Id); 
            ViewBag.TypeId = new SelectList(_type.GetRecruitmentQaidTypes(), "Id", "Name", recruitmentQaid.TypeId);
            return View(recruitmentQaid);
        }
        #endregion

        #region Close 
        public IActionResult Close(int? id)
        {
            var qaid = _recruitmentQaid.GetRecruitmentQaidById((int)id);

            if (qaid != null)
            {
                _recruitmentQaid.CloseRecruitmentQaid((int)id, qaid);
            }
            return RedirectToAction(nameof(Index), new { RecruitmentQaidId = qaid.Id });
        }
        #endregion
    }
}