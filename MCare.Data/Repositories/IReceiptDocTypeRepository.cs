using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IReceiptDocTypeRepository
    {
        IQueryable<ReceiptDocType> GetReceiptDocTypes();
        ReceiptDocType GetReceiptDocTypeById(int id);
        int AddReceiptDocType(ReceiptDocType receiptDocType);
        bool UpdateReceiptDocType(int id, ReceiptDocType receiptDocType);
        bool RemoveReceiptDocType(int id);
    }
}
