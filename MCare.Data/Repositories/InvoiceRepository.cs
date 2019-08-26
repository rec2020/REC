using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private NajmetAlraqeeContext _context;

        public InvoiceRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public int AddInvoice(Invoice invoice)
        {
            invoice.Total = invoice.Amount - invoice.Discount;
            _context.Invoices.Add(invoice);
            _context.SaveChanges();

            return invoice.Id;
        }

        public Invoice GetInvoiceById(int Id)
        {
            return _context.Invoices.Include(x=>x.Contract)
                .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<Invoice> GetInvoices()
        {
            return _context.Invoices.Include(x => x.Contract);
        }

        public bool RemoveInvoice(int Id)
        {
            Invoice invoice = GetInvoiceById(Id);
            if (invoice == null)
                return false;

            _context.Remove(invoice);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateInvoice(int Id, Invoice invoice)
        {
            Decimal ContractAmount = 0;
            if (invoice.ContractNo >0 ) { 
            Contract contract = _context.Contracts.Find(invoice.ContractNo);
                ContractAmount = contract.ContractCost;
            }
            Invoice existinvoice = GetInvoiceById(Id);
            if (existinvoice == null)
                return false;
            existinvoice.InvoiceDate = invoice.InvoiceDate;
            existinvoice.Note = invoice.Note;
            existinvoice.Discount = invoice.Discount;
            existinvoice.Total = ContractAmount - existinvoice.Discount;

            _context.Update(existinvoice);
            _context.SaveChanges();

            return true;
        }
    }
}
