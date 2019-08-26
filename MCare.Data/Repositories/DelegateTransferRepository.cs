using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
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
        public int AddDelegateTransfer(DelegateTransfer delegateTransfer)
        {
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
