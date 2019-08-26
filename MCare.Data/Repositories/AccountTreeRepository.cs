using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class AccountTreeRepository : IAccountTreeRepository
    {
        private NajmetAlraqeeContext _context;

        public AccountTreeRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddAccountTree(AccountTree accTree)
        {
            _context.AccountTrees.Add(accTree);
            _context.SaveChanges();
            return accTree.Id;
        }
        public AccountTree GetAccountTreeById(int Id)
        {
            return _context.AccountTrees.Include(x => x.AccType).Include(x => x.AccClassification)
              .SingleOrDefault(p => p.Id == Id);
        }
        public IQueryable<AccountTree> GetAccountTrees()
        {
            return _context.AccountTrees.Include(x => x.AccType).Include(x => x.AccClassification).Include(x=>x.Parent);
        }
        public bool RemoveAccountTree(int Id)
        {
            AccountTree accTree = GetAccountTreeById(Id);
            if (accTree == null)
                return false;
            _context.Remove(accTree);
            _context.SaveChanges();

            return true;
        }
        public bool UpdateAccountTree(int Id, AccountTree accTree)
        {
            AccountTree existaccTree = GetAccountTreeById(Id);
            if (existaccTree == null)
                return false;
            existaccTree.AccClassificationId = accTree.AccClassificationId;
            //existaccTree.AccountLevel = accTree.AccountLevel;
            //existaccTree.AccountNo = accTree.AccountNo;
            //existaccTree.Accprev = accTree.Accprev;
            existaccTree.AccTypeId = accTree.AccTypeId;
            existaccTree.Balance = accTree.Balance;
            existaccTree.CostCenter = accTree.CostCenter;
            existaccTree.Credit = accTree.Credit;
            existaccTree.Debit = accTree.Debit;
            existaccTree.DescriptionAr = accTree.DescriptionAr;
            existaccTree.DescriptionEn = accTree.DescriptionEn;
            existaccTree.EhalkPrecent = accTree.EhalkPrecent;
            existaccTree.FixedAssetDate = accTree.FixedAssetDate;
            existaccTree.HighLimitForBalance = accTree.HighLimitForBalance;
            existaccTree.JE = accTree.JE;
            //existaccTree.ParentId = accTree.ParentId;
            existaccTree.PriceInExhibtion = accTree.PriceInExhibtion;

            _context.Update(existaccTree);
            _context.SaveChanges();

            return true;
        }
    }
}
