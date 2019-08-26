using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
   public class SnadReceiptRepository : ISnadReceiptRepository
    {
        private readonly NajmetAlraqeeContext _context;
        public SnadReceiptRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int AddSnadReceipt(SnadReceipt snadReceipt)
        {
            //snadReceipt.VAT = 0;
            _context.SnadReceipts.Add(snadReceipt);
            _context.SaveChanges();
            
            return snadReceipt.Id;
        }

        public SnadReceipt GetSnadReceiptById(int Id)
        {
            return _context.SnadReceipts.Include(x => x.Expense)
                .Include(x => x.SnadReceiptType).Include(x => x.PaymentMethod)
               .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<SnadReceipt> GetSnadReceipts()
        {
            return _context.SnadReceipts.Include(x=>x.Expense)
               .Include(x => x.SnadReceiptType).Include(x => x.PaymentMethod);
        }

        public bool UpdateSnadReceipt(int Id, SnadReceipt snadReceipt)
        {
            SnadReceipt exist_SnadReceipt = GetSnadReceiptById(Id);
            if (exist_SnadReceipt == null)
                return false;
            exist_SnadReceipt.PaymentMethodId = snadReceipt.PaymentMethodId;
            exist_SnadReceipt.QuidNumber = snadReceipt.QuidNumber;
            exist_SnadReceipt.SnadByUser = snadReceipt.SnadByUser;
            exist_SnadReceipt.SnadByUserName = snadReceipt.SnadByUserName;
            exist_SnadReceipt.SnadDate = snadReceipt.SnadDate;
            //exist_SnadReceipt.ExpenseId = snadReceipt.ExpenseId;
            exist_SnadReceipt.SnadReceiptTypeId = snadReceipt.SnadReceiptTypeId;
            exist_SnadReceipt.VAT = snadReceipt.VAT;
            exist_SnadReceipt.Amount = snadReceipt.Amount;
            exist_SnadReceipt.FinancialYear = snadReceipt.FinancialYear;
            exist_SnadReceipt.Note = snadReceipt.Note;

            _context.Update(exist_SnadReceipt);
            _context.SaveChanges();

            return true;
        }
    }
}
