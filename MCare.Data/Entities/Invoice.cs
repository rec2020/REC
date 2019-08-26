using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string  InvoiceDate  { get; set; }
        public string  Note  { get; set; }
        public int? ContractNo { get; set; }
        public decimal  Amount { get; set; }
        public string  Customer { get; set; } // 
        public decimal Discount { get; set; }// 
        public decimal VatPercentage { get; set; }// 
        public decimal VatValue { get; set; }// 
        public decimal  Total { get; set; }//


        public virtual Contract Contract { get; set; }
    }
}
