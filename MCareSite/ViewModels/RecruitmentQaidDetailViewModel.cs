using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class RecruitmentQaidDetailViewModel
    {
        public int Id { get; set; }

        public int? QaidId { get; set; }

        [Required(ErrorMessage =" الرجاء تحديد نوع بند القيد")]
        public int? TypeId { get; set; }

        [Required(ErrorMessage = " الرجاء تحديد الحساب ")]
        public int? AccountTreeId { get; set; }

        public decimal? Credit { get; set; }

        public decimal? Debit { get; set; }

        [Required(ErrorMessage = " الرجاءادخال الملاحظة")]
        public string Note { get; set; }
    }
}
