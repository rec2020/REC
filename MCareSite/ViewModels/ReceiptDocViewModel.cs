using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class ReceiptDocViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="الرجاء تحديد نوع السند ")]
        public int? ReceiptdocTypeId { get; set; }
        public string ReceiptdocTypeName { get; set; }
        public int? ContractId { get; set; }

        [Required(ErrorMessage = "الرجاءادخال العميل  ")]
        public int? CustomerId { get; set; }
        public string  CustomerName { get; set; }
        [Required(ErrorMessage = "الرجاءادخال المبلغ  ")]
        public decimal Amount { get; set; }
        public decimal VAT { get; set; }
        [Required(ErrorMessage = "الرجاءادخال ملاحظةعلي السند  ")]
        public string Note { get; set; }
        [Required(ErrorMessage = "الرجاءادخال تاريخ السند  ")]
        public string ReceiptDate { get; set; }
        public string ReceiptByUser { get; set; }
        public string ReceiptByUserName { get; set; }
    }
}
