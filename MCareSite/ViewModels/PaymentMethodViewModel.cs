using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class PaymentMethodViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال طريقة الدفع ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال حساب الدليل ")]
        public string TreeAccountNo { get; set; }
    }
}
