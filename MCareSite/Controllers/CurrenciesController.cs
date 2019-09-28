using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    [Authorize]
    public class CurrenciesController : Controller
    {
        
        private readonly ICurrencyRepository _currency;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly ICurrencyTypeRepository _type; 
        public CurrenciesController(NajmetAlraqeeContext context, ICurrencyRepository currency, ICurrencyTypeRepository type, IMapper mapper, IToastNotification toastNotification)
        {
            _currency = currency;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _type = type;
        }

        #region Index 
        public IActionResult Index(int? page)
        {
            var currency = _currency.GetCurrencies();
            ViewBag.currency = currency;
            ViewBag.CurrencyTypeId = new SelectList(_type.GetCurrencyTypes(), "Id", "Name");
            //if (currency.Count() <= 10) { page = 1; }
            //int pageSize = 10;
            return View();
        }
        #endregion

        

        [HttpGet]
        public IActionResult Add()
        {
            var currencyList = _currency.GetCurrencies();
            ViewBag.currency = currencyList;
            ViewBag.CurrencyTypeId = new SelectList(_type.GetCurrencyTypes(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CurrencyViewModel currencyViewModel)
        {
            var currencyList = _currency.GetCurrencies();
            ViewBag.currency = currencyList;
            ViewBag.CurrencyTypeId = new SelectList(_type.GetCurrencyTypes(), "Id", "Name",currencyViewModel.CurrencyTypeId);
            if (currencyViewModel.CurrencyTypeId == null) { ModelState.AddModelError("","الرجاء تحديد نوع  العملة"); }
            if (currencyViewModel.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("CurrencyTypeId");
                if (ModelState.IsValid)
                {
                    var currency = _mapper.Map<Currency>(currencyViewModel);
                    _currency.AddCurrency(currency);
                    _toastNotification.AddSuccessToastMessage("تم أضافةالعملة بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index),currencyViewModel);
            }
            else
            {
                ModelState.Remove("CurrencyTypeId");
                if (ModelState.IsValid)
                {
                    var currency = _mapper.Map<Currency>(currencyViewModel);
                    _currency.UpdateCurrency(currencyViewModel.Id, currency);
                    _toastNotification.AddSuccessToastMessage("تم تعديل العملة بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), currencyViewModel);
            }

        }
      
        #region Edit
        // GET: Doctors1/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currency = _currency.GetCurrencyById((int)id);
            var currencyViewModel = _mapper.Map<CurrencyViewModel>(currency);
            if (currency == null)
            {
                return NotFound();
            }
            var nano = _currency.GetCurrencies();
            ViewBag.currency = nano;
            ViewBag.CurrencyTypeId = new SelectList(_type.GetCurrencyTypes(), "Id", "Name", currencyViewModel.CurrencyTypeId);
            return View("Index", currencyViewModel);
        }


        #endregion

        #region Delete

        public IActionResult Delete(int? id)
        {
            _currency.RemoveCurrency((int)id);
            _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}