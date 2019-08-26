using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class RecruitmentQaidViewModel
    {
        public int Id { get; set; }
        public string QaidDate { get; set; }
        [Required(ErrorMessage ="الرجاء ادخال من حساب ")]
        public int? FromAccountId { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال الي حساب ")]
        public int? ToAccountId { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال المبلغ ")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "الرجاء الملاحظة  ")]
        public string Note { get; set; }
    }
}
