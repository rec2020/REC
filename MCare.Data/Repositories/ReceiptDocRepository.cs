using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class ReceiptDocRepository : IReceiptDocRepository
    {

        private NajmetAlraqeeContext _context;

        public ReceiptDocRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int AddReceiptDoc(ReceiptDoc receipt)
        {
            _context.ReceiptDocs.Add(receipt);
            _context.SaveChanges();

            return receipt.Id;
        }

        public ReceiptDoc GetReceiptDocById(int Id)
        {
            return _context.ReceiptDocs.Include(x=>x.ReceiptdocType).Include(x => x.Customer)
               .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<ReceiptDoc> GetReceiptDocs()
        {
            return _context.ReceiptDocs.Include(x => x.ReceiptdocType).Include(x=>x.Customer);
        }

        public bool RemoveReceiptDoc(int Id)
        {
            ReceiptDoc receipt = GetReceiptDocById(Id);
            if (receipt == null)
                return false;

            _context.Remove(receipt);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateReceiptDoc(int Id, ReceiptDoc rec)
        {
            ReceiptDoc existreceipt = GetReceiptDocById(Id);
            if (existreceipt == null)
                return false;
            existreceipt.ReceiptDate = rec.ReceiptDate;
            existreceipt.ReceiptByUser = rec.ReceiptByUser;
            existreceipt.VAT = rec.VAT;
            existreceipt.ContractId = rec.ContractId;
            existreceipt.Amount = rec.Amount;
            existreceipt.CustomerId = rec.CustomerId;
            _context.Update(existreceipt);
            _context.SaveChanges();

            return true;
        }
    }
}
