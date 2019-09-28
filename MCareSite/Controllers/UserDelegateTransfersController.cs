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
    public class UserDelegateTransfersController : Controller
    {
        #region Filed 
        private readonly IDelegateReository _userdelegate;
        private readonly IDelegateTransferRepository _delegateTransfer;
        private readonly ITransferPurposeRepository _purpose;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IBankDetailRepository _bank;
        private readonly IPaymentMethodRepository _payment;
        private readonly ICurrencyRepository _currency;

        #endregion
        public UserDelegateTransfersController(
            IDelegateTransferRepository delegateTransfer,
            IMapper mapper,
            ITransferPurposeRepository purpose,
            IToastNotification toastNotification,
            INationalityRepository nationality,
            IBankDetailRepository bank,
            IDelegateReository userdelegatre,
            IPaymentMethodRepository payment, ICurrencyRepository currency
          )
        {
            _delegateTransfer = delegateTransfer;
            _purpose = purpose;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _bank = bank;
            _payment = payment;
            _currency = currency;
            _userdelegate = userdelegatre;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page, string SearchString)
        {
            var delegateTransferList = _delegateTransfer.GetDelegateTransfers();

            if (SearchString != null)
            {
                delegateTransferList = _delegateTransfer.GetDelegateTransfers().Where(x => x.UserDelegate.Name.Contains(SearchString));
            }
            else
            {
                delegateTransferList = _delegateTransfer.GetDelegateTransfers();
            }

           
            if (delegateTransferList.Count() <= 10) { page = 1; }
            int pageSize = 10;
            var userDelegationPaging = await PaginatedList<DelegateTransfer>.CreateAsync((delegateTransferList).AsNoTracking(), page ?? 1, pageSize); 
            ViewBag.DelegateTransfer = userDelegationPaging;
            return base.View(userDelegationPaging);
        }
        #endregion

        #region Details
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var agencytransfer = _delegateTransfer.GetDelegateTransferById((int)id);
            //var agencyTransferViewModel = _mapper.Map<ForeignAgencyTransferViewModel>(agencytransfer);
            if (agencytransfer == null)
            {
                return NotFound();
            }
            return View(agencytransfer);
        }
        #endregion

        #region Add

        [HttpGet]
        public IActionResult Add()
        {
            DelegateTransferViewModel agencyTransfer = new DelegateTransferViewModel();
            agencyTransfer.TransferDate = DateTime.Now.ToString("d", CultureInfo.InvariantCulture);
            ViewBag.PurposeId = new SelectList(_purpose.GetTransferPurposes(), "Id", "Name");
            ViewBag.CurrencyId = new SelectList(_currency.GetCurrencies(), "Id", "Name");
            ViewBag.TransferBankId = new SelectList(_bank.GetBankDetails(), "Id", "Name");
            ViewBag.PaymentMethodId = new SelectList(_payment.GetPaymentMethods(), "Id", "Name");
            ViewBag.UserDelegateId = new SelectList(_userdelegate.GetDelegates(), "Id", "Name");
            return View(agencyTransfer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(DelegateTransferViewModel delegatetransferViewModels)
        {
            ViewBag.PurposeId = new SelectList(_purpose.GetTransferPurposes(), "Id", "Name");
            ViewBag.TransferBankId = new SelectList(_bank.GetBankDetails(), "Id", "Name");
            ViewBag.CurrencyId = new SelectList(_currency.GetCurrencies(), "Id", "Name");
            ViewBag.PaymentMethodId = new SelectList(_payment.GetPaymentMethods(), "Id", "Name");
            ViewBag.UserDelegateId = new SelectList(_userdelegate.GetDelegates(), "Id", "Name");
            if (delegatetransferViewModels.PurposeId == null) { ModelState.AddModelError("", "الرجاء ادخال الغرض من التحويل"); }
            if (delegatetransferViewModels.CurrencyId == null) { ModelState.AddModelError("", "الرجاء ادخال نوع العملة"); }
            if (delegatetransferViewModels.TransferBankId == null) { ModelState.AddModelError("", "الرجاء ادخال نوع البنك"); }
            if (delegatetransferViewModels.PaymentMethodId == null) { ModelState.AddModelError("", "الرجاء ادخال طريقة الدفع "); }
            if (delegatetransferViewModels.UserDelegateId == null) { ModelState.AddModelError("", "الرجاء تحديد المندوب  "); }
            if (delegatetransferViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("PurposeId");
                ModelState.Remove("CurrencyId");
                ModelState.Remove("TransferBankId");
                ModelState.Remove("PaymentMethodId");
                ModelState.Remove("UserDelegateId");
                if (ModelState.IsValid)
                {
                    var delegateTreansfer = _mapper.Map<DelegateTransfer>(delegatetransferViewModels);
                    _delegateTransfer.AddDelegateTransfer(delegateTreansfer);
                    _toastNotification.AddSuccessToastMessage("تم التحويل  للوكيل بنجاح  ");
                    return RedirectToAction(nameof(Index));
                }

                return View(delegatetransferViewModels);
            }
            else
            {
                ModelState.Remove("PurposeId");
                ModelState.Remove("TransferBankId");
                ModelState.Remove("CurrencyId");
                ModelState.Remove("PaymentMethodId");
                ModelState.Remove("UserDelegateId");
                if (ModelState.IsValid)
                {
                    var delegateTransfer = _mapper.Map<DelegateTransfer>(delegatetransferViewModels);
                    _delegateTransfer.UpdateDelegateTransfer(delegatetransferViewModels.Id, delegateTransfer);
                    _toastNotification.AddSuccessToastMessage("تم تعديل أجراء التحويل بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View("Add", delegatetransferViewModels);
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

            var delegateTransfer = _delegateTransfer.GetDelegateTransferById((int)id);
            var delegateTransferViewModels = _mapper.Map<DelegateTransferViewModel>(delegateTransfer);
            if (delegateTransfer == null)
            {
                return NotFound();
            }
            ViewBag.PurposeId = new SelectList(_purpose.GetTransferPurposes(), "Id", "Name", delegateTransferViewModels.PurposeId);
            ViewBag.CurrencyId = new SelectList(_currency.GetCurrencies(), "Id", "Name", delegateTransferViewModels.CurrencyId);
            ViewBag.TransferBankId = new SelectList(_bank.GetBankDetails(), "Id", "Name", delegateTransferViewModels.TransferBankId);
            ViewBag.PaymentMethodId = new SelectList(_payment.GetPaymentMethods(), "Id", "Name", delegateTransferViewModels.PaymentMethodId);
            ViewBag.UserDelegateId = new SelectList(_userdelegate.GetDelegates(), "Id", "Name", delegateTransferViewModels.UserDelegateId);
            return View("Add", delegateTransferViewModels);
        }
        #endregion

        //#region Delete

        //public IActionResult Delete(int id)
        //{
        //    _agency.RemoveAggency(id);
        //    _toastNotification.AddSuccessToastMessage("تم حذف الوكالة الخارجية بنجاح");
        //    return RedirectToAction(nameof(Index));
        //}



        //#endregion
    }
}