using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    public class PaymentMethodController : Controller
    {
        private readonly IPaymentMethodRepository _payment;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public PaymentMethodController(IPaymentMethodRepository payment, IMapper mapper, IToastNotification toastNotification)
        {
            _payment = payment;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        #region Index 
        public IActionResult Index(int? page)
        {
            var PaymentMethodsList = _payment.GetPaymentMethods();
            ViewBag.PaymentMethod = PaymentMethodsList;
            //if (nationality.Count() <= 10) { page = 1; }
            //int pageSize = 10;
            return View();
        }
        #endregion




        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddPost(PaymentMethodViewModel paymentMethodViewModels)
        {
            var paymentMethodList = _payment.GetPaymentMethods();
            ViewBag.PaymentMethod = paymentMethodList;
            if (paymentMethodViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    var paymentMethod = _mapper.Map<PaymentMethod>(paymentMethodViewModels);
                    _payment.AddPaymentMethod(paymentMethod);
                    _toastNotification.AddSuccessToastMessage("تم بيانات طرقة الدفع بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), paymentMethodViewModels);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var paymentMethod = _mapper.Map<PaymentMethod>(paymentMethodViewModels);
                    _payment.UpdatePaymentMethod(paymentMethodViewModels.Id, paymentMethod);
                    _toastNotification.AddSuccessToastMessage("تم تعديل طريقة الدفع بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Index), paymentMethodViewModels);
            }
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethod = _payment.GetPaymentMethodById((int)id);
            var paymentMethodViewModel = _mapper.Map<PaymentMethodViewModel>(paymentMethod);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            var paymentMethodList = _payment.GetPaymentMethods();
            ViewBag.PaymentMethod = paymentMethodList;
            return View("Index", paymentMethodViewModel);
        }

        #region Delete

        public IActionResult Delete(int id)
        {
            _payment.RemovePaymentMethod(id);
            _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion 
    }
}