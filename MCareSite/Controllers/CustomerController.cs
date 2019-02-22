using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    public class CustomerController : Controller
    {
        private readonly NajmetAlraqeeContext _context;
        private readonly ICustomerRepository _customer;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public CustomerController(NajmetAlraqeeContext context, ICustomerRepository customer, IMapper mapper, IToastNotification toastNotification)
        {
            _context = context;
            _customer = customer;
            _mapper = mapper;
            _toastNotification = toastNotification;
        }

        #region Index 
        public IActionResult Index(int? page)
        {
            var customer = _customer.GetCustomers();
            ViewBag.Customers = customer;
            //if (nationality.Count() <= 10) { page = 1; }
            //int pageSize = 10;
            return View();
        }
        #endregion

        #region Details
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customer.GetCustomerById((long)id);
            var customerViewModels = _mapper.Map<CustomerViewModel>(customer);
            if (customerViewModels == null)
            {
                return NotFound();
            }

            return View(customerViewModels);
        }
        #endregion


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddPost(CustomerViewModel customerViewModels)
        {
            if (customerViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                if (ModelState.IsValid)
                {
                    var customer = _mapper.Map<Customer>(customerViewModels);
                    _customer.AddCustomer(customer);
                    _toastNotification.AddSuccessToastMessage("تم أضافةبيانات العميل بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                _toastNotification.AddWarningToastMessage("الرجاء ادخال الوظيفة");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var customer = _mapper.Map<Customer>(customerViewModels);
                    _customer.UpdateCustomer(customerViewModels.Id, customer);
                    _toastNotification.AddSuccessToastMessage("تم تعديل بيانات العميل بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                _toastNotification.AddWarningToastMessage("الرجاء ادخال الوظيفة");
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customer.GetCustomerById((int)id);
            var customerViewModel = _mapper.Map<CustomerViewModel>(customer);
            if (customer == null)
            {
                return NotFound();
            }
            var customerlist = _customer.GetCustomers();
            ViewBag.customers = customerlist;
            return View("Index", customerViewModel);
        }

        #region Delete

        public IActionResult Delete(long id)
        {
            _customer.RemoveCustomer(id);
            _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion 

    }
}