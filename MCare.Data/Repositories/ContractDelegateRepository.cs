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
    public class ContractDelegateRepository : IContractDelegateRepository
    {
            private NajmetAlraqeeContext _context;

        public ContractDelegateRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int AddContractDelegation(ContractDelegation contractDelegation)
        {

            // Contract Info 
            var cont = _context.Contracts.Find(contractDelegation.ContractId);
            // Get JoB Salary 
            var agency = _context.ForeignAgencyJobs.Where(x => x.ForeignAgencyId == contractDelegation.ForeignAgencyId
            && x.IsActive == true && x.JobTypeId == cont.JobTypeId).SingleOrDefault();

            if (agency != null)
            {
                _context.ContractDelegations.Add(contractDelegation);
                _context.SaveChanges();
            }
            

            if (cont != null && agency !=null)
            {
                cont.ContractStatusId = (int)EnumHelper.ContractStatus.Delegate;
                if (contractDelegation.ForeignAgencyId != null)
                {
                    cont.ForeignAgencyId = contractDelegation.ForeignAgencyId;
                }
                //if (agency != null)
                //{
                //    cont.ContractCost = (decimal)agency.Price;
                //    cont.VatCost = (cont.ContractCost) * (5 / 100);
                //    cont.Remainder = cont.ContractCost;
                //}
                _context.Update(cont);
                _context.SaveChanges();
            }

            // Update ForgienAgency 
            if (agency != null)
            {
                var forgeignAgency = _context.ForeignAgencies.SingleOrDefault(x => x.Id == contractDelegation.ForeignAgencyId);
                if (forgeignAgency != null)
                {
                    forgeignAgency.DeservedAmount = (decimal)agency.Price;
                    forgeignAgency.RemainderAmount = forgeignAgency.DeservedAmount;
                    _context.Update(forgeignAgency);
                    _context.SaveChanges();
                }



                // Adding To Contract History 
                ContractHistory history = new ContractHistory();
                history.ContractId = (int)contractDelegation.ContractId;
                history.CustomerId = cont.CustomerId;
                history.ForeignAgencyId = cont.ForeignAgencyId;
                history.EmployeeId = cont.EmployeeId;
                history.ActionId = (int)EnumHelper.ContractAction.Delegate;
                history.ContractStatusId = cont.ContractStatusId;
                history.ActionById = contractDelegation.DelegateById;
                history.ActionByName = _context.Users.Where(x => x.Id.Contains(history.ActionById)).SingleOrDefault().UserName;
                var foreignAgencies = _context.ForeignAgencies.SingleOrDefault(x => x.Id == history.ForeignAgencyId);
                if (foreignAgencies != null) { history.ForeignAgencyName = foreignAgencies.OfficeName; }
                var cust = _context.Customers.SingleOrDefault(x => x.Id == history.CustomerId);
                if (cust != null) { history.CustomerName = cust.Name; }
                history.ActionDate = DateTime.UtcNow.ToString("dd/MM/yyyy",
                                           CultureInfo.InvariantCulture);

                _context.ContractHistories.Add(history);
                _context.SaveChanges();
            }
            return contractDelegation.Id;
        }

        public ContractDelegation GetContractDelegationById(int Id)
        {
            return _context.ContractDelegations
               .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<ContractDelegation> GetContractDelegations()
        {
            return _context.ContractDelegations.Include(x=>x.ForeignAgency);
        }

        public bool RemoveContractDelegation(int Id)
        {
            ContractDelegation ContractDelegation = GetContractDelegationById(Id);
            if (ContractDelegation == null)
                return false;

            _context.Remove(ContractDelegation);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateContractDelegation(int Id, ContractDelegation contractDelegation)
        {

            ContractDelegation existContractDelegation = GetContractDelegationById(Id);
            if (existContractDelegation == null)
                return false;
            existContractDelegation.ContractId = contractDelegation.ContractId;
            existContractDelegation.DelegateById = contractDelegation.DelegateById;
            existContractDelegation.ForeignAgencyId = contractDelegation.ForeignAgencyId;
            existContractDelegation.DelegationDate = contractDelegation.DelegationDate;
            //existContractDelegation.DelegateByName = contractDelegation.DelegateByName;


            //var foreignAgency = _context.ForeignAgencies.SingleOrDefault(x => x.Id == contractDelegation.ForeignAgencyId);
            //if (foreignAgency != null) { existContractDelegation.ForeignAgencyName = foreignAgency.OfficeName; }

            _context.Update(existContractDelegation);
            _context.SaveChanges();


            var cont = _context.Contracts.Find(contractDelegation.ContractId);
            if (cont != null)
            {
                cont.ContractStatusId = (int)EnumHelper.ContractStatus.Delegate;
                if (contractDelegation.ForeignAgencyId != null)
                {
                    cont.ForeignAgencyId = contractDelegation.ForeignAgencyId;
                }
                _context.Update(cont);
                _context.SaveChanges();
            }


            // Adding To Contract History 
            ContractHistory history = new ContractHistory();
            history.ContractId = (int)contractDelegation.ContractId;
            history.CustomerId = cont.CustomerId;
            history.ForeignAgencyId = cont.ForeignAgencyId;
            history.EmployeeId = cont.EmployeeId;
            history.ActionId = (int)EnumHelper.ContractAction.Delegate;
            history.ContractStatusId = cont.ContractStatusId;
            //history.ActionByName = contractDelegation.DelegateByName;
            history.ActionById = contractDelegation.DelegateById;
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
