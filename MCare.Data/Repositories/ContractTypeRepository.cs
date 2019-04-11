using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class ContractTypeRepository : IContractTypeRepository
    {

        private NajmetAlraqeeContext _context;

        public ContractTypeRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddContractType(ContractType ContractType)
        {
            _context.ContractTypes.Add(ContractType);
            _context.SaveChanges();

            return ContractType.Id;
        }

        public ContractType GetContractTypeById(int id)
        {
            return _context.ContractTypes.Find(id);
        }

        public IQueryable<ContractType> GetContractTypes()
        {
            return _context.ContractTypes;
        }

        public bool RemoveContractType(int id)
        {
            var ContractType = _context.ContractTypes.SingleOrDefault(x => x.Id == id);
            if (ContractType == null)
                return false;

            _context.ContractTypes.Remove(ContractType);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateContractType(int id, ContractType ContractType)
        {
            ContractType existContractType = GetContractTypeById(id);
            if (existContractType == null)
                return false;
            existContractType.Name = ContractType.Name;
            _context.Update(existContractType);
            _context.SaveChanges();

            return true;
        }
    }
}
