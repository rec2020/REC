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
    public class ContractTicketController : Controller
    {
        private readonly IContractRepository _contrat;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IContractTicketRepository _ticket;
        private readonly IEmployeeRepository _employee;
        private readonly ICityRepository _city;
        private readonly IUserRepository _user;

        public ContractTicketController(IContractRepository contract, ICityRepository city, IUserRepository user, IEmployeeRepository employee, IContractTicketRepository ticket, IMapper mapper, IToastNotification toastNotification)
        {
            _user = user;
            _contrat = contract;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _ticket = ticket;
            _employee = employee;
            _city = city;
        }

        #region Index 
        public IActionResult Index(int contractId)
        {
            ContractTicketViewModel ticket = new ContractTicketViewModel();
            ticket.ContractId = contractId;
            var contractTicketList = _ticket.GetContractTickets().Where(x => x.ContractId == contractId);
            ViewBag.ContractTickets = contractTicketList;
            ViewBag.CityId = new SelectList(_city.GetCities(), "Id", "Name");
            //ViewBag.EmpoyeeId = new SelectList(_employee.GetEmployees(), "Id", "FirstName");
            return View(ticket);
        }
        #endregion

        #region Add

        [HttpGet]
        public IActionResult Add()
        {
            var contractTicketList = _ticket.GetContractTickets();
            ViewBag.ContractTickets = contractTicketList;
            ViewBag.CityId = new SelectList(_city.GetCities(), "Id", "Name");
            //ViewBag.EmpoyeeId = new SelectList(_employee.GetEmployees(), "Id", "FirstName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ContractTicketViewModel ticketViewModel)
        {
            ticketViewModel.TicketByName = User.Identity.Name;
            var ticketById = _user.GetUserByName(ticketViewModel.TicketByName);
            ticketViewModel.TicketById = ticketById.Id;
            var contractTicketList = _ticket.GetContractTickets().Where(x => x.ContractId == ticketViewModel.ContractId);
            ViewBag.ContractTickets = contractTicketList;
            ViewBag.CityId = new SelectList(_city.GetCities(), "Id", "Name", ticketViewModel.CityId);
            if (ticketViewModel.CityId == null) { ModelState.AddModelError("", "الرجاء تحديد مدينة الوصول"); }
            if (ticketViewModel.Id == 0)
            {
                ticketViewModel.IsApproved = false;
                ModelState.Remove("Id");
                ModelState.Remove("CityId");
                if (ModelState.IsValid)
                {
                    var ticketContract = _mapper.Map<ContractTicket>(ticketViewModel);
                    _ticket.AddContractTicket(ticketContract);
                    _toastNotification.AddSuccessToastMessage("تم ادخال التذكرة بنجاح");
                    return RedirectToAction(nameof(Index), new { contractId = ticketViewModel.ContractId });
                }
                return View(nameof(Index), ticketViewModel);
            }
            else
            {
                ModelState.Remove("CityId");
                ModelState.Remove("EmployeeId");
                if (ModelState.IsValid)
                {
                    var ticketContract = _mapper.Map<ContractTicket>(ticketViewModel);
                    _ticket.UpdateContractTicket(ticketViewModel.Id, ticketContract);
                    _toastNotification.AddSuccessToastMessage("تم تعديل التذكرة بنجاح");
                    return RedirectToAction(nameof(Index), new { contractId = ticketViewModel.ContractId });
                }
                return View(nameof(Index), ticketViewModel);
            }

        }
        #endregion

        #region Edit
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contractTicket = _ticket.GetContractTicketById((int)id);
            var contractTicketViewModel = _mapper.Map<ContractTicketViewModel>(contractTicket);
            if (contractTicket == null)
            {
                return NotFound();
            }
            var contractTicketList = _ticket.GetContractTickets().Where(x => x.ContractId == contractTicket.ContractId); ;
            ViewBag.ContractTickets = contractTicketList;
            ViewBag.CityId = new SelectList(_city.GetCities(), "Id", "Name", contractTicketViewModel.CityId);
            ViewBag.EmpoyeeId = new SelectList(_employee.GetEmployees(), "Id", "FirstName", contractTicketViewModel.EmployeeId);
            return View("Index", contractTicketViewModel);
        }


        #endregion

        #region Delete

        public IActionResult Delete(int? id)
        {
            _ticket.RemoveContractTicket((int)id);
            _toastNotification.AddSuccessToastMessage("تم الحذف بنجاح");
            return RedirectToAction(nameof(Index));
        }

        #endregion
        public IActionResult ApprovedTicket(int id)
        {
            var item = _ticket.GetContractTicketById(id);
            item.IsApproved = true;
            _ticket.ApprovedTicket(id, item);
            _toastNotification.AddSuccessToastMessage("تم الاعتماد بنجاح");
            return RedirectToAction(nameof(Index), new { contractId = item.ContractId });
        }
    }
}