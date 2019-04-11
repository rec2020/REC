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
    public class ContractSelectRepository : IContractSelectRepository
    {
        private NajmetAlraqeeContext _context;

        public ContractSelectRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int AddContractSelect(ContractSelect contractSelect)
        {
            _context.ContractSelects.Add(contractSelect);
            _context.SaveChanges();


            // Contract Info 
            var cont = _context.Contracts.Find(contractSelect.ContractId);
            if (cont != null)
            {
                cont.ContractStatusId = (int)EnumHelper.ContractStatus.Select;
                //cont.ContractStatusName = _context.ContractStatuses.Find(cont.ContractStatusId).Name;
                if (contractSelect.ForeignAgencyId != null)
                {
                    cont.ForeignAgencyId = contractSelect.ForeignAgencyId;
                }
                _context.Update(cont);
                _context.SaveChanges();
            }



            // Adding To Contract History 
            ContractHistory history = new ContractHistory();
            history.ContractId = contractSelect.ContractId;
            history.CustomerId = cont.CustomerId;
            history.ForeignAgencyId = cont.ForeignAgencyId;
            history.EmployeeId = cont.EmployeeId;
            history.ActionId = (int)EnumHelper.ContractAction.Select;
            history.ContractStatusId = cont.ContractStatusId;
            //history.ActionByName = contractSelect.SelectByName;
            history.ActionById = contractSelect.SelectById;
            history.ActionByName = _context.Users.Where(x => x.Id.Contains(history.ActionById)).SingleOrDefault().UserName;
            var foreignAgencies = _context.ForeignAgencies.SingleOrDefault(x => x.Id == history.ForeignAgencyId);
            if (foreignAgencies != null) { history.ForeignAgencyName = foreignAgencies.OfficeName; }
            var cust = _context.Customers.SingleOrDefault(x => x.Id == history.CustomerId);
            if (cust != null) { history.CustomerName = cust.Name; }

            history.ActionDate = DateTime.UtcNow.ToString("dd/MM/yyyy",
                                       CultureInfo.InvariantCulture);

            _context.ContractHistories.Add(history);
            _context.SaveChanges();



            return contractSelect.Id;
        }

        public ContractSelect GetContractSelectById(int Id)
        {
            return _context.ContractSelects.Include(x => x.ForeignAgency)
               .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<ContractSelect> GetContractSelects()
        {
            return _context.ContractSelects.Include(x=>x.ForeignAgency)
                ;
        }

        public bool RemoveContractSelect(int Id)
        {
            ContractSelect contractSelect = GetContractSelectById(Id);
            if (contractSelect == null)
                return false;

            _context.Remove(contractSelect);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateContractSelect(int Id, ContractSelect contractSelect)
        {

            ContractSelect existcontractSelect = GetContractSelectById(Id);
            if (existcontractSelect == null)
                return false;
            existcontractSelect.ContractId = contractSelect.ContractId;
            existcontractSelect.ForeignAgencyId = contractSelect.ForeignAgencyId;
            existcontractSelect.PolNumer = contractSelect.PolNumer;
            existcontractSelect.PolNumerDate = contractSelect.PolNumerDate;
            existcontractSelect.SelectById = contractSelect.SelectById; ;
            //existcontractSelect.SelectByName = contractSelect.SelectByName;
            existcontractSelect.SelectDate = contractSelect.SelectDate;



            _context.Update(existcontractSelect);
            _context.SaveChanges();


            // Contract Info 
            var cont = _context.Contracts.Find(contractSelect.ContractId);
            if (cont != null)
            {
                cont.ContractStatusId = (int)EnumHelper.ContractStatus.Select;
                if (contractSelect.ForeignAgencyId != null)
                {
                    cont.ForeignAgencyId = contractSelect.ForeignAgencyId;
                }
                _context.Update(cont);
                _context.SaveChanges();
            }



            // Adding To Contract History 
            ContractHistory history = new ContractHistory();
            history.ContractId = contractSelect.ContractId;
            history.CustomerId = cont.CustomerId;
            history.ForeignAgencyId = cont.ForeignAgencyId;
            history.EmployeeId = cont.EmployeeId;
            history.ActionId = (int)EnumHelper.ContractAction.Select;
            history.ContractStatusId = cont.ContractStatusId;
           var select  = contractSelect.SelectById;
            history.ActionById = contractSelect.SelectById;
            history.ActionByName = _context.Users.Where(x => x.Id.Contains(history.ActionById)).SingleOrDefault().UserName;
            var foreignAgencies = _context.ForeignAgencies.SingleOrDefault(x => x.Id == history.ForeignAgencyId);
            if (foreignAgencies != null) { history.ForeignAgencyName = foreignAgencies.OfficeName; }
            var cust = _context.Customers.SingleOrDefault(x => x.Id == history.CustomerId);
            if (cust != null) { history.CustomerName = cust.Name; }
            history.ActionDate = DateTime.UtcNow.ToString("dd/MM/yyyy",
                                       CultureInfo.InvariantCulture);

            _context.ContractHistories.Add(history);
            _context.SaveChanges();


            return true;
        }
    }
}
