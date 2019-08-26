using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class SnadReceiptViewModel
    {
        public int Id { get; set; }
        public int? SnadReceiptTypeId { get; set; }
        public int? ExpenseId { get; set; }
        public string SnadDate { get; set; }
        public int FinancialYear { get; set; }
        public int QuidNumber { get; set; }
        public decimal Amount { get; set; }
        public decimal VAT { get; set; }
        public int? PaymentMethodId { get; set; }
        public string SnadByUser { get; set; }
        public string SnadByUserName { get; set; }
        public string Note { get; set; }

    }
}
