using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class ForeignAgencyTransferViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال تاريخ التحويل")]
        public string TransferDate { get; set; }
        public int? ForeignAgencyId { get; set; }

        [Required(ErrorMessage = "الرجاءادخال المبلغ")]
        public decimal Amount { get; set; }
        public int?  CurrencyId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? TransferBankId { get; set; }
        public int? PurposeId { get; set; }
        public string Notes { get; set; }
    }
}
