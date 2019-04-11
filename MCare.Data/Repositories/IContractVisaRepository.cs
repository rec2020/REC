using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IContractVisaRepository
    {
        int AddContractVisa(ContractVisa deleg);
        ContractVisa GetContractVisaById(int Id);
        IQueryable<ContractVisa> GetContractVisas();
        bool RemoveContractVisa(int Id);
        bool UpdateContractVisa(int Id, ContractVisa contractVisa);
    }
}
