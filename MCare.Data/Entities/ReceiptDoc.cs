using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class ReceiptDoc 
    {
        [Key]
        public int Id { get; set; }
        public int? ReceiptdocTypeId { get; set; }
        public int? ContractId { get; set; }
        public int? CustomerId { get; set; }
        public decimal Amount { get; set; }
        public decimal VAT { get; set; }
        public string Note { get; set; }
        public string ReceiptDate { get; set; }
        public string ReceiptByUser { get; set; }
        public string ReceiptByUserName { get; set; }
        public int? ContractTypeId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int QaidNo { get; set; }
        public int? FinancialPeriodId { get; set; }
        public virtual ReceiptDocType ReceiptdocType { get; set; }
        //public virtual ContractType ContractType { get; set; }
        public virtual  Contract Contract  { get; set; }
        public virtual PaymentMethod PaymentMethod  { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual FinancialPeriod FinancialPeriod { get; set; }
    }
}
