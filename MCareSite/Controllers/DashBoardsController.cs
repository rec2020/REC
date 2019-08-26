using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NajmetAlraqee.Data;
using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;
//using NajmetAlraqeeSite.Data;
using NajmetAlraqeeSite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace NajmetAlraqeeSite.Controllers
{
    [Authorize]
    public class DashBoardsController : Controller
    {

        private NajmetAlraqeeContext _context;
        
        public DashBoardsController(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            AdminDashBoardViewModels dash = new AdminDashBoardViewModels();
            dash.TotalContracts = _context.Contracts.Count();
            dash.TotalSelect = _context.Contracts.Where(x=>x.ContractStatusId==(int)EnumHelper.ContractStatus.Select).Count();
            dash.TotalSelect = _context.Contracts.Where(x => x.ContractStatusId == (int)EnumHelper.ContractStatus.Select).Count(); ;
            dash.TotalDelegation = _context.Contracts.Where(x => x.ContractStatusId == (int)EnumHelper.ContractStatus.Delegate).Count(); 
            dash.TotalVisa = _context.Contracts.Where(x => x.ContractStatusId == (int)EnumHelper.ContractStatus.Visa).Count();
            dash.TotalTicket = _context.Contracts.Where(x => x.ContractStatusId == (int)EnumHelper.ContractStatus.Ticket).Count();
            dash.TotalClose = _context.Contracts.Where(x => x.ContractStatusId == (int)EnumHelper.ContractStatus.Close).Count();
            dash.TotalCustomers = _context.Customers.Count();
            dash.TotalPartener = _context.Partners.Count(); 
            dash.TotalForigenAgency = _context.ForeignAgencies.Count(); ;
            dash.TotalEmployee = _context.Employees.Count(); ;
            return View(dash);
        }

    }
}