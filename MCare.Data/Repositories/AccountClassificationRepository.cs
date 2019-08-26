using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class AccountClassificationRepository : IAccountClassificationRepository
    {
        private NajmetAlraqeeContext _context;
        public AccountClassificationRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public AccountClassification GetAccountClassificationById(int id)
        {
            return _context.AccountClassifications.Find(id);
        }
        public int AddAccountClassification(AccountClassification type)
        {
            _context.AccountClassifications.Add(type);
            _context.SaveChanges();
            return type.Id;
        }
        public IQueryable<AccountClassification> GetAccountClassifications()
        {
            return _context.AccountClassifications;
        }
        public bool RemoveAccountClassification(int id)
        {
            var type = _context.AccountClassifications.SingleOrDefault(x => x.Id == id);
            if (type == null)
                return false;
            _context.AccountClassifications.Remove(type);
            _context.SaveChanges();
            return true;
        }
        public bool UpdateAccountClassification(int id, AccountClassification accountClassification)
        {
            AccountClassification existAccountClassification = GetAccountClassificationById(id);
            if (existAccountClassification == null)
                return false;
            existAccountClassification.DescriptionAr = accountClassification.DescriptionAr;
            existAccountClassification.DescriptionEn = accountClassification.DescriptionEn;
            existAccountClassification.TypeId  = accountClassification.TypeId;

            _context.Update(existAccountClassification);
            _context.SaveChanges();

            return true;
        }
    }
}
