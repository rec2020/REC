using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Constants;
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
            var totalRecord = _context.ReceiptDocs.Count();
            if (totalRecord == 0)
            {
                receipt.QaidNo = 00001;
            }
            else
            {
                var getLastQauidNo = _context.ReceiptDocs.LastOrDefault();
                receipt.QaidNo = getLastQauidNo.QaidNo + 1;
            }
            _context.ReceiptDocs.Add(receipt);
            _context.SaveChanges();
            if (receipt.ContractTypeId == (int)EnumHelper.ContractType.New || receipt.ContractTypeId == (int)EnumHelper.ContractType.Substitute)
            {
                if (receipt.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadReceive)
                {
                    var cont = _context.Contracts.Find(receipt.ContractId);
                    if (cont != null)
                    {
                        cont.Paid = cont.Paid - receipt.Amount;
                        _context.Update(cont);
                        _context.SaveChanges();
                    }
                }
                if (receipt.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadTaking)
                {
                    var cont = _context.Contracts.Find(receipt.ContractId);
                    if (cont != null)
                    {
                        cont.Paid = cont.Paid + receipt.Amount;
                        cont.Remainder = cont.Remainder - receipt.Amount;
                        _context.Update(cont);
                        _context.SaveChanges();
                    }
                }
            }
            else
            {
                if (receipt.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadReceive)
                {
                    var cont = _context.SpecificContracts.Find(receipt.ContractId);
                    if (cont != null)
                    {
                        cont.Remainder = cont.Remainder - receipt.Amount;
                        _context.Update(cont);
                        _context.SaveChanges();
                    }
                }
                if (receipt.ReceiptdocTypeId == (int)EnumHelper.ReceiptdocType.SnadTaking)
                {
                    var cont = _context.SpecificContracts.Find(receipt.ContractId);
                    if (cont != null)
                    {
                        cont.Paid = cont.Paid + receipt.Amount;
                        _context.Update(cont);
                        _context.SaveChanges();
                    }
                }
            }
            return receipt.Id;
        }

        public ReceiptDoc GetReceiptDocById(int Id)
        {
            return _context.ReceiptDocs.Include(x => x.ReceiptdocType).Include(x => x.Customer).Include(x=>x.PaymentMethod)
            .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<ReceiptDoc> GetReceiptDocs()
        {
            return _context.ReceiptDocs.Include(x => x.ReceiptdocType).Include(x => x.Customer).Include(x => x.PaymentMethod);
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
            existreceipt.PaymentMethodId = rec.PaymentMethodId;
            existreceipt.CustomerId = rec.CustomerId;
            _context.Update(existreceipt);
            _context.SaveChanges();

            return true;
        }
    }
}
