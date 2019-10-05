using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    [Authorize]
    public class RecruitmentQaidDetailController : Controller
    {
        #region Filed 
        private readonly IAccountTreeRepository _accTree;
        private readonly IRecruitmentQaidRepository _qaid;
        private readonly IRecruitmentQaidDetailRepository _qaidDetail;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IRecruitmentQaidDetailTypeRepository _detailType;
        #endregion

        public RecruitmentQaidDetailController(IAccountTreeRepository accTree,
            IMapper mapper, IRecruitmentQaidRepository qaid,
            IToastNotification toastNotification
            , IRecruitmentQaidDetailTypeRepository detailType ,
            IRecruitmentQaidDetailRepository qaidDetail)
        {
            _accTree = accTree;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _qaid = qaid;
            _detailType = detailType;
            _qaidDetail = qaidDetail;
        }



        #region Index 
        public IActionResult Index(int? page, string SearchString, int? RecruitmentQaidId, int? Id)
        {

            RecruitmentQaidDetailViewModel detail = new RecruitmentQaidDetailViewModel
            {
                QaidId = RecruitmentQaidId,
            };

            if (Id != null)
            {
                var qaidDetail = _qaidDetail.GetRecruitmentQaidDetailById((int)Id);
                var qaidDetailViewModels = _mapper.Map<RecruitmentQaidDetailViewModel>(qaidDetail);
                detail.AccountTreeId = qaidDetailViewModels.AccountTreeId;
                detail.TypeId = qaidDetailViewModels.TypeId;
                detail.Debit = qaidDetailViewModels.Debit;
                detail.Credit = qaidDetailViewModels.Credit;
                detail.Note = qaidDetailViewModels.Note;
            }


            var qaidDetailList = _qaidDetail.GetRecruitmentQaidDetails().Where(x => x.QaidId == RecruitmentQaidId);
            ViewBag.QaidDetail = qaidDetailList;

            ViewBag.AccountTreeId = new SelectList(_accTree.GetAccountTrees(), "Id", "DescriptionAr");
            ViewBag.TypeId = new SelectList(_detailType.GetRecruitmentQaidDetailTypes(), "Id", "Name");
            return View(detail);
        }
        #endregion


        #region Add

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.AccountTreeId = new SelectList(_accTree.GetAccountTrees(), "Id", "DescriptionAr");
            ViewBag.TypeId = new SelectList(_detailType.GetRecruitmentQaidDetailTypes(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(RecruitmentQaidDetailViewModel qaidDetailViewModels)
        {
            ViewBag.AccountTreeId = new SelectList(_accTree.GetAccountTrees(), "Id", "DescriptionAr");
            ViewBag.TypeId = new SelectList(_detailType.GetRecruitmentQaidDetailTypes(), "Id", "Name");
            if (qaidDetailViewModels.AccountTreeId == null) { ModelState.AddModelError("", "الرجاء تحديد الحساب"); }
            if (qaidDetailViewModels.TypeId == null) { ModelState.AddModelError("", "الرجاء نوع بند القيد "); }
            if (qaidDetailViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("AccountTreeId");
                ModelState.Remove("TypeId");
               
                if (ModelState.IsValid)
                {
                    var qaidDetail = _mapper.Map<RecruitmentQaidDetail>(qaidDetailViewModels);
                    _qaidDetail.AddRecruitmentQaidDetail(qaidDetail);
                    _toastNotification.AddSuccessToastMessage("تم أضافة بند للقيد بنجاح");
                    return RedirectToAction(nameof(Index), new { RecruitmentQaidId = qaidDetailViewModels.QaidId });
                }
                return View(nameof(Index), qaidDetailViewModels);
            }
            else
            {
                ModelState.Remove("AccountTreeId");
                ModelState.Remove("TypeId");

                if (ModelState.IsValid)
                {
                    var qaidDetail = _mapper.Map<RecruitmentQaidDetail>(qaidDetailViewModels);
                    _qaidDetail.UpdateRecruitmentQaidDetail(qaidDetailViewModels.Id, qaidDetail);
                    _toastNotification.AddSuccessToastMessage("تم تعديل  بند للقيد بنجاح");
                    return RedirectToAction(nameof(Index), new { RecruitmentQaidId = qaidDetailViewModels.QaidId });
                }
                return View(nameof(Index), qaidDetailViewModels);
            }

        }

        #endregion

    }
}