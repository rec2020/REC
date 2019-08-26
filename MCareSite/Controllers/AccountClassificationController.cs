using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    public class AccountClassificationController : Controller
    {
        #region Filed 
        private readonly IAccountClassificationRepository _AccClassification;
        private readonly IAccountClassificationTypeRepository _Acctype;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        #endregion
        public AccountClassificationController(  
            IMapper mapper,
            IToastNotification toastNotification , IAccountClassificationTypeRepository acctype,
            IAccountClassificationRepository accClassification)
        {
            _mapper = mapper;
            _toastNotification = toastNotification;
            _AccClassification = accClassification;
            _Acctype = acctype;

        }


        public IActionResult Index()
        {
            var accountClasificationList = _AccClassification.GetAccountClassifications();
            ViewBag.AccountClasificationList = accountClasificationList;
            ViewBag.TypeId = new SelectList(_Acctype.GetAccountClassificationTypes(), "Id", "Name");
            return View();
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddPost(AccountClassificationViewModel accClassificationViewModel)
        {
            var accountClasificationList = _AccClassification.GetAccountClassifications();
            ViewBag.AccountClasificationList = accountClasificationList;
            ViewBag.TypeId = new SelectList(_Acctype.GetAccountClassificationTypes(), "Id", "Name", accClassificationViewModel.TypeId);
            if (accClassificationViewModel.Id == 0)
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    var accClassification = _mapper.Map<AccountClassification>(accClassificationViewModel);
                    _AccClassification.AddAccountClassification(accClassification);
                    _toastNotification.AddSuccessToastMessage("تم أضافة تبويب الحساب بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), accClassificationViewModel);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var accClassification = _mapper.Map<AccountClassification>(accClassificationViewModel);
                    _AccClassification.UpdateAccountClassification(accClassificationViewModel.Id, accClassification);
                    _toastNotification.AddSuccessToastMessage("تم تعديل تبويب الحساب بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), accClassificationViewModel);
            }
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accClassification = _AccClassification.GetAccountClassificationById((int)id);
            var accountClassificationViewModel = _mapper.Map<AccountClassificationViewModel>(accClassification);
            if (accClassification == null)
            {
                return NotFound();
            }
            var accountClasificationList = _AccClassification.GetAccountClassifications();
            ViewBag.AccountClasificationList = accountClasificationList;
            ViewBag.TypeId = new SelectList(_Acctype.GetAccountClassificationTypes(), "Id", "Name");
            return View("Index", accountClassificationViewModel);
        }
    }
}