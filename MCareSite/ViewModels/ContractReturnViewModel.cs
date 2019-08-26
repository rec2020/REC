using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class ContractReturnViewModel
    {

        public int Id { get; set; }
        public int? ContractId { get; set; }
        public int? ContractTypeId { get; set; }
        public string ContractTypeName { get; set; }
        public int? ReturnReasonId { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد تاريخ الرجوع")]
        public string EmployeeReturnDate { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد أسم الكفيل")]
        public string KafeelName { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد جوال الكفيل")]
        public string KafeelPhone { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد عنوان الكفيل")]
        public string KafeelAddress { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد تاريخ نقل الكفالة")]
        public string KfalaTranportDate { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد تاريخ الخروج النهائي")]
        public string ExitDate { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد زمن الخروج النهائي")]
        public string ExitTime { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد الخطوط الجوية")]
        public string AirLine { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد تاريخ الالغاء")]
        public string CancelDate { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد ملاحظات الالغاء")]
        public string CancelNote { get; set; }
        public string  CreatedById { get; set; }

    }
}
