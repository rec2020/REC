using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال تاريخ الفانورة")]
        public string InvoiceDate { get; set; }
        [Required(ErrorMessage ="الرجاء ادخال الملاحظة")]
        public string Note { get; set; }
        public int? ContractNo { get; set; }
        public decimal Amount { get; set; }
        public string Customer { get; set; } // 
        [Required(ErrorMessage = "الرجاء ادخال الخصم")]
        public decimal Discount { get; set; }// 
        public decimal VatPercentage { get; set; }// 
        public decimal VatValue { get; set; }// 
        public decimal Total { get; set; }//
    }
}
