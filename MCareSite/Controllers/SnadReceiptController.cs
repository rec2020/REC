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
using NajmetAlraqeeSite.Controllers;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    public class SnadReceiptController : Controller
    {
        #region Filed 
        private readonly ISnadReceiptTypeRepository _type;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IPaymentMethodRepository _method;
        private readonly IExpenseRepository _expense;
        private readonly ISnadReceiptRepository _snad;


        #endregion
        public SnadReceiptController(
            ISnadReceiptTypeRepository type,IMapper mapper,
            IToastNotification toastNotification, IExpenseRepository expense,
             IPaymentMethodRepository method , ISnadReceiptRepository snad
           )
        {
            _type = type;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _expense = expense;
            _method = method;
            _snad = snad;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page, string SearchString)
        {
            var snadList = _snad.GetSnadReceipts();
            //if (SearchString != null)
            //{
            //    snadList = _snad.GetSnadReceipts().Where(x => x..Contains(SearchString));
            //}
            //else
            //{
            //    snadList = _snad.GetSnadReceipts();
            //}

            if (snadList.Count() <= 10) { page = 1; }
            int pageSize = 10;
            var SnadReceiptPagng = await PaginatedList<SnadReceipt>.CreateAsync((snadList).AsNoTracking(), page ?? 1, pageSize);
            ViewBag.SnadList = SnadReceiptPagng;
            return View(SnadReceiptPagng);
        }
        #endregion

        #region Details
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var snad = _snad.GetSnadReceiptById((int)id);
            if (snad == null)
            {
                return NotFound();
            }
            return View(snad);
        }
        #endregion

        #region Add

        [HttpGet]
        public IActionResult Add()
        {
            SnadReceiptViewModel snad = new SnadReceiptViewModel();
            snad.SnadDate = DateTime.Now.ToString("d", CultureInfo.InvariantCulture);
            ViewBag.ExpenseId = new SelectList(_expense.GetExpenses(), "Id", "Name");
            ViewBag.PaymentMethodId = new SelectList(_method.GetPaymentMethods(), "Id", "Name");
            ViewBag.SnadReceiptTypeId = new SelectList(_type.GetSnadReceiptTypes(), "Id", "Name");
            return View(snad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(SnadReceiptViewModel snadReceiptViewModels)
        {
            ViewBag.SnadReceiptCaluseId = new SelectList(_expense.GetExpenses(), "Id", "Name");
            ViewBag.PaymentMethodId = new SelectList(_method.GetPaymentMethods(), "Id", "Name");
            ViewBag.SnadReceiptTypeId = new SelectList(_type.GetSnadReceiptTypes(), "Id", "Name");
            snadReceiptViewModels.SnadByUserName = User.Identity.Name;
            if (snadReceiptViewModels.ExpenseId == null) { ModelState.AddModelError("", "الرجاء تحديد بند الصرف "); }
            if (snadReceiptViewModels.PaymentMethodId == null) { ModelState.AddModelError("", "الرجاء تحديد طريقة الصرف "); }
            if (snadReceiptViewModels.SnadReceiptTypeId == null) { ModelState.AddModelError("", "الرجاء تحدد نوع سند الصرف "); }
            if (snadReceiptViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("SnadReceiptCaluseId");
                ModelState.Remove("PaymentMethodId");
                ModelState.Remove("SnadReceiptTypeId");
                if (ModelState.IsValid)
                {

                    var snad = _mapper.Map<SnadReceipt>(snadReceiptViewModels);
                    _snad.AddSnadReceipt(snad);
                    _toastNotification.AddSuccessToastMessage("تم أضافة سند الصرف ");
                    return RedirectToAction(nameof(Index));
                }

                return View(snadReceiptViewModels);
            }
            else
            {
                ModelState.Remove("Id");
                ModelState.Remove("SnadReceiptCaluseId");
                ModelState.Remove("PaymentMethodId");
                ModelState.Remove("SnadReceiptTypeId");
                if (ModelState.IsValid)
                {
                    var snad = _mapper.Map<SnadReceipt>(snadReceiptViewModels); ;
                    _snad.UpdateSnadReceipt(snadReceiptViewModels.Id, snad);
                    _toastNotification.AddSuccessToastMessage("تم تعديل  سند الصرف ");
                    return RedirectToAction(nameof(Index));
                }
                return View("Add", snadReceiptViewModels);
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

            var snad = _snad.GetSnadReceiptById((int)id);
            var snadReceiptViewModels = _mapper.Map<SnadReceiptViewModel>(snad);
            if (snad == null)
            {
                return NotFound();
            }
            ViewBag.ExpenseId = new SelectList(_expense.GetExpenses(), "Id", "Name" , snadReceiptViewModels.ExpenseId );
            ViewBag.PaymentMethodId = new SelectList(_method.GetPaymentMethods(), "Id", "Name", snadReceiptViewModels.PaymentMethodId);
            ViewBag.SnadReceiptTypeId = new SelectList(_type.GetSnadReceiptTypes(), "Id", "Name", snadReceiptViewModels.SnadReceiptTypeId);
            return View("Add", snadReceiptViewModels);
        }
        #endregion
    }
}