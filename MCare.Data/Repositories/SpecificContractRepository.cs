using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class SpecificContractRepository : ISpecificContractRepository
    {

        private NajmetAlraqeeContext _context;

        public SpecificContractRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddSpecificContract(SpecificContract spec_cont)
        {
            _context.SpecificContracts.Add(spec_cont);
            _context.SaveChanges();
            return spec_cont.Id;
        }

        public SpecificContract GetSpecificContractById(int Id)
        {
            return _context.SpecificContracts.Include(x => x.SpecialEmployee).Include(x=>x.ForeignAgency).
                Include(x=>x.Customer).Include(x=>x.ContractStatus)
              .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<SpecificContract> GetSpecificContracts()
        {
            return _context.SpecificContracts.Include(x => x.SpecialEmployee).Include(x => x.ForeignAgency).
               Include(x => x.Customer).Include(x => x.ContractStatus);
        }

        public bool RemoveSpecificContract(int Id)
        {
            SpecificContract spec_Con = GetSpecificContractById(Id);
            if (spec_Con == null)
                return false;
            _context.Remove(spec_Con);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateSpecificContract(int Id, SpecificContract spec_cont)
        {
            SpecificContract existSpecificContract = GetSpecificContractById(Id);
            if (existSpecificContract == null)
                return false;
            existSpecificContract.CustomerId = spec_cont.CustomerId;
            existSpecificContract.ContractStatusId = spec_cont.ContractStatusId;
            existSpecificContract.DelegationDate = spec_cont.DelegationDate;
            existSpecificContract.ForeignAgencyId = spec_cont.ForeignAgencyId;
            existSpecificContract.LicenceNumber = spec_cont.LicenceNumber;
            existSpecificContract.VAT = spec_cont.VAT;
            existSpecificContract.ContractCost = spec_cont.ContractCost;

            _context.Update(existSpecificContract);
            _context.SaveChanges();

            return true;
        }
    }
}
