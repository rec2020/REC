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
    public class ForeignAgencyTransferController : Controller
    {
        #region Filed 
        private readonly IForeignAgencyRepository _agency;
        private readonly IForeignAgencyTransferRepository _agencyTransfer;
        private readonly ITransferPurposeRepository _purpose;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IBankDetailRepository _bank;
        private readonly IPaymentMethodRepository _payment;
        private readonly ICurrencyRepository _currency;

        #endregion
        public ForeignAgencyTransferController(IForeignAgencyTransferRepository agencyTransfer,
            IMapper mapper,ITransferPurposeRepository purpose, ICurrencyRepository currency,
            IToastNotification toastNotification
            , INationalityRepository nationality, 
            IBankDetailRepository bank,
            IForeignAgencyRepository agency,
            IPaymentMethodRepository payment
          )
        {
            _agencyTransfer = agencyTransfer;
            _purpose = purpose;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _bank = bank;
            _payment = payment;
            _agency = agency;
            _currency = currency;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page, string SearchString)
        {
            var agencyList = _agencyTransfer.GetForeignAgencyTransfers();

            if (SearchString != null)
            {
                agencyList = _agencyTransfer.GetForeignAgencyTransfers().Where(x => x.ForeignAgency.OfficeName.Contains(SearchString));
            }
            else
            {
                agencyList = _agencyTransfer.GetForeignAgencyTransfers();
            }

           
            if (agencyList.Count() <= 10) { page = 1; }
            int pageSize = 10;
            var foreignAgencypaging = await PaginatedList<ForeignAgencyTransfer>.CreateAsync((agencyList).AsNoTracking(), page ?? 1, pageSize);
            ViewBag.AgencyTransfer = foreignAgencypaging;
            return base.View(foreignAgencypaging);
        }
        #endregion

        #region Details
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var agencytransfer = _agencyTransfer.GetForeignAgencyTransferById((int)id);
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
            ForeignAgencyTransferViewModel agencyTransfer = new ForeignAgencyTransferViewModel();
            agencyTransfer.TransferDate = DateTime.Now.ToString("d", CultureInfo.InvariantCulture);
            ViewBag.PurposeId = new SelectList(_purpose.GetTransferPurposes(), "Id", "Name");
            ViewBag.CurrencyId = new SelectList(_currency.GetCurrencies(), "Id", "Name");
            ViewBag.TransferBankId = new SelectList(_bank.GetBankDetails(), "Id", "Name");
            ViewBag.PaymentMethodId = new SelectList(_payment.GetPaymentMethods(), "Id", "Name");
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName");
            return View(agencyTransfer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ForeignAgencyTransferViewModel agencytransferViewModels)
        {
            ViewBag.PurposeId = new SelectList(_purpose.GetTransferPurposes(), "Id", "Name");
            ViewBag.TransferBankId = new SelectList(_bank.GetBankDetails(), "Id", "Name");
            ViewBag.CurrencyId = new SelectList(_currency.GetCurrencies(), "Id", "Name");
            ViewBag.PaymentMethodId = new SelectList(_payment.GetPaymentMethods(), "Id", "Name");
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName");
            if (agencytransferViewModels.PurposeId == null) { ModelState.AddModelError("", "الرجاء ادخال الغرض من التحويل"); }
            if (agencytransferViewModels.CurrencyId == null) { ModelState.AddModelError("", "الرجاء ادخال نوع العملة"); }
            if (agencytransferViewModels.TransferBankId == null) { ModelState.AddModelError("", "الرجاء ادخال نوع البنك"); }
            if (agencytransferViewModels.PaymentMethodId == null) { ModelState.AddModelError("", "الرجاء ادخال طريقة الدفع "); }
            if (agencytransferViewModels.ForeignAgencyId == null) { ModelState.AddModelError("", "الرجاء تحديد الوكيل  "); }
            if (agencytransferViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("PurposeId");
                ModelState.Remove("CurrencyId");
                ModelState.Remove("TransferBankId");
                ModelState.Remove("PaymentMethodId");
                ModelState.Remove("ForeignAgencyId");
                if (ModelState.IsValid)
                {
                    var agency = _mapper.Map<ForeignAgencyTransfer>(agencytransferViewModels);
                    _agencyTransfer.AddForeignAgencyTransfer(agency);
                    _toastNotification.AddSuccessToastMessage("تم التحويل  للوكيل بنجاح  ");
                    return RedirectToAction(nameof(Index));
                }

                return View(agencytransferViewModels);
            }
            else
            {
                ModelState.Remove("PurposeId");
                ModelState.Remove("CurrencyId");
                ModelState.Remove("TransferBankId");
                ModelState.Remove("PaymentMethodId");
                ModelState.Remove("ForeignAgencyId");
                if (ModelState.IsValid)
                {
                    var agency = _mapper.Map<ForeignAgencyTransfer>(agencytransferViewModels);
                    _agencyTransfer.UpdateForeignAgencyTransfer(agencytransferViewModels.Id, agency);
                    _toastNotification.AddSuccessToastMessage("تم تعديل أجراء التحويل بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View("Add", agencytransferViewModels);
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

            var agencyTransfer = _agencyTransfer.GetForeignAgencyTransferById((int)id);
            var agencyTransferViewModels = _mapper.Map<ForeignAgencyTransferViewModel>(agencyTransfer);
            if (agencyTransfer == null)
            {
                return NotFound();
            }
            ViewBag.CurrencyId = new SelectList(_currency.GetCurrencies(), "Id", "Name", agencyTransferViewModels.CurrencyId);
            ViewBag.PurposeId = new SelectList(_purpose.GetTransferPurposes(), "Id", "Name", agencyTransferViewModels.PurposeId);
            ViewBag.TransferBankId = new SelectList(_bank.GetBankDetails(), "Id", "Name", agencyTransferViewModels.TransferBankId);
            ViewBag.PaymentMethodId = new SelectList(_payment.GetPaymentMethods(), "Id", "Name",agencyTransferViewModels.PaymentMethodId);
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName", agencyTransferViewModels.ForeignAgencyId);
            return View("Add", agencyTransferViewModels);
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