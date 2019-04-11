using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class ContractSelectViewModel
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد تاريخ الاختيار")]
        public string SelectDate { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد رقم البولو ")]
        public int? PolNumer { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد تاريخ البولو ")]
        public string PolNumerDate { get; set; }
        [Required(ErrorMessage = "الرجاء تحديدالوكالة الخارجية")]
        public int? ForeignAgencyId { get; set; }
        public string ForeignAgencyName { get; set; }

        public string SelectById { get; set; }
        public string SelectByName { get; set; }

    }
}
