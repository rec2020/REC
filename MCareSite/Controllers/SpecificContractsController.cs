using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.Services;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    public class SpecificContractsController : Controller
    {
        #region Filed 
        private readonly ICustomerRepository _customer;
        private readonly ISpecificContractRepository _Contract;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly INationalityRepository _nationality;
        private readonly IContractTypeRepository _contract_Type;
        private readonly ICityRepository _city;
        private readonly IJobTypeReository _jobtype;
        private readonly IContractSelectRepository _select;
        private readonly IContractDelegateRepository _delegate;
        private readonly IContractVisaRepository _visa;
        private readonly IContractTicketRepository _ticket;
        private readonly IContractHistoryRepository _history;
        private readonly IUserRepository _user;
        private readonly IEmployeeRepository _emp;
        private readonly IReceiptDocRepository _receipt;
        private readonly IForeignAgencyRepository _agency;
        private readonly ICountryRepository _country;

        #endregion
        public SpecificContractsController(ICityRepository city, IContractTypeRepository contract_Type, ICountryRepository country, IForeignAgencyRepository agency, IEmployeeRepository emp, IReceiptDocRepository receipt, IContractSelectRepository select, IUserRepository user, IContractHistoryRepository history, IContractTicketRepository ticket, IContractVisaRepository visa, IContractDelegateRepository deleg, IJobTypeReository jobtype, ICustomerRepository customer, INationalityRepository nationality, ISpecificContractRepository contract, IMapper mapper, IToastNotification toastNotification)
        {
            _contract_Type = contract_Type;
            _receipt = receipt;
            _Contract = contract;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _nationality = nationality;
            _customer = customer;
            _city = city;
            _country = country;
            _jobtype = jobtype;
            _select = select;
            _delegate = deleg;
            _visa = visa;
            _ticket = ticket;
            _history = history;
            _user = user;
            _emp = emp;
            _agency = agency;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page, string SearchString)
        {
            var contractList = _Contract.GetSpecificContracts();

            if (SearchString != null)
            {
                contractList = _Contract.GetSpecificContracts().Where(x => x.Customer.Name.Contains(SearchString));
            }
            else
            {
                contractList = _Contract.GetSpecificContracts();
            }
            
            if (contractList.Count() <= 10) { page = 1; }
            int pageSize = 10;
            var specificContract = await PaginatedList<SpecificContract>.CreateAsync(contractList.AsNoTracking(), page ?? 1, pageSize);
            ViewBag.Contracts = specificContract;
            return View(specificContract);
        }
        #endregion

        #region Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contract = _Contract.GetSpecificContractById((int)id);
            //var contractViewModels = _mapper.Map<SpecificContractViewModel>(contract);
            if (contract == null)
            {
                return NotFound();
            }
            ViewBag.ReceiptDocs = _receipt.GetReceiptDocs().Where(x => x.ContractId == contract.Id 
            && x.ContractTypeId == contract.ContractTypeId && x.CustomerId == contract.CustomerId
            && x.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadReceive);
            ViewBag.TakingDocs = _receipt.GetReceiptDocs().Where(x => x.ContractId == contract.Id
            && x.ContractTypeId == contract.ContractTypeId && x.CustomerId == contract.CustomerId
            && x.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadTaking);
            return View(contract);
        }
        #endregion

        #region Add

        [HttpGet]
        public IActionResult Add(int contractType)
        {
            SpecificContractViewModel contractViewModel = new SpecificContractViewModel();
            //ViewBag.ContractTypeId = new SelectList(_contract_Type.GetContractTypes().Where(x => x.Id <= 2), "Id", "Name");
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "FirstName");
            ViewBag.ArrivalCityId = new SelectList(_city.GetCities(), "Id", "Name");
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name");
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName");
            return View(contractViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(SpecificContractViewModel SpecContractViewModel)
        {
            SpecContractViewModel.ContractTypeId = (int)EnumHelper.ContractType.Specific;
            SpecContractViewModel.CreatedByName = User.Identity.Name;
            var CreatedBy = _user.GetUserByName(SpecContractViewModel.CreatedByName);
            SpecContractViewModel.CreatedById = CreatedBy.Id;
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName");
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "Name", SpecContractViewModel.CustomerId);
            //ViewBag.CityId = new SelectList(_city.GetCities(), "Id", "Name", SpecContractViewModel.CityId);
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name", SpecContractViewModel.JobTypeId);
            if (SpecContractViewModel.CustomerId == null) { ModelState.AddModelError("", "الرجاء تحدد العميل"); }
            //if (SpecContractViewModel.CityId == null) { ModelState.AddModelError("", "الرجاء تحديد مدينة الوصول"); }
            if (SpecContractViewModel.JobTypeId == null) { ModelState.AddModelError("", "الرجاء تحديد الوظيفة "); }
            if (SpecContractViewModel.Id == 0)
            {
                SpecContractViewModel.ContractStatusId = (int)EnumHelper.ContractStatus.New;
                ModelState.Remove("Id");
                ModelState.Remove("ContractTypeId");
                ModelState.Remove("CustomerId");
                ModelState.Remove("CityId");
                ModelState.Remove("JobTypeId");
                ModelState.Remove("ForeignAgencyId");
                if (ModelState.IsValid)
                {

                    var contract = _mapper.Map<SpecificContract>(SpecContractViewModel);
                    _Contract.AddSpecificContract(contract);
                    _toastNotification.AddSuccessToastMessage("تم أضافةالعقد بنجاح");
                    return RedirectToAction(nameof(Index));
                }

                return View(SpecContractViewModel);
            }
            else
            {
                SpecContractViewModel.ContractStatusId = (int)EnumHelper.ContractStatus.New;
                ModelState.Remove("ContractTypeId");
                ModelState.Remove("CustomerId");
                ModelState.Remove("CityId");
                if (ModelState.IsValid)
                {
                    var contract = _mapper.Map<SpecificContract>(SpecContractViewModel);
                    _Contract.UpdateSpecificContract(SpecContractViewModel.Id, contract);
                    _toastNotification.AddSuccessToastMessage("تم تعديل العقد بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View("Add", SpecContractViewModel);
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

            var spec_contract = _Contract.GetSpecificContractById((int)id);
            var sepc_contractViewModel = _mapper.Map<SpecificContractViewModel>(spec_contract);
            if (spec_contract == null)
            {
                return NotFound();
            }
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName");
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "Name", sepc_contractViewModel.CustomerId);
            //ViewBag.CityId = new SelectList(_city.GetCities(), "Id", "Name", sepc_contractViewModel.CityId);
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name", sepc_contractViewModel.JobTypeId);
            return View("Add", sepc_contractViewModel);
        }
        #endregion

        #region Close 
        [HttpGet]
        public IActionResult Close(int Id)
        {
            SpecificContractViewModel contractViewModel = new SpecificContractViewModel();
            //ViewBag.ContractTypeId = new SelectList(_contract_Type.GetContractTypes().Where(x => x.Id <= 2), "Id", "Name");
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "FirstName");
            ViewBag.CountryId = new SelectList(_country.GetCountries(), "Id", "Name");
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name");
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName");
            contractViewModel.Id = Id;
            return View(contractViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Close(SpecificContractViewModel SpecContractViewModel)
        {
            SpecContractViewModel.CreatedByName = User.Identity.Name;
            var CreatedBy = _user.GetUserByName(SpecContractViewModel.CreatedByName);
            SpecContractViewModel.CreatedById = CreatedBy.Id;
            ViewBag.ForeignAgencyId = new SelectList(_agency.GetAgencies(), "Id", "OfficeName");
            ViewBag.CountryId = new SelectList(_country.GetCountries(), "Id", "Name");
            if (SpecContractViewModel.DelegationDate == null) { ModelState.AddModelError("", "الرجاء تحديد تاريخ التفويض"); }
            if (SpecContractViewModel.CountryId == null) { ModelState.AddModelError("", "الرجاء تحديد البلد"); }
            if (SpecContractViewModel.ContractCost <= 0) { ModelState.AddModelError("", "الرجاء تحديد قيمة العقد"); }
            SpecContractViewModel.ContractStatusId = (int)EnumHelper.ContractStatus.Close;
            ModelState.Remove("CountryId");
            ModelState.Remove("ForeignAgencyId");
            ModelState.Remove("CustomerId");
            ModelState.Remove("JobTypeId");
            if (ModelState.IsValid)
            {
                var contract = _mapper.Map<SpecificContract>(SpecContractViewModel);
                _Contract.CloseSpecificContract(SpecContractViewModel.Id, contract);
                _toastNotification.AddSuccessToastMessage("تم أغلاق العقد بنجاح");
                return RedirectToAction(nameof(Index));
            }
            return View(SpecContractViewModel);
        }
        #endregion

        //#region Delete

        //public IActionResult Delete(int id)
        //{
        //    _Contract.RemoveContract(id);
        //    _toastNotification.AddSuccessToastMessage("تم حذف العقد  بنجاح");
        //    return RedirectToAction(nameof(Index));
        //}

        //#endregion
    }
}