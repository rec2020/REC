using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
     public interface ISnadReceiptRepository
    {
        int AddSnadReceipt(SnadReceipt snadReceipt);
        SnadReceipt GetSnadReceiptById(int Id);
        IQueryable<SnadReceipt> GetSnadReceipts();
        bool UpdateSnadReceipt(int Id, SnadReceipt snadReceipt);
       
    }
}
