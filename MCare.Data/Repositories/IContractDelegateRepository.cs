using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IContractDelegateRepository
    {
        int AddContractDelegation(ContractDelegation deleg);
        ContractDelegation GetContractDelegationById(int Id);
        IQueryable<ContractDelegation> GetContractDelegations();
        bool RemoveContractDelegation(int Id);
        bool UpdateContractDelegation(int Id, ContractDelegation contractSelect);
    }
}
