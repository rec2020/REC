using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class ContractVisaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد رقم العقد")]
        public int ContractId { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد الموظف")]
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد تاريخ الفيزاء")]
        public string VisaDate { get; set; }
        public string VisaById { get; set; }
        public string VisaByName { get; set; }
    }
}
