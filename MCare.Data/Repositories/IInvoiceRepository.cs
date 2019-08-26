using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
   public  interface IInvoiceRepository
    {
        int AddInvoice(Invoice invoice);
        Invoice GetInvoiceById(int Id);
        IQueryable<Invoice> GetInvoices();
        bool RemoveInvoice(int Id);
        bool UpdateInvoice(int Id, Invoice invoice);
    }
}
