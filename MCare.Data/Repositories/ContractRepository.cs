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

            _context.Contracts.Add(contract);
            _context.SaveChanges();

            // Adding To Contract History 
            ContractHistory history = new ContractHistory();
            history.ContractId = contract.Id;
            history.CustomerId = contract.CustomerId;
            history.ForeignAgencyId = contract.ForeignAgencyId;
            history.EmployeeId = contract.EmployeeId;
            history.ActionId = (int)EnumHelper.ContractAction.New;
            history.ContractStatusId = contract.ContractStatusId;
            history.ActionById = contract.CreatedById;
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
            existcontract.ContractCost = contract.ContractCost;
            existcontract.ContractDate = contract.ContractDate;
            existcontract.ContractInterVal = contract.ContractInterVal;
            existcontract.ContractNote = contract.ContractNote;
            //existcontract.ContractStatusId = contract.ContractStatusId;
            //existcontract.ContractTypeId = contract.ContractTypeId;
            existcontract.ContractYear = contract.ContractYear;
            existcontract.CustomerId = contract.CustomerId;
            existcontract.EmployeeCost = contract.EmployeeCost;
            //existcontract.EmployeeId = contract.EmployeeId;
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
            existcontract.EmployeeId = contract.EmployeeId;
            _context.Update(existcontract);
            _context.SaveChanges();



            // Adding To Contract History 
            ContractHistory history = new ContractHistory();
            history.ContractId = existcontract.Id;
            history.CustomerId = existcontract.CustomerId;
            history.ForeignAgencyId = existcontract.ForeignAgencyId;
            history.EmployeeId = contract.EmployeeId;
            history.ActionId = (int)EnumHelper.ContractAction.Close;
            history.ContractStatusId = contract.ContractStatusId;
            history.ActionById = contract.CreatedById;
            history.ActionByName = _context.Users.Where(x => x.Id.Contains(history.ActionById)).SingleOrDefault().UserName;
            var emp = _context.Employees.SingleOrDefault(x => x.Id == history.EmployeeId);
            if (emp != null) { history.EmployeeName = emp.FirstName + ' ' + emp.Father; }
            var cust = _context.Customers.SingleOrDefault(x => x.Id == history.CustomerId);
            if (cust != null) { history.CustomerName = cust.Name; }
            //var foreignAgencies = _context.ForeignAgencies.SingleOrDefault(x => x.Id == history.ForeignAgencyId);
            //if (foreignAgencies != null) { history.ForeignAgencyName = foreignAgencies.OfficeName; }
            //var Action = _context.ContractAction.SingleOrDefault(x => x.Id == history.ActionId);
            //if (Action != null) { history.ActionName = Action.Name; }
          

            history.ActionDate = DateTime.UtcNow.ToString("dd/MM/yyyy",
                                       CultureInfo.InvariantCulture);

            _context.ContractHistories.Add(history);
            _context.SaveChanges();


            return true;
        }
    }
}
