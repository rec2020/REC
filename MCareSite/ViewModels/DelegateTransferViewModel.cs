using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class DelegateTransferViewModel
    {
        public int Id { get; set; }
        public string TransferDate { get; set; }
        public int? UserDelegateId { get; set; }
        public decimal Amount { get; set; }
        public int? CurrencyId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? TransferBankId { get; set; }
        public int? PurposeId { get; set; }
        public string Notes { get; set; }
    }
}
