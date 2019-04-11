using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class ContractTicketRepository : IContractTicketRepository
    {
        private NajmetAlraqeeContext _context;

        public ContractTicketRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int AddContractTicket(ContractTicket contractTicket)
        {

            var cont = _context.Contracts.Find(contractTicket.ContractId);
            contractTicket.EmployeeId = cont.EmployeeId;
            _context.ContractTickets.Add(contractTicket);
            _context.SaveChanges();

            // Contract Info 
           
            if (cont != null)
            {
                cont.ContractStatusId = (int)EnumHelper.ContractStatus.Ticket;
                _context.Update(cont);
                _context.SaveChanges();
            }



            // Adding To Contract History 
            ContractHistory history = new ContractHistory();
            history.ContractId = contractTicket.ContractId;
            history.CustomerId = cont.CustomerId;
            history.ForeignAgencyId = cont.ForeignAgencyId;
            history.EmployeeId = cont.EmployeeId;
            history.ActionId = (int)EnumHelper.ContractAction.Ticket;
            history.ContractStatusId = cont.ContractStatusId;
            var ticket = contractTicket.TicketById;
            history.ActionById = contractTicket.TicketById;
            history.ActionByName = _context.Users.Where(x => x.Id.Contains(history.ActionById)).SingleOrDefault().UserName;
            var foreignAgencies = _context.ForeignAgencies.SingleOrDefault(x => x.Id == history.ForeignAgencyId);
            if (foreignAgencies != null) { history.ForeignAgencyName = foreignAgencies.OfficeName; }
            var cust = _context.Customers.SingleOrDefault(x => x.Id == history.CustomerId);
            if (cust != null) { history.CustomerName = cust.Name; }
            var emp = _context.Employees.SingleOrDefault(x => x.Id == history.EmployeeId);
            if (emp != null) { history.EmployeeName = emp.FirstName + ' ' + emp.Father; }
            history.ActionDate = DateTime.UtcNow.ToString("dd/MM/yyyy",
                                       CultureInfo.InvariantCulture);
            _context.ContractHistories.Add(history);
            _context.SaveChanges();

            return contractTicket.Id;
        }

        public ContractTicket GetContractTicketById(int Id)
        {
            return _context.ContractTickets
               .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<ContractTicket> GetContractTickets()
        {
            return _context.ContractTickets.Include(x => x.Employee).Include(x => x.City);
        }

        public bool RemoveContractTicket(int Id)
        {
            ContractTicket contractTicket = GetContractTicketById(Id);
            if (contractTicket == null)
                return false;

            _context.Remove(contractTicket);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateContractTicket(int Id, ContractTicket contractTicket)
        {
            var cont = _context.Contracts.Find(contractTicket.ContractId);
            ContractTicket existcontractTicket = GetContractTicketById(Id);
            if (existcontractTicket == null)
                return false;
            existcontractTicket.ContractId = contractTicket.ContractId;
            existcontractTicket.EmployeeId = cont.EmployeeId;
            existcontractTicket.TicketById = contractTicket.TicketById;
            existcontractTicket.TicketDate = contractTicket.TicketDate;
            existcontractTicket.Time = contractTicket.Time;
            existcontractTicket.CityId = contractTicket.CityId;
            _context.Update(existcontractTicket);
            _context.SaveChanges();


            // Contract Info 
          
            if (cont != null)
            {
                cont.ContractStatusId = (int)EnumHelper.ContractStatus.Ticket;
                _context.Update(cont);
                _context.SaveChanges();
            }



            // Adding To Contract History 
            ContractHistory history = new ContractHistory();
            history.ContractId = contractTicket.ContractId;
            history.CustomerId = cont.CustomerId;
            history.ForeignAgencyId = cont.ForeignAgencyId;
            history.EmployeeId = cont.EmployeeId;
            history.ActionId = (int)EnumHelper.ContractAction.Ticket;
            history.ContractStatusId = cont.ContractStatusId;

            history.ActionById = contractTicket.TicketById;
            history.ActionByName = _context.Users.Where(x => x.Id.Contains(history.ActionById)).SingleOrDefault().UserName;
            
            var foreignAgencies = _context.ForeignAgencies.SingleOrDefault(x => x.Id == history.ForeignAgencyId);
            if (foreignAgencies != null) { history.ForeignAgencyName = foreignAgencies.OfficeName; }
            var cust = _context.Customers.SingleOrDefault(x => x.Id == history.CustomerId);
            if (cust != null) { history.CustomerName = cust.Name; }
            var emp = _context.Employees.SingleOrDefault(x => x.Id == history.EmployeeId);
            if (emp != null) { history.EmployeeName = emp.FirstName + ' ' + emp.Father; }
            history.ActionDate = DateTime.UtcNow.ToString("dd/MM/yyyy",
                                       CultureInfo.InvariantCulture);
            history.ActionDate = DateTime.Now.ToShortDateString();

            _context.ContractHistories.Add(history);
            _context.SaveChanges();

            return true;
        }

        public bool ApprovedTicket(int Id, ContractTicket ticket)
        {
            ContractTicket existticket = GetContractTicketById(Id);
            if (existticket == null)
                return false;
            existticket.IsApproved = ticket.IsApproved;
            _context.Update(existticket);
            _context.SaveChanges();
            return true;
        }
    }
}
