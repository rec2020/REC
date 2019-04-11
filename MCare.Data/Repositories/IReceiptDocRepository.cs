using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IReceiptDocRepository
    {
        int AddReceiptDoc(ReceiptDoc receipt);
        ReceiptDoc GetReceiptDocById(int Id);
        IQueryable<ReceiptDoc> GetReceiptDocs();
        bool RemoveReceiptDoc(int Id);
        bool UpdateReceiptDoc(int Id, ReceiptDoc receipt);
    }
}
