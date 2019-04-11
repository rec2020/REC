using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IContractSelectRepository
    {

        int AddContractSelect(ContractSelect deleg);
        ContractSelect GetContractSelectById(int Id);
        IQueryable<ContractSelect> GetContractSelects();
        bool RemoveContractSelect(int Id);
        bool UpdateContractSelect(int Id, ContractSelect contractSelect);
    }
}
