using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Constants;
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
        public int RecruitmentQaid(SnadReceipt snadReceipt)
        {
            // Add RecruitmentQaid First 
            RecruitmentQaid qaid = new RecruitmentQaid
            {
                QaidDate = DateTime.UtcNow.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                StatusId = (int)EnumHelper.RecruitmentQaidStatus.Open
            };
            var getCurrentFinancialPeriod = _context.FinancialPeriods.Where(x => x.FinancialPeriodStatusId == (int)EnumHelper.FinancPeriodStatus.CURRENT).SingleOrDefault();
            if (getCurrentFinancialPeriod != null)
            {
                qaid.FinancialPeriodId = getCurrentFinancialPeriod.Id;
            }
            if (snadReceipt.SnadReceiptTypeId == (int)EnumHelper.ReceiptdocType.SnadReceive)
            {
                qaid.TypeId = (int)EnumHelper.RecruitmentQaidTypes.Exchange;
            }
            
            _context.RecruitmentQaids.Add(qaid);
            _context.SaveChanges();

            // Add RecruitmentQaidDetails 
            //RecruitmentQaidDetail detailDebit = new RecruitmentQaidDetail
            //{
            //    QaidId = qaid.Id,
            //    Debit = snadReceipt.Amount,
            //    TypeId = (int)EnumHelper.RecruitmentQaidDetailType.Debit,
            //    AccountTreeId = snadReceipt.Expense.AccountTreeId,
            //    Note = ""
            //};
            //_context.RecruitmentQaidDetails.Add(detailDebit);
            //_context.SaveChanges();

            //Add RecruitmentQaidDetails
            //RecruitmentQaidDetail detailCredit = new RecruitmentQaidDetail
            //{
            //    QaidId = qaid.Id,
            //    Credit = receipt.Amount,
            //    TypeId = (int)EnumHelper.RecruitmentQaidDetailType.Credit,
            //    AccountTreeId = receipt.PaymentMethod.AccountTreeId,
            //    Note = ""
            //};
            //_context.RecruitmentQaidDetails.Add(detailCredit);
            //_context.SaveChanges();

            return qaid.Id;
        }

        public int AddSnadReceipt(SnadReceipt snadReceipt)
        {

            // Add RecruitmentQaid First 
            var qaidId = RecruitmentQaid(snadReceipt);

            //snadReceipt.VAT = 0;
            var getCurrentFinancialPeriodrec = _context.FinancialPeriods.Where(x => x.FinancialPeriodStatusId == (int)EnumHelper.FinancPeriodStatus.CURRENT).SingleOrDefault();
            if (getCurrentFinancialPeriodrec != null)
            {
                snadReceipt.FinancialPeriodId = getCurrentFinancialPeriodrec.Id;
            }
            snadReceipt.QaidNo = qaidId;
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
