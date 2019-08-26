using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
   public interface ISpecificContractRepository
    {
        int AddSpecificContract(SpecificContract spec_cont);
        SpecificContract GetSpecificContractById(int Id);
        IQueryable<SpecificContract> GetSpecificContracts();
        bool RemoveSpecificContract(int Id);
        bool UpdateSpecificContract(int Id, SpecificContract spec_cont);
        bool CloseSpecificContract(int Id, SpecificContract spec_cont);
    }
}
