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
    public class DelegateTransferRepository : IDelegateTransferRepository
    {
        private NajmetAlraqeeContext _context;

        public DelegateTransferRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int RecruitmentQaid(DelegateTransfer delegateTransfer)
        {
            #region AddQaid 
            // Add Qaid First 
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
            qaid.TypeId = (int)EnumHelper.RecruitmentQaidTypes.Transfer;
            _context.RecruitmentQaids.Add(qaid);
            _context.SaveChanges();
            #endregion

            #region DEBIT
            // Add RecruitmentQaidDetails  DEBIT 
            RecruitmentQaidDetail detailDebit = new RecruitmentQaidDetail
            {
                QaidId = qaid.Id,
                Debit = delegateTransfer.Amount,
                TypeId = (int)EnumHelper.RecruitmentQaidDetailType.Debit,
                AccountTreeId = delegateTransfer.UserDelegate.AccountTreeId,
                Note = ""
            };
            _context.RecruitmentQaidDetails.Add(detailDebit);
            _context.SaveChanges();

            // change In AccountTree For Debit Account ----------------------------------------
            AccountTree existAcc = _context.AccountTrees.Where(x => x.Id == detailDebit.AccountTreeId).SingleOrDefault();
            if (existAcc != null)
            {
                existAcc.Debit = existAcc.Debit + detailDebit.Debit;
                _context.Update(existAcc);
                _context.SaveChanges();
            }

            #endregion

            #region CREDIT
            // Add RecruitmentQaidDetails 
            RecruitmentQaidDetail detailCredit = new RecruitmentQaidDetail
            {
                QaidId = qaid.Id,
                Credit = delegateTransfer.Amount,
                TypeId = (int)EnumHelper.RecruitmentQaidDetailType.Credit,
                AccountTreeId = delegateTransfer.PaymentMethod.AccountTreeId,
                Note = ""
            };
            _context.RecruitmentQaidDetails.Add(detailCredit);
            _context.SaveChanges();
            // change In AccountTree For Credit Account ---------------------------------------------
            AccountTree existAccCredit = _context.AccountTrees.Where(x => x.Id == detailCredit.AccountTreeId).SingleOrDefault();
            if (existAccCredit != null)
            {
                existAccCredit.Credit = existAccCredit.Credit + detailCredit.Credit;
                _context.Update(existAccCredit);
                _context.SaveChanges();
            }

            #endregion

            return qaid.Id;
        }
        public int AddDelegateTransfer(DelegateTransfer delegateTransfer)
        {
            // Add RecruitmentQaid First 
            var qaidId = RecruitmentQaid(delegateTransfer);
            //snadReceipt.VAT = 0;
            var getCurrentFinancialPeriodrec = _context.FinancialPeriods.Where(x => x.FinancialPeriodStatusId == (int)EnumHelper.FinancPeriodStatus.CURRENT).SingleOrDefault();
            if (getCurrentFinancialPeriodrec != null)
            {
                delegateTransfer.FinancialPeriodId = getCurrentFinancialPeriodrec.Id;
            }
            delegateTransfer.QaidNo = qaidId;
            
            _context.DelegateTransfers.Add(delegateTransfer);
            _context.SaveChanges();

            var existfordelegate = _context.UserDelegates.SingleOrDefault(x => x.Id == delegateTransfer.UserDelegateId);
            existfordelegate.TransferAmount = existfordelegate.TransferAmount + delegateTransfer.Amount;
            _context.Update(existfordelegate);
            _context.SaveChanges();

            return delegateTransfer.Id;
        }

        public DelegateTransfer GetDelegateTransferById(int Id)
        {
            return _context.DelegateTransfers.Include(x => x.UserDelegate).Include(x => x.PaymentMethod)
                 .Include(x => x.Purpose).Include(x => x.TransferBank).Include(x => x.Currency)
               .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<DelegateTransfer> GetDelegateTransfers()
        {
            return _context.DelegateTransfers.Include(x => x.UserDelegate).Include(x => x.PaymentMethod)
                .Include(x => x.TransferBank).Include(x => x.Currency)
                .Include(x => x.Purpose);
        }

        public bool RemoveDelegateTransfer(int Id)
        {
            DelegateTransfer delegatetranfer = GetDelegateTransferById(Id);
            if (delegatetranfer == null)
                return false;
            _context.Remove(delegatetranfer);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateDelegateTransfer(int Id, DelegateTransfer delegateTransfer)
        {
            DelegateTransfer existdelegateTransfer = GetDelegateTransferById(Id);
            if (existdelegateTransfer == null)
                return false;
            existdelegateTransfer.UserDelegateId = delegateTransfer.UserDelegateId;
            existdelegateTransfer.Amount = delegateTransfer.Amount;
            existdelegateTransfer.CurrencyId = delegateTransfer.CurrencyId;
            existdelegateTransfer.Notes = delegateTransfer.Notes;
            existdelegateTransfer.PaymentMethodId = delegateTransfer.PaymentMethodId;
            existdelegateTransfer.PurposeId = delegateTransfer.PurposeId;
            existdelegateTransfer.TransferBankId = delegateTransfer.TransferBankId;
            existdelegateTransfer.TransferDate = delegateTransfer.TransferDate;
            _context.Update(existdelegateTransfer);
            _context.SaveChanges();

            return true;
        }
    }
}
