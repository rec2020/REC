using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class ContractDelegateViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد رقم العقد")]
        public int? ContractId { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد الوكالة")]
        public int? ForeignAgencyId { get; set; }
        public string ForeignAgencyName { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد تاريخ التفويض")]
        public string DelegationDate { get; set; }

        public string DelegateById { get; set; }
        public string DelegateByName { get; set; }
    }
}
