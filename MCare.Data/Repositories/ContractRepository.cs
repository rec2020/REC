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
    public class ContractRepository : IContractRepository
    {

        private NajmetAlraqeeContext _context;

        public ContractRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int AddContract(Contract contract)
        {
            contract.Remainder = contract.ContractCost;
            contract.Paid = 0;
            contract.TestDay = 0;
            contract.OldContractNo = 0;
            _context.Contracts.Add(contract);
            _context.SaveChanges();

            // Adding To Contract History 
            ContractHistory history = new ContractHistory
            {
                ContractId = contract.Id,
                CustomerId = contract.CustomerId,
                ForeignAgencyId = contract.ForeignAgencyId,
                EmployeeId = contract.EmployeeId,
                ActionId = (int)EnumHelper.ContractAction.New,
                ContractStatusId = contract.ContractStatusId,
                ActionById = contract.CreatedById
            };
            history.ActionByName = _context.Users.Where(x => x.Id.Contains(history.ActionById)).SingleOrDefault().UserName;
            //var emp = _context.Employees.SingleOrDefault(x => x.Id == history.EmployeeId);
            //if (emp != null) { history.EmployeeName = emp.FirstName + ' ' + employee.Father; }
            var cust = _context.Customers.SingleOrDefault(x => x.Id == history.CustomerId);
            if (cust != null) { history.CustomerName = cust.Name; }
            //var foreignAgencies = _context.ForeignAgencies.SingleOrDefault(x => x.Id == history.ForeignAgencyId);
            //if (foreignAgencies != null) { history.ForeignAgencyName = foreignAgencies.OfficeName; }
            //var Action = _context.ContractAction.SingleOrDefault(x => x.Id == history.ActionId);
            //if (Action != null) { history.ActionName = Action.Name; }
            //var contract_s = _context.ContractStatuses.SingleOrDefault(x => x.Id == history.ContractStatusId);
            //if (contractStatus != null) { history.ContractStatusName = contract_s.Name; }

            history.ActionDate = DateTime.UtcNow.ToString("dd/MM/yyyy",
                                       CultureInfo.InvariantCulture);

            _context.ContractHistories.Add(history);
            _context.SaveChanges();

            return contract.Id;
        }

        public Contract GetContractById(int Id)
        {
            return _context.Contracts.Include(x => x.ArrivalCity)
                .Include(x => x.ContractStatus).Include(x => x.ContractType)
                .Include(x => x.Customer).Include(x => x.Employees)
                .Include(x => x.ForeignAgency).Include(x => x.JobType)
               .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<Contract> GetContracts()
        {
            return _context.Contracts.Include(x => x.ArrivalCity)
                .Include(x => x.ContractStatus).Include(x => x.ContractType)
                .Include(x => x.Customer).Include(x => x.Employees)
                .Include(x => x.ForeignAgency).Include(x => x.JobType);
        }

        public bool RemoveContract(int Id)
        {
            Contract contract = GetContractById(Id);
            if (contract == null)
                return false;

            _context.Remove(contract);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateContract(int Id, Contract contract)
        {

            Contract existcontract = GetContractById(Id);
            if (existcontract == null)
                return false;
            existcontract.ArrivalCityId = contract.ArrivalCityId;
            existcontract.NationalityId = contract.NationalityId;
            existcontract.ContractCost = contract.ContractCost;
            existcontract.ContractDate = contract.ContractDate;
            existcontract.ContractInterVal = contract.ContractInterVal;
            existcontract.ContractNote = contract.ContractNote;
            existcontract.VatCost = contract.VatCost;
            existcontract.VisaNumber = contract.VisaNumber;
            existcontract.ContractYear = contract.ContractYear;
            existcontract.CustomerId = contract.CustomerId;
            existcontract.EmployeeCost = contract.EmployeeCost;
            existcontract.VisaDate = contract.VisaDate;
            existcontract.EmployeeNumber = contract.EmployeeNumber;
            existcontract.ExperienceYear = contract.ExperienceYear;
            existcontract.QulaficationNote = contract.QulaficationNote;
            existcontract.SalaryMonth = contract.SalaryMonth;
            existcontract.TestDay = contract.TestDay;
            existcontract.VatCost = contract.VatCost;
            existcontract.VicationDays = contract.VicationDays;

            _context.Update(existcontract);
            _context.SaveChanges();

            return true;
        }

        public bool CloseContract(int Id, Contract contract)
        {
            Contract existcontract = GetContractById(Id);
            if (existcontract == null)
                return false;
            existcontract.ContractStatusId = contract.ContractStatusId;
            _context.Update(existcontract);
            _context.SaveChanges();



            // Adding To Contract History 
            ContractHistory history = new ContractHistory
            {
                ContractId = existcontract.Id,
                CustomerId = existcontract.CustomerId,
                ForeignAgencyId = existcontract.ForeignAgencyId,
                EmployeeId = contract.EmployeeId,
                ActionId = (int)EnumHelper.ContractAction.Close,
                ContractStatusId = contract.ContractStatusId,
                ActionById = contract.CreatedById
            };
            history.ActionByName = _context.Users.Where(x => x.Id.Contains(history.ActionById)).SingleOrDefault().UserName;
            var emp = _context.Employees.SingleOrDefault(x => x.Id == history.EmployeeId);
            if (emp != null) { history.EmployeeName = emp.FirstName + ' ' + emp.Father; }
            var cust = _context.Customers.SingleOrDefault(x => x.Id == history.CustomerId);
            if (cust != null) { history.CustomerName = cust.Name; }
            var foreignAgencies = _context.ForeignAgencies.SingleOrDefault(x => x.Id == history.ForeignAgencyId);
            if (foreignAgencies != null) { history.ForeignAgencyName = foreignAgencies.OfficeName; }
            //var Action = _context.ContractAction.SingleOrDefault(x => x.Id == history.ActionId);
            //if (Action != null) { history.ActionName = Action.Name; }


            history.ActionDate = DateTime.UtcNow.ToString("dd/MM/yyyy",
                                       CultureInfo.InvariantCulture);

            _context.ContractHistories.Add(history);
            _context.SaveChanges();


            return true;
        }

        public bool UpdateTestDay(int id)
        {
            string format = "MM/dd/yyyy";
            var contractTicket = _context.ContractTickets.Where(x => x.ContractId == id && x.IsApproved == true).SingleOrDefault();
            var arrivalDatestring= String.Format("{0:MM/dd/yyyy}", contractTicket.ArrivalDate);
            var arrivalDate = DateTime.ParseExact(arrivalDatestring, format, CultureInfo.InvariantCulture);
            var currentDateString = DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            var currentDate = DateTime.ParseExact(currentDateString, format, CultureInfo.InvariantCulture);
            var reminder = (currentDate - arrivalDate).TotalDays;
            Contract existcontract = GetContractById(id);
            if (existcontract == null)
                return false;
            if (reminder >0) {
                existcontract.TestDay = (int)(existcontract.TestDay - reminder);
            }
            _context.Update(existcontract);
            _context.SaveChanges();
            return true;
        }
    }
}
