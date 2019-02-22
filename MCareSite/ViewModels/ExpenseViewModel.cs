using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class ExpenseViewModel
    {

        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage ="الرجاء أدخال الكود ")]
        public int? Code { get; set; }
        [Required(ErrorMessage = "الرجاء أدخال المصروف ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "الرجاء أدخال رقم الحساب ")]
        public string AccountNumber { get; set; }
        [Required(ErrorMessage = "الرجاء أدخال كود الشريك ")]
        public string PartnerCode { get; set; }
    }
}
