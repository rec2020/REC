using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IContractRepository
    {
        int AddContract(Contract deleg);
        Contract GetContractById(int Id);
        IQueryable<Contract> GetContracts();
        bool RemoveContract(int Id);
        bool UpdateContract(int Id, Contract contract);
        bool CloseContract(int Id, Contract contract);
        bool UpdateTestDay(int id);
    }
}
