using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
     public  interface IContractTypeRepository
    {
        IQueryable<ContractType> GetContractTypes();
        ContractType GetContractTypeById(int id);
        int AddContractType(ContractType cContractType);
        bool UpdateContractType(int id, ContractType ContractType);
        bool RemoveContractType(int id);
    }
}
