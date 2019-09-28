using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Entities;
using NajmetAlraqee.Data.Repositories;
using NajmetAlraqee.Site.Helper;
using NajmetAlraqee.Site.Services;
using NajmetAlraqee.Site.ViewModels;
using NToastNotify;

namespace NajmetAlraqee.Site.Controllers
{
    [Authorize]
    public class ContractController : Controller
    {
        #region Filed 
        private readonly ICustomerRepository _customer;
        private readonly IContractRepository _Contract;
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



        #endregion
        public ContractController(ICityRepository city,
            IEmployeeRepository emp, 
            IReceiptDocRepository receipt,
            IContractSelectRepository select,
            IUserRepository user, 
            IContractHistoryRepository history,
            IContractTicketRepository ticket,
            IContractVisaRepository visa,
            IContractDelegateRepository deleg,
            IJobTypeReository jobtype, 
            ICustomerRepository customer, INationalityRepository nationality,
            IContractRepository contract, IContractTypeRepository contract_Type, IMapper mapper,
            IToastNotification toastNotification)
        {
            _receipt = receipt;
            _Contract = contract;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _nationality = nationality;
            _contract_Type = contract_Type;
            _customer = customer;
            _city = city;
            _jobtype = jobtype;
            _select = select;
            _delegate = deleg;
            _visa = visa;
            _ticket = ticket;
            _history = history;
            _user = user;
            _emp = emp;
        }

        #region Index 
        public async Task<IActionResult> Index(int? page, string SearchString)
        {
            var contractList = _Contract.GetContracts();

            if (SearchString != null)
            {
                contractList = _Contract.GetContracts().Where(x => x.Customer.Name.Contains(SearchString));
            }
            else
            {
                contractList = _Contract.GetContracts();
            }
           
            if (contractList.Count() <= 10) { page = 1; }
            int pageSize = 10;
            var contractPaging = await PaginatedList<Contract>.CreateAsync(contractList.AsNoTracking(), page ?? 1, pageSize);
            ViewBag.Contracts = contractPaging;
            return View(contractPaging);
        }
        #endregion

        #region Details
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contract = _Contract.GetContractById((int)id);
            var contractViewModels = _mapper.Map<ContractViewModel>(contract);
            if (contractViewModels == null)
            {
                return NotFound();
            }
            ViewBag.ContractSelect = _select.GetContractSelects().Where(x => x.ContractId == id);
            ViewBag.ContractDelegation = _delegate.GetContractDelegations().Where(x => x.ContractId == id);
            ViewBag.ContractVisa = _visa.GetContractVisas().Where(x => x.ContractId == id);
            ViewBag.ContractTickets = _ticket.GetContractTickets().Where(x => x.ContractId == id);
            ViewBag.ContractHistory = _history.GetContractHistorys().Where(x => x.ContractId == id);
            ViewBag.ReceiptDocs = _receipt.GetReceiptDocs().Where(x => x.ContractId == id && x.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadReceive && x.ContractTypeId == contract.ContractTypeId);
            ViewBag.TakingDocs = _receipt.GetReceiptDocs().Where(x => x.ContractId == id && x.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadTaking);
            if (contract != null)
            {
                //var CheckTestDay = _Contract.UpdateTestDay(contract.Id);
            }
            var nationalityNmae = _nationality.GetNationalities().SingleOrDefault(x => x.Id == contractViewModels.NationalityId);
            contractViewModels.NationalityName = nationalityNmae.Name;
            return View(contractViewModels);
        }
        #endregion

        #region Add

        [HttpGet]
        public IActionResult Add(int contractType, int? contractId)
        {
            ContractViewModel contractViewModel = new ContractViewModel();


            if (contractType == (int)EnumHelper.ContractType.New)
            {
                ViewBag.ContractTypeId = new SelectList(_contract_Type.GetContractTypes().Where(x => x.Id == (int)EnumHelper.ContractType.New), "Id", "Name");
            }
            if (contractType == (int)EnumHelper.ContractType.Substitute)
            {
                contractViewModel.OldContractNo = contractId;
                contractViewModel.ContractTypeId = contractType;
                ViewBag.ContractTypeId = new SelectList(_contract_Type.GetContractTypes().Where(x => x.Id == (int)EnumHelper.ContractType.Substitute), "Id", "Name");
            }
            //ViewBag.ContractTypeId = new SelectList(_contract_Type.GetContractTypes().Where(x => x.Id <= 2), "Id", "Name");
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "Name");
            ViewBag.ArrivalCityId = new SelectList(_city.GetCities(), "Id", "Name");
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name");
            ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name");
            return View(contractViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ContractViewModel contractViewModel)
        {
            contractViewModel.CreatedByName = User.Identity.Name;
            var CreatedBy = _user.GetUserByName(contractViewModel.CreatedByName);
            contractViewModel.CreatedById = CreatedBy.Id;
            if (contractViewModel.ContractTypeId == (int)EnumHelper.ContractType.New)
            {
                ViewBag.ContractTypeId = new SelectList(_contract_Type.GetContractTypes().Where(x => x.Id == (int)EnumHelper.ContractType.New), "Id", "Name", contractViewModel.ContractTypeId);
            }
            if (contractViewModel.ContractTypeId == (int)EnumHelper.ContractType.Substitute)
            {
                ViewBag.ContractTypeId = new SelectList(_contract_Type.GetContractTypes().Where(x => x.Id == (int)EnumHelper.ContractType.Substitute), "Id", "Name", contractViewModel.ContractTypeId);
            }
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "Name", contractViewModel.CustomerId);
            ViewBag.ArrivalCityId = new SelectList(_city.GetCities(), "Id", "Name", contractViewModel.ArrivalCityId);
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name", contractViewModel.JobTypeId);
            ViewBag.NationalityId = new SelectList(_nationality.GetNationalities(), "Id", "Name", contractViewModel.NationalityId);
            if (contractViewModel.ContractTypeId == null) { ModelState.AddModelError("", "الرجاء تحديد نوع العقد"); }
            if (contractViewModel.CustomerId == null) { ModelState.AddModelError("", "الرجاء تحدد العميل"); }
            if (contractViewModel.ArrivalCityId == null) { ModelState.AddModelError("", "الرجاء تحديد مدينة الوصول"); }
            if (contractViewModel.JobTypeId == null) { ModelState.AddModelError("", "الرجاء تحديد الوظيفة "); }
            if (contractViewModel.NationalityId == null) { ModelState.AddModelError("", "الرجاء تحديد جنسبة العامل "); }
            if (contractViewModel.Id == 0)
            {
                contractViewModel.ContractStatusId = (int)EnumHelper.ContractStatus.New;
                ModelState.Remove("Id");
                ModelState.Remove("ContractTypeId");
                ModelState.Remove("CustomerId");
                ModelState.Remove("ArrivalCityId");
                ModelState.Remove("JobTypeId");
                ModelState.Remove("NationalityId");
                if (ModelState.IsValid)
                {

                    var contract = _mapper.Map<Contract>(contractViewModel);
                    _Contract.AddContract(contract);
                    _toastNotification.AddSuccessToastMessage("تم أضافةالعقد بنجاح");
                    return RedirectToAction(nameof(Index));
                }

                return View(contractViewModel);
            }
            else
            {
                ModelState.Remove("ContractTypeId");
                ModelState.Remove("CustomerId");
                ModelState.Remove("ArrivalCityId");
                ModelState.Remove("NationalityId");
                if (ModelState.IsValid)
                {
                    var contract = _mapper.Map<Contract>(contractViewModel);
                    _Contract.UpdateContract(contractViewModel.Id, contract);
                    _toastNotification.AddSuccessToastMessage("تم تعديل العقد بنجاح");
                    return RedirectToAction(nameof(Index));
                }
                return View("Add", contractViewModel);
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

            var contract = _Contract.GetContractById((int)id);
            var contractViewModel = _mapper.Map<ContractViewModel>(contract);
            if (contract == null)
            {
                return NotFound();
            }
            if (contractViewModel.ContractTypeId <= 1)
            {
                ViewBag.ContractTypeId = new SelectList(_contract_Type.GetContractTypes().Where(x => x.Id == (int)EnumHelper.ContractType.New), "Id", "Name", contractViewModel.ContractTypeId);
            }
            else
            {
                ViewBag.ContractTypeId = new SelectList(_contract_Type.GetContractTypes().Where(x => x.Id == (int)EnumHelper.ContractType.Substitute), "Id", "Name", contractViewModel.ContractTypeId);
            }
            ViewBag.CustomerId = new SelectList(_customer.GetCustomers(), "Id", "Name", contractViewModel.CustomerId);
            ViewBag.ArrivalCityId = new SelectList(_city.GetCities(), "Id", "Name", contractViewModel.ArrivalCityId);
            ViewBag.JobTypeId = new SelectList(_jobtype.GetJobTypes(), "Id", "Name", contractViewModel.JobTypeId);
            return View("Add", contractViewModel);
        }
        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            _Contract.RemoveContract(id);
            _toastNotification.AddSuccessToastMessage("تم حذف العقد  بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion


        #region CloseContract 
        public IActionResult CloseContract(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contract = _Contract.GetContractById((int)id);
            if (contract != null)
            {
                contract.ContractStatusId = (int)EnumHelper.ContractStatus.Close;
                _Contract.CloseContract(contract.Id, contract);
            }

            return RedirectToAction("Details", new { id = contract.Id });
        }
        #endregion 

    }
}