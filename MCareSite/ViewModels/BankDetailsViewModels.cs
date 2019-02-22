using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class BankDetailViewModels
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="الرجاء أدخال البنك")]
        public string Name { get; set; }

        [Required(ErrorMessage = "الرجاء أدخال رقم الحساب")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "الرجاء أدخال حساب الدليل")]
        public string AccountNumberInTree { get; set; }
    }
}
