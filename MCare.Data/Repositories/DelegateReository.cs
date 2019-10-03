using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class DelegateReository : IDelegateReository
    {

        private NajmetAlraqeeContext _context;

        public DelegateReository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int AddDelegate(UserDelegate deleg)
        {
            deleg.DeservedAmount = 0;
            deleg.RemainderAmount = 0;
            deleg.TransferAmount = 0;
            _context.UserDelegates.Add(deleg);
            _context.SaveChanges();

            return deleg.Id;
        }

        public UserDelegate GetDelegateById(int Id)
        {
            return _context.UserDelegates.Include(x=>x.AccountTree)
               .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<UserDelegate> GetDelegates()
        {
            return _context.UserDelegates.Include("DelegateType").Include(x=>x.Nationality).Include(x => x.AccountTree);
        }

        public bool RemoveDelegate(int Id)
        {
            UserDelegate delegateuser = GetDelegateById(Id);
            if (delegateuser == null)
                return false;

            _context.Remove(delegateuser);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateDelegate(int Id, UserDelegate del)
        {

            UserDelegate existdelegateuser = GetDelegateById(Id);
            if (existdelegateuser == null)
                return false;
            existdelegateuser.Name = del.Name;
            existdelegateuser.NationalityId = del.NationalityId;
            existdelegateuser.DelegateTypeId = del.DelegateTypeId;
            existdelegateuser.CommissionValue = del.CommissionValue;
            existdelegateuser.CommissionPrecentage = del.CommissionPrecentage;
            existdelegateuser.AccountTreeId = del.AccountTreeId;
            //existdelegateuser.DeservedAmount = del.DeservedAmount;
            //existdelegateuser.RemainderAmount = del.RemainderAmount;
            //existdelegateuser.TransferAmount = del.TransferAmount;

            //var delegatetype = _context.DelegateTypes.SingleOrDefault(x => x.Id == existdelegateuser.DelegateTypeId);
            ////if (delegatetype != null) { existdelegateuser.DelegateTypeName = delegatetype.Name; }

            //var nationality = _context.Nationalities.SingleOrDefault(x => x.Id == existdelegateuser.NationalityId);
            //if (delegatetype != null) { existdelegateuser.NationalityName = nationality.Name; }


            _context.Update(existdelegateuser);
            _context.SaveChanges();

            return true;
        }
    }
}
