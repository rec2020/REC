using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class ReceiptDocTypeRepository : IReceiptDocTypeRepository
    {
        private NajmetAlraqeeContext _context;
        public ReceiptDocTypeRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddReceiptDocType(ReceiptDocType receiptDocType)
        {
            _context.ReceiptDocTypes.Add(receiptDocType);
            _context.SaveChanges();

            return receiptDocType.Id;
        }

        public ReceiptDocType GetReceiptDocTypeById(int id)
        {
            return _context.ReceiptDocTypes.Find(id);
        }

        public IQueryable<ReceiptDocType> GetReceiptDocTypes()
        {
            return _context.ReceiptDocTypes;
        }

        public bool RemoveReceiptDocType(int id)
        {
            var receipt = _context.ReceiptDocTypes.SingleOrDefault(x => x.Id == id);
            if (receipt == null)
                return false;

            _context.ReceiptDocTypes.Remove(receipt);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateReceiptDocType(int id, ReceiptDocType receiptDocType)
        {
            ReceiptDocType existreceipt = GetReceiptDocTypeById(id);
            if (existreceipt == null)
                return false;
            existreceipt.Name = receiptDocType.Name;
            _context.Update(existreceipt);
            _context.SaveChanges();
            return true;
        }
    }
}
