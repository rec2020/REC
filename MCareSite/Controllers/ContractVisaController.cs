using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    [Authorize]
    public class ContractVisaController : Controller
    {
        private readonly IContractRepository _contrat;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IContractVisaRepository _visa;
        private readonly IEmployeeRepository _employee;
        private readonly IUserRepository _user; 

        public ContractVisaController(IContractRepository contract, IUserRepository user, IEmployeeRepository employee, IContractVisaRepository visa, IMapper mapper, IToastNotification toastNotification)
        {
            _contrat = contract;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _visa = visa;
            _employee = employee;
            _user = user;
        }

        #region Index 
        public IActionResult Index(int ContractId)
        {
            ContractVisaViewModel visa = new ContractVisaViewModel();
            visa.ContractId = ContractId;
            var contractVisaList = _visa.GetContractVisas().Where(x=>x.ContractId== ContractId);
            ViewBag.ContractVisa = contractVisaList;
            ViewBag.EmployeeId = new SelectList(_employee.GetEmployees(), "Id", "FirstName");
            return View(visa);
        }
        #endregion



        [HttpGet]
        public IActionResult Add()
        {
            var contractVisaList = _visa.GetContractVisas();
            ViewBag.ContractVisa = contractVisaList;
            ViewBag.EmployeeId = new SelectList(_employee.GetEmployees().Where(x=>x.EmployeeStatusId==(int)EnumHelper.EmployeeStatus.New), "Id", "FirstName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ContractVisaViewModel visaViewModel)
        {
           
            visaViewModel.VisaByName = User.Identity.Name;
            var visitbyid = _user.GetUserByName(visaViewModel.VisaByName);
            visaViewModel.VisaById = visitbyid.Id;
            var contractVisaList = _visa.GetContractVisas().Where(x => x.ContractId == visaViewModel.ContractId);
            ViewBag.ContractVisa = contractVisaList;
            ViewBag.EmployeeId = new SelectList(_employee.GetEmployees().Where(x => x.EmployeeStatusId == (int)EnumHelper.EmployeeStatus.New), "Id", "FirstName",visaViewModel.EmployeeId);
            if (visaViewModel.EmployeeId == null) { ModelState.AddModelError("", "الرجاء تحدد الموظف"); }
            if (visaViewModel.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("EmployeeId");
                if (ModelState.IsValid)
                {
                    var visacontract = _mapper.Map<ContractVisa>(visaViewModel);
                    _visa.AddContractVisa(visacontract);
                    _toastNotification.AddSuccessToastMessage("تم التفيز بنجاح");
                    return RedirectToAction(nameof(Index), new { ContractId = visaViewModel.ContractId });
                }
                return View(nameof(Index), visaViewModel);
            }
            else
            {
                ModelState.Remove("EmployeeId");
                if (ModelState.IsValid)
                {
                    var visacontract = _mapper.Map<ContractVisa>(visaViewModel);
                    _visa.UpdateContractVisa(visaViewModel.Id, visacontract);
                    _toastNotification.AddSuccessToastMessage("تم تعديل التفيز بنجاح");
                    return RedirectToAction(nameof(Index), new { ContractId = visaViewModel.ContractId });
                }
                return View(nameof(Index), visaViewModel);
            }

        }
        //return View("Index",currencyViewModel);




        #region Edit
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contractVisa = _visa.GetContractVisaById((int)id);
            var contractVisaViewModel = _mapper.Map<ContractVisaViewModel>(contractVisa);
            if (contractVisa == null)
            {
                return NotFound();
            }
            var contractVisaList = _visa.GetContractVisas().Where(x => x.ContractId == contractVisa.ContractId); ;
            ViewBag.ContractVisa = contractVisaList;
            ViewBag.EmployeeId = new SelectList(_employee.GetEmployees().Where(x => x.EmployeeStatusId == (int)EnumHelper.EmployeeStatus.New), "Id", "FirstName", contractVisa.EmployeeId);
            return View("Index", contractVisaViewModel);
        }


        #endregion

        #region Delete

        public IActionResult Delete(int? id)
        {
            _visa.RemoveContractVisa((int)id);
            _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}