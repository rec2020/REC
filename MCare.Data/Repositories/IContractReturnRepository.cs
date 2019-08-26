using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IContractReturnRepository
    {
        int AddContractReturn(ContractReturn contract_return);
        ContractReturn GetContractReturnById(int Id);
        IQueryable<ContractReturn> GetContractReturns();
        bool RemoveContractReturn(int Id);
        bool UpdateContractReturn(int Id, ContractReturn contract_return);
    }
}
