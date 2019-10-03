using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class DelegateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="الرجاء ادخال اسم المندوب")]
        public string Name { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال جنسية المندوب")]
        public int? NationalityId { get; set; }
        public string NationalityName { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال نوع المندوب")]
        public int? DelegateTypeId { get; set; }
        public string DelegateTypeName { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال قيمة العمولة")]
        public decimal? CommissionValue { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال نسبة العمولة")]
        public decimal? CommissionPrecentage { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال حساب الدليل")]
        public string AccountTreeId { get; set; }
        
        public decimal? DeservedAmount { get; set; }
        
        public decimal? RemainderAmount { get; set; }
       
        public decimal? TransferAmount { get; set; }

    }
}
