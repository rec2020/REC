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
    public class ContractReturnController : Controller
    {
        private readonly IContractReturnRepository _contrat_return;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IReturnReasonRepository _reason;
        private readonly IUserRepository _user;
        private readonly IContractRepository _contract;
        private readonly IEmployeeRepository _emp;
        private readonly IContractTypeRepository _type;

        public ContractReturnController(IContractRepository contract, IContractTypeRepository type, IEmployeeRepository emp, IContractReturnRepository contrat_return, IUserRepository user, IReturnReasonRepository reason, IMapper mapper, IToastNotification toastNotification)
        {
            _user = user;
            _contrat_return = contrat_return;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _reason = reason;
            _contract = contract;
            _emp = emp;
            _type = type;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page, string SearchString)
        {
            var contractReturnList = _contrat_return.GetContractReturns();

            if (SearchString != null)
            {
                contractReturnList = _contrat_return.GetContractReturns();
            }
            else
            {
                contractReturnList = _contrat_return.GetContractReturns();
            }
            ViewBag.ContractReturns = contractReturnList;
            if (contractReturnList.Count() <= 10) { page = 1; }
            int pageSize = 10;
            return View(await PaginatedList<ContractReturn>.CreateAsync(contractReturnList.AsNoTracking(), page ?? 1, pageSize));
        }
        #endregion

        #region Add
        [HttpGet]
        public IActionResult Add(int contractId)
        {
            ContractReturnViewModel contractReturn = new ContractReturnViewModel
            {
                ContractId = contractId
            };
            var contract = _contract.GetContractById((int)contractReturn.ContractId);
            if (contract != null)
            {
                contractReturn.ContractTypeId = contract.ContractTypeId;
                contractReturn.ContractTypeName = contract.ContractType.Name;
                contractReturn.EmployeeId = contract.EmployeeId;
            }
            ViewBag.ReturnReasonId = new SelectList(_reason.GetReturnReasons(), "Id", "Name");
            return View(contractReturn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ContractReturnViewModel contractReturnViewModel)
        {
            var actionbyname = User.Identity.Name;
            var actionByid = _user.GetUserByName(actionbyname);
            contractReturnViewModel.CreatedById = actionByid.Id;
            ViewBag.ReturnReasonId = new SelectList(_reason.GetReturnReasons(), "Id", "Name");
            if (contractReturnViewModel.ReturnReasonId ==1) {
                ModelState.Remove("KafeelName");
                ModelState.Remove("KafeelPhone");
                ModelState.Remove("KafeelAddress");
                ModelState.Remove("KfalaTranportDate");
                ModelState.Remove("ExitDate");
                ModelState.Remove("AirLine");
                ModelState.Remove("ExitTime");
                ModelState.Remove("CancelDate");
                ModelState.Remove("CancelNote");
            }
            if (contractReturnViewModel.ReturnReasonId == 2) {
                ModelState.Remove("ExitDate");
                ModelState.Remove("EmployeeReturnDate");
                ModelState.Remove("ExitTime");
                ModelState.Remove("AirLine");
                ModelState.Remove("CancelDate");
                ModelState.Remove("CancelNote");
            }
            if (contractReturnViewModel.ReturnReasonId == 3)
            {
                
                ModelState.Remove("EmployeeReturnDate");
                ModelState.Remove("KafeelName");
                ModelState.Remove("KafeelPhone");
                ModelState.Remove("KafeelAddress");
                ModelState.Remove("KfalaTranportDate");
                ModelState.Remove("CancelDate");
                ModelState.Remove("CancelNote");
            }
            if (contractReturnViewModel.ReturnReasonId == 4) {
                ModelState.Remove("EmployeeReturnDate");
                ModelState.Remove("KafeelName");
                ModelState.Remove("KafeelPhone");
                ModelState.Remove("KafeelAddress");
                ModelState.Remove("KfalaTranportDate");
                ModelState.Remove("ExitDate");
                ModelState.Remove("ExitTime");
                ModelState.Remove("AirLine");
            }
            if (contractReturnViewModel.ReturnReasonId == null) { ModelState.AddModelError("", "الرجاء تحديد نوع العقد"); }
            ModelState.Remove("ReturnReasonId");
            if (ModelState.IsValid)
            {
                var contractReturn = _mapper.Map<ContractReturn>(contractReturnViewModel);
                _contrat_return.AddContractReturn(contractReturn);
                _toastNotification.AddSuccessToastMessage("تم الاسترجاع بنجاح");
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Add), contractReturnViewModel);

        }
        //return View("Index",currencyViewModel);
        #endregion

        #region Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contract = _contrat_return.GetContractReturnById((int)id);
            var contractReturnViewModels = _mapper.Map<ContractReturnViewModel>(contract);
            if (contract == null)
            {
                return NotFound();
            }
            return View(contract);
        }
        #endregion

        //#region Edit
        //public IActionResult Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var contractDelegate = _delegate.GetContractDelegationById((int)id);
        //    var contractDelegateViewModel = _mapper.Map<ContractDelegateViewModel>(contractDelegate);
        //    if (contractDelegate == null)
        //    {
        //        return NotFound();
        //    }
        //    var contractDelegationList = _delegate.GetContractDelegations();
        //    ViewBag.ContractDelegation = contractDelegationList;
        //    ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName", contractDelegateViewModel.ForeignAgencyId);
        //    return View("Index", contractDelegateViewModel);
        //}


        //#endregion

        //#region Delete

        //public IActionResult Delete(int? id)
        //{
        //    _delegate.RemoveContractDelegation((int)id);
        //    _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
        //    return RedirectToAction(nameof(Index));
        //}

        //#endregion
    }
}