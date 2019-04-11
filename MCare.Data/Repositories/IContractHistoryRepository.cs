using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
   public interface IContractHistoryRepository
    {
        int AddContractHistory(ContractHistory history);
        ContractHistory GetContractHistoryById(int Id);
        IQueryable<ContractHistory> GetContractHistorys();
        bool RemoveContractHistory(int Id);
        bool UpdateContractHistory(int Id, ContractHistory contractHistory);
    }
}
