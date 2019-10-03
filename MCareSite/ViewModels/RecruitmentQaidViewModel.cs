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

        [Required(ErrorMessage = "الرجاء ادخال تاريخ القيد ")]
        public string QaidDate { get; set; }

        [Required(ErrorMessage = "الرجاء ادخال نوع القيد ")]
        public int? TypeId { get; set; }

        public int? FinancialPeriodId { get; set; }

        public int? StatusId { get; set; }
    }
}
