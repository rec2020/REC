using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class DelegateTypeRepository : IDelegateTypeRepository
    {

        private NajmetAlraqeeContext _context;

        public DelegateTypeRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public long AddDelegateType(DelegateType delegateType)
        {
            _context.DelegateTypes.Add(delegateType);
            _context.SaveChanges();

            return delegateType.Id;
        }

        public DelegateType GetDelegateTypeById(int id)
        {
            return _context.DelegateTypes.Find(id);
        }

        public IQueryable<DelegateType> GetDelegateTypes()
        {
            return _context.DelegateTypes;
        }

        public bool RemoveDelegateType(int id)
        {
            var delegatetype = _context.DelegateTypes.SingleOrDefault(x => x.Id == id);
            if (delegatetype == null)
                return false;

            _context.DelegateTypes.Remove(delegatetype);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateDelegateType(int id, DelegateType delegateType)
        {
            DelegateType existdelegatetype = GetDelegateTypeById(id);
            if (existdelegatetype == null)
                return false;
            existdelegatetype.Name = delegateType.Name;
            _context.Update(existdelegatetype);
            _context.SaveChanges();

            return true;
        }
    }
}
