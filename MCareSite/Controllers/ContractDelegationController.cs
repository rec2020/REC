using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    [Authorize]
    public class ContractDelegationController : Controller
    {
        private readonly IContractRepository _contrat;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IContractDelegateRepository _delegate;
        private readonly IForeignAgencyRepository _agency;
        private readonly IUserRepository _user;

        public ContractDelegationController(IContractRepository contract, IUserRepository user, IForeignAgencyRepository agency, IContractDelegateRepository deleg, IMapper mapper, IToastNotification toastNotification)
        {
            _user = user;
            _contrat = contract;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _delegate = deleg;
            _agency = agency;
        }

        #region Index 
        public IActionResult Index(int ContractId)
        {
            ContractDelegateViewModel deleget = new ContractDelegateViewModel
            {
                ContractId = ContractId
            };
            var contractDelegationList = _delegate.GetContractDelegations().Where(x=>x.ContractId == ContractId);
            ViewBag.ContractDelegation = contractDelegationList;
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName");
            return View(deleget);
        }
        #endregion



        [HttpGet]
        public IActionResult Add()
        {
            var contractDelegationList = _delegate.GetContractDelegations();
            ViewBag.ContractDelegation = contractDelegationList;
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ContractDelegateViewModel delegetViewModel)
        {
            delegetViewModel.DelegateByName = User.Identity.Name;
            var delegateByid = _user.GetUserByName(delegetViewModel.DelegateByName);
            delegetViewModel.DelegateById = delegateByid.Id;
            var contractDelegationList = _delegate.GetContractDelegations().Where(x => x.ContractId == delegetViewModel.ContractId);
            ViewBag.ContractDelegation = contractDelegationList;
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName", delegetViewModel.ForeignAgencyId);
            if (delegetViewModel.ForeignAgencyId == null) { ModelState.AddModelError("", "الرجاء تحديد الوكالة الخارجية"); }
            if (delegetViewModel.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("ForeignAgencyId");
                if (ModelState.IsValid)
                {
                    var selectDelegate = _mapper.Map<ContractDelegation>(delegetViewModel);
                    _delegate.AddContractDelegation(selectDelegate);
                    _toastNotification.AddSuccessToastMessage("تم التفويض بنجاح");
                    return RedirectToAction(nameof(Index),new { ContractId = delegetViewModel.ContractId });
                }
                return View(nameof(Index), delegetViewModel);
            }
            else
            {
                ModelState.Remove("ForeignAgencyId");
                if (ModelState.IsValid)
                {
                    var selectDelegate = _mapper.Map<ContractDelegation>(delegetViewModel);
                    _delegate.UpdateContractDelegation(delegetViewModel.Id, selectDelegate);
                    _toastNotification.AddSuccessToastMessage("تم تعديل التفويض بنجاح");
                    return RedirectToAction(nameof(Index), new { ContractId = delegetViewModel.ContractId });
                }
                return View(nameof(Index), delegetViewModel);
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

            var contractDelegate = _delegate.GetContractDelegationById((int)id);
            var contractDelegateViewModel = _mapper.Map<ContractDelegateViewModel>(contractDelegate);
            if (contractDelegate == null)
            {
                return NotFound();
            }
            var contractDelegationList = _delegate.GetContractDelegations().Where(x => x.ContractId == contractDelegate.ContractId); ;
            ViewBag.ContractDelegation = contractDelegationList;
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName", contractDelegateViewModel.ForeignAgencyId);
            return View("Index", contractDelegateViewModel);
        }


        #endregion

        #region Delete

        public IActionResult Delete(int? id)
        {
            _delegate.RemoveContractDelegation((int)id);
            _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}