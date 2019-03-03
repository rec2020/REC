using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class PartnerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="الرجاء ادخال اسم الشريك")]
        public string Name { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال النسبة ")]
        public decimal? Percentage { get; set; }
        [Required(ErrorMessage = " الرجاء ادخال المستحقات")]
        public decimal? Deserved { get; set; }
        [Required(ErrorMessage = "  الرجاء ادخال المصروفات")]
        public decimal? Expenses { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال المحول")]
        public decimal? Transfer { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال المتبقي")]
        public decimal? Remiander { get; set; }
    }
}
