using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.Services;
using NajmetAlraqee.Site.ViewModels;
using NajmetAlraqeeSite.Services;
using NToastNotify;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace NajmetAlraqee.Site.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly NajmetAlraqeeContext _context;
        private readonly ICustomerRepository _customer;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IDelegateReository _userdelegate;
        public readonly ICustomerTypeRepository _customertype;
        private readonly IHostingEnvironment _environment;

        public CustomerController(NajmetAlraqeeContext context, IHostingEnvironment environment, ICustomerTypeRepository customertype, ICustomerRepository customer, IDelegateReository userdelegate, IMapper mapper, IToastNotification toastNotification)
        {
            _context = context;
            _customer = customer;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _userdelegate = userdelegate;
            _customertype = customertype;
            _environment = environment;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page, string SearchString)
        {
            var customerList = _customer.GetCustomers();

            if (SearchString != null)
            {
                customerList = _customer.GetCustomers().Where(x => x.FirstName.Contains(SearchString));
            }
            else
            {
                customerList = _customer.GetCustomers();
            }
            
            if (customerList.Count() <= 10) { page = 1; }
            int pageSize = 10;
            var customerpaging = await PaginatedList<Customer>.CreateAsync(customerList.AsNoTracking(), page ?? 1, pageSize);
            ViewBag.Customers = customerpaging;
            return View(customerpaging);
        }
        #endregion

        #region Details
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = _customer.GetCustomerById((int)id);
            var customerViewModel = _mapper.Map<CustomerViewModel>(customer);
            if (customer != null)
            {
                customerViewModel.UserDelegateName = customer.UserDelegate.Name;
                customerViewModel.CustomerTypeName = customer.CustomerType.Name;
            }

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }
        #endregion


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.CustomerTypeId = new SelectList(_customertype.GetCustomerTypes(), "Id", "Name");
            ViewBag.DelegateId = new SelectList(_userdelegate.GetDelegates(), "Id", "Name");
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CustomerViewModel customerViewModels)
        {
            ViewBag.CustomerTypeId = new SelectList(_customertype.GetCustomerTypes(), "Id", "Name", customerViewModels.CustomerTypeId);
            ViewBag.DelegateId = new SelectList(_userdelegate.GetDelegates(), "Id", "Name", customerViewModels.UserDelegateId);
            string familyImageValue = null;
            string identiyImageValue = null;
            if (customerViewModels.FamilyImageFile != null)
            {
                familyImageValue = await FileService.UploadFileAsync(customerViewModels.FamilyImageFile, _environment);
                customerViewModels.FamilyImage = familyImageValue;
            }
            if (customerViewModels.IdentiyImageFile != null)
            {
                identiyImageValue = await FileService.UploadFileAsync(customerViewModels.IdentiyImageFile, _environment);
                customerViewModels.IdentiyImage = identiyImageValue;
            }

            if (customerViewModels.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("CustomerTypeId");
                ModelState.Remove("UserDelegateId");
                if (ModelState.IsValid)
                {
                    var customer = _mapper.Map<Customer>(customerViewModels);
                    _customer.AddCustomer(customer);
                    _toastNotification.AddSuccessToastMessage("تم أضافة بيانات العميل بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View(customerViewModels);
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
                return View(customerViewModels);
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
            ViewBag.Customers = customerlist;
            ViewBag.CustomerTypeId = new SelectList(_customertype.GetCustomerTypes(), "Id", "Name");
            ViewBag.DelegateId = new SelectList(_userdelegate.GetDelegates(), "Id", "Name");

            return View("Add", customerViewModel);
        }

        #region Delete

        public IActionResult Delete(int id)
        {
            _customer.RemoveCustomer(id);
            _toastNotification.AddSuccessToastMessage("تم حذف العميل بنجاح");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Activated(int id)
        {
            var item = _customer.GetCustomerById(id);
            item.IsActive = true;
            _customer.ActivationCustomer(id, item);
            _toastNotification.AddSuccessToastMessage("تم التفعيل بنجاح");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DisActivated(int id)
        {
            var item = _customer.GetCustomerById(id);
            item.IsActive = false;
            _customer.ActivationCustomer(id, item);
            _toastNotification.AddSuccessToastMessage("تم الايقاف بنجاح");
            return RedirectToAction(nameof(Index));
        }
        #endregion

        //public IActionResult TestTable()
        //{
        //    try
        //    {
        //        string draw = HttpContext.Request.Form["draw"].FirstOrDefault();
        //        // Skiping number of Rows count  
        //        var start = Request.Form["start"].FirstOrDefault();
        //        // Paging Length 10,20  
        //        var length = Request.Form["length"].FirstOrDefault();
        //        // Sort Column Name  
        //        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        //        // Sort Column Direction ( asc ,desc)  
        //        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        //        // Search Value from (Search box)  
        //        var searchValue = Request.Form["search[value]"].FirstOrDefault();

        //        //Paging Size (10,20,50,100)  
        //        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        //        int skip = start != null ? Convert.ToInt32(start) : 0;
        //        int recordsTotal = 0;

        //        // Getting all Customer data  
        //        var customerData = (from tempcustomer in _customer.GetCustomers()
        //                            select tempcustomer);

        //        //Sorting  
        //        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        //        {
        //            customerData = customerData.OrderBy(x=>x.Id);
        //        }
        //        //Search  
        //        if (!string.IsNullOrEmpty(searchValue))
        //        {
        //            customerData = customerData.Where(m => m.Name == searchValue);
        //        }

        //        //total number of rows count   
        //        recordsTotal = customerData.Count();
        //        //Paging   
        //        var data = customerData.Skip(skip).Take(pageSize).ToList();
        //        //Returning Json Data  
        //        return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

        //    }
        //    catch (Exception ex )
        //    {
        //        throw ex ;
        //    }

        //}  


    }
}