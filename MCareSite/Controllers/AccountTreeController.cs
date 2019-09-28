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
    public class AccountTreeController : Controller
    {
        #region Filed 
        private readonly IAccountClassificationRepository _AccClassification;
        private readonly IAccountClassificationTypeRepository _Acctype;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IAccountTreeRepository _tree;
        #endregion

        public AccountTreeController(
          IMapper mapper, IToastNotification toastNotification,
          IAccountClassificationTypeRepository acctype, IAccountClassificationRepository accClassification,
          IAccountTreeRepository tree)
        {
            _mapper = mapper;
            _toastNotification = toastNotification;
            _AccClassification = accClassification;
            _Acctype = acctype;
            _tree = tree;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult TreeData()
        {
            var Data = _tree.GetAccountTrees().Select(r => new
            {
                Id = r.Id,
                AccountNo = r.AccountNo,
                DescriptionAr = r.DescriptionAr,
                DescriptionEn = r.DescriptionEn,
                ClassificationType = r.AccClassification.DescriptionAr,
                ParentId = r.ParentId,
                Balance = r.Balance,
                Credit = r.Credit,
                Debit = r.Debit,
                Accprev = r.Accprev,
                AccType = r.AccType.Name

            });
            return Json(Data);
        }
        [HttpGet]
        public IActionResult Add(int? accountId)
        {
            AccountTreeViewModel model = new AccountTreeViewModel
            {
                ParentId = accountId != 0 ? accountId : null,
                Balance = (decimal)0.0,
                Credit = (decimal)0.0,
                Debit = (decimal)0.0,
                PriceInExhibtion = 0,
                HighLimitForBalance = 0,
                EhalkPrecent = 0
            };
            if (accountId > 0)
            {
                var treeaccount = _tree.GetAccountTreeById((int)accountId);
                model.Accprev = treeaccount.AccountNo;
                model.AccountLevel = treeaccount.AccountLevel + 1;
            }
            else
            {
                model.Accprev = null;
                model.AccountLevel = 1;
            }
            ViewBag.AccTypeId = new SelectList(_Acctype.GetAccountClassificationTypes(), "Id", "Name");
            ViewBag.AccClassificationId = new SelectList(_AccClassification.GetAccountClassifications(), "Id", "DescriptionAr");
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddPost(AccountTreeViewModel accTreeViewModel)
        {
            ViewBag.AccTypeId = new SelectList(_Acctype.GetAccountClassificationTypes(), "Id", "Name", accTreeViewModel.AccTypeId);
            ViewBag.AccClassificationId = new SelectList(_AccClassification.GetAccountClassifications(), "Id", "DescriptionAr", accTreeViewModel.AccClassificationId);
            if (accTreeViewModel.Id == 0)
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    var accTree = _mapper.Map<AccountTree>(accTreeViewModel);
                    _tree.AddAccountTree(accTree);
                    _toastNotification.AddSuccessToastMessage("تم أضافة حساب الشجرة بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), accTreeViewModel);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var accTree = _mapper.Map<AccountTree>(accTreeViewModel);
                    _tree.UpdateAccountTree(accTreeViewModel.Id, accTree);
                    _toastNotification.AddSuccessToastMessage("تم تعديل حساب الشجرة  بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), accTreeViewModel);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accTree = _tree.GetAccountTreeById((int)id);
            var accountTreeViewModel = _mapper.Map<AccountTreeViewModel>(accTree);
            if (accTree == null)
            {
                return NotFound();
            }
            ViewBag.AccTypeId = new SelectList(_Acctype.GetAccountClassificationTypes(), "Id", "Name" , accountTreeViewModel.AccTypeId);
            ViewBag.AccClassificationId = new SelectList(_AccClassification.GetAccountClassifications(), "Id", "DescriptionAr", accountTreeViewModel.AccClassificationId);
            return View("Add", accountTreeViewModel);
        }
    }
}