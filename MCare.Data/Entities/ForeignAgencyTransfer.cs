using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class ForeignAgencyTransfer
    {
        public int Id { get; set; }
        public string  TransferDate { get; set; }
        public int?  ForeignAgencyId { get; set; }
        public decimal Amount { get; set; }
        public int? CurrencyId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? TransferBankId { get; set; }
        public int? PurposeId { get; set; }
        public string  Notes { get; set; }
        public int? FinancialPeriodId { get; set; }
        public int QaidNo { get; set; }


        public virtual TransferPurpose Purpose  { get; set; }
        public virtual  ForeignAgency ForeignAgency { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual BankDetail TransferBank { get; set; }
        public virtual  Currency Currency { get; set; }
        public virtual FinancialPeriod FinancialPeriod { get; set; }
    }
}
