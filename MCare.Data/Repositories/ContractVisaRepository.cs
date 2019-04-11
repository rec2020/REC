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
    public class ContractVisaRepository :IContractVisaRepository
    {
        private NajmetAlraqeeContext _context;

        public ContractVisaRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int AddContractVisa(ContractVisa contractVisa)
        {
            _context.ContractVisas.Add(contractVisa);
            _context.SaveChanges();

            // Contract Info 
            var cont = _context.Contracts.Find(contractVisa.ContractId);
            if (cont != null)
            {
                cont.ContractStatusId = (int)EnumHelper.ContractStatus.Visa;
                //cont.ContractStatusName = _context.ContractStatuses.Find(cont.ContractStatusId).Name;
                if (contractVisa.EmployeeId != null)
                {
                    cont.EmployeeId = contractVisa.EmployeeId;
                    //cont.EmployeeName = contractVisa.EmployeeName;
                }
                _context.Update(cont);
                _context.SaveChanges();
            }



            // Adding To Contract History 
            ContractHistory history = new ContractHistory();
            history.ContractId = contractVisa.ContractId;
            history.CustomerId = cont.CustomerId;
            history.ForeignAgencyId = cont.ForeignAgencyId;
            history.EmployeeId = cont.EmployeeId;
            history.ActionId = (int)EnumHelper.ContractAction.Visa;
            history.ContractStatusId = cont.ContractStatusId;
            history.ActionById = contractVisa.VisaById;
            history.ActionByName = _context.Users.Where(x => x.Id.Contains(history.ActionById)).SingleOrDefault().UserName;
            var foreignAgencies = _context.ForeignAgencies.SingleOrDefault(x => x.Id == history.ForeignAgencyId);
            if (foreignAgencies != null) { history.ForeignAgencyName = foreignAgencies.OfficeName; }
            var cust = _context.Customers.SingleOrDefault(x => x.Id == history.CustomerId);
            if (cust != null) { history.CustomerName = cust.Name; }
            var emp = _context.Employees.SingleOrDefault(x => x.Id == history.EmployeeId);
            if (emp != null) { history.EmployeeName = emp.FirstName + ' ' + emp.Father; }
            history.ActionDate = DateTime.UtcNow.ToString("dd/MM/yyyy",
                                       CultureInfo.InvariantCulture); ;

            _context.ContractHistories.Add(history);
            _context.SaveChanges();


            return contractVisa.Id;
        }

        public ContractVisa GetContractVisaById(int Id)
        {
            return _context.ContractVisas
               .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<ContractVisa> GetContractVisas()
        {
            return _context.ContractVisas.Include(x=>x.Employee);
        }

        public bool RemoveContractVisa(int Id)
        {
            ContractVisa ContractVisa = GetContractVisaById(Id);
            if (ContractVisa == null)
                return false;

            _context.Remove(ContractVisa);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateContractVisa(int Id, ContractVisa contractVisa)
        {

            ContractVisa existContractVisa = GetContractVisaById(Id);
            if (existContractVisa == null)
                return false;
            existContractVisa.ContractId = contractVisa.ContractId;
            existContractVisa.EmployeeId = contractVisa.EmployeeId;
            existContractVisa.VisaById = contractVisa.VisaById;
            //existContractVisa.VisaByName = contractVisa.VisaByName;
            existContractVisa.VisaDate = contractVisa.VisaDate;


            //var employee = _context.Employees.SingleOrDefault(x => x.Id == contractVisa.EmployeeId);
            //if (employee != null) { existContractVisa.EmployeeName = employee.FirstName + ' ' + employee.Father; }

            _context.Update(existContractVisa);
            _context.SaveChanges();


            // Contract Info 
            var cont = _context.Contracts.Find(contractVisa.ContractId);
            if (cont != null)
            {
                cont.ContractStatusId = (int)EnumHelper.ContractStatus.Visa;
                //cont.ContractStatusName = _context.ContractStatuses.Find(cont.ContractStatusId).Name;
                if (contractVisa.EmployeeId != null)
                {
                    cont.EmployeeId = contractVisa.EmployeeId;
                    //cont.EmployeeName = contractVisa.EmployeeName;
                }
                _context.Update(cont);
                _context.SaveChanges();
            }



            // Adding To Contract History 
            ContractHistory history = new ContractHistory();
            history.ContractId = contractVisa.ContractId;
            history.CustomerId = cont.CustomerId;
            history.ForeignAgencyId = cont.ForeignAgencyId;
            history.EmployeeId = cont.EmployeeId;
            history.ActionId = (int)EnumHelper.ContractAction.Visa;
            history.ContractStatusId = cont.ContractStatusId;
            //history.ActionByName = contractVisa.VisaByName;
            history.ActionById = contractVisa.VisaById;
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

            return true;
        }
    }
}
