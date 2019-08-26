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
    public class ContractReturnRepository : IContractReturnRepository
    {

        private NajmetAlraqeeContext _context;

        public ContractReturnRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddContractReturn(ContractReturn contract_return)
        {
            _context.ContractReturns.Add(contract_return);
            _context.SaveChanges();

            // Contract Info 
            var cont = _context.Contracts.Find(contract_return.ContractId);
            if (cont != null)
            {
                cont.ContractStatusId = (int)EnumHelper.ContractStatus.Return;
                _context.Update(cont);
                _context.SaveChanges();
            }



            // Adding To Contract History 
            ContractHistory history = new ContractHistory();
            history.ContractId = cont.Id;
            history.CustomerId = cont.CustomerId;
            history.ForeignAgencyId = cont.ForeignAgencyId;
            history.EmployeeId = cont.EmployeeId;
            history.ActionId = (int)EnumHelper.ContractAction.Return;
            history.ContractStatusId = cont.ContractStatusId;
            //history.ActionByName = contractSelect.SelectByName;
            history.ActionById = contract_return.CreatedById;
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



            return contract_return.Id;
        }

        public ContractReturn GetContractReturnById(int Id)
        {
            return _context.ContractReturns.Include(x => x.ReturnReason).Include(x => x.Employee).Include(x=>x.ContractType)
                .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<ContractReturn> GetContractReturns()
        {
            return _context.ContractReturns.Include(x=>x.ReturnReason).Include(x => x.Employee).Include(x => x.ContractType);
        }

        public bool RemoveContractReturn(int Id)
        {
            ContractReturn contract_Reason = GetContractReturnById(Id);
            if (contract_Reason == null)
                return false;
            _context.Remove(contract_Reason);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateContractReturn(int Id, ContractReturn contract_return)
        {
            //UserDelegate existdelegateuser = GetDelegateById(Id);
            //if (existdelegateuser == null)
            //    return false;
            //existdelegateuser.Name = del.Name;
            //existdelegateuser.NationalityId = del.NationalityId;
            //existdelegateuser.DelegateTypeId = del.DelegateTypeId;
            //existdelegateuser.CommissionValue = del.CommissionValue;
            //existdelegateuser.CommissionPrecentage = del.CommissionPrecentage;
            //existdelegateuser.AccountNoTree = del.AccountNoTree;
            //existdelegateuser.DeservedAmount = del.DeservedAmount;
            //existdelegateuser.RemainderAmount = del.RemainderAmount;
            //existdelegateuser.TransferAmount = del.TransferAmount;

            ////var delegatetype = _context.DelegateTypes.SingleOrDefault(x => x.Id == existdelegateuser.DelegateTypeId);
            //////if (delegatetype != null) { existdelegateuser.DelegateTypeName = delegatetype.Name; }

            ////var nationality = _context.Nationalities.SingleOrDefault(x => x.Id == existdelegateuser.NationalityId);
            ////if (delegatetype != null) { existdelegateuser.NationalityName = nationality.Name; }


            //_context.Update(existdelegateuser);
            //_context.SaveChanges();

            return true;
        }
    }
}
