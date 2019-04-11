using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    public class ContractSelectController : Controller
    {
        private readonly IContractRepository _contrat;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IContractSelectRepository _select;
        private readonly IForeignAgencyRepository _agency;
        private readonly IUserRepository _user;

        public ContractSelectController(IContractRepository contract, IUserRepository user, IForeignAgencyRepository agency, IContractSelectRepository select, IMapper mapper, IToastNotification toastNotification)
        {
            _contrat = contract;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _select = select;
            _user = user;
            _agency = agency;
        }

        #region Index 
        public IActionResult Index(int ContractId )
        {
            ContractSelectViewModel select = new ContractSelectViewModel();
            select.ContractId = ContractId;
            var contractSelectList = _select.GetContractSelects();
            ViewBag.ContractSelect = contractSelectList;
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName");
            return View(select);
        }
        #endregion



        [HttpGet]
        public IActionResult Add()
        {
            var contractSelectList = _select.GetContractSelects();
            ViewBag.ContractSelect = contractSelectList;
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ContractSelectViewModel selectViewModel)
        {
            selectViewModel.SelectByName = User.Identity.Name;
            var selectById = _user.GetUserByName(selectViewModel.SelectByName);
            selectViewModel.SelectById = selectById.Id;
            var contractSelectList = _select.GetContractSelects();
            ViewBag.ContractSelect = contractSelectList;
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName", selectViewModel.ForeignAgencyId);
            if (selectViewModel.ForeignAgencyId == null) { ModelState.AddModelError("", "الرجاء تحديد الوكالة الخارجية"); }
            if (selectViewModel.Id == 0)
            {
                ModelState.Remove("Id");
                ModelState.Remove("ForeignAgencyId");
                if (ModelState.IsValid)
                {
                   
                    var selectcontract = _mapper.Map<ContractSelect>(selectViewModel);
                    _select.AddContractSelect(selectcontract);
                    _toastNotification.AddSuccessToastMessage("تم الاختيار بنجاح");
                    return RedirectToAction(nameof(Index), new { ContractId = selectViewModel.ContractId });
                }
                return View(nameof(Index), selectViewModel);
            }
            else
            {
                ModelState.Remove("ForeignAgencyId");
                if (ModelState.IsValid)
                {
                    var selectcontract = _mapper.Map<ContractSelect>(selectViewModel);
                    _select.UpdateContractSelect(selectViewModel.Id, selectcontract);
                    _toastNotification.AddSuccessToastMessage("تم تعديل الاختيار بنجاح");
                    return RedirectToAction(nameof(Index),new { ContractId = selectViewModel.ContractId });
                }
                return View(nameof(Index), selectViewModel);
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

            var contractSelected = _select.GetContractSelectById((int)id);
            var contractselectedViewModel = _mapper.Map<ContractSelectViewModel>(contractSelected);
            if (contractSelected == null)
            {
                return NotFound();
            }
            var contractSelectList = _select.GetContractSelects();
            ViewBag.ContractSelect = contractSelectList;
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName");
            return View("Index", contractselectedViewModel);
        }


        #endregion

        #region Delete

        public IActionResult Delete(int? id)
        {
            _select.RemoveContractSelect((int)id);
            _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}