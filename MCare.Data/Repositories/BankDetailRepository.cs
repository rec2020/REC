using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
   public  class BankDetailRepository :IBankDetailRepository
    {

        private NajmetAlraqeeContext _context;

        public BankDetailRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int AddBankDetail(BankDetail detail)
        {
            _context.BankDetails.Add(detail);
            _context.SaveChanges();

            return detail.Id;
        }

        public BankDetail GetBankDetailById(int Id)
        {
            return _context.BankDetails
               .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<BankDetail> GetBankDetails()
        {
            return _context.BankDetails;
        }

        public bool RemoveBankDetail(int Id)
        {
            BankDetail bank = GetBankDetailById(Id);
            if (bank == null)
                return false;

            _context.Remove(bank);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateBankDetail(int Id, BankDetail detail)
        {
            BankDetail existbank= GetBankDetailById(Id);
            if (existbank == null)
                return false;
            existbank.Name = detail.Name;
            existbank.AccountNumber = detail.AccountNumber;
            existbank.AccountTreeId = detail.AccountTreeId;
            _context.Update(existbank);
            _context.SaveChanges();

            return true;
        }
    }
}
