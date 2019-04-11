using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class ContractTicketViewModel
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        //[Required(ErrorMessage = "الرجاء تحديد الموظف")]
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد تاريخ الوصول")]
        public string ArrivalDate { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد تاريخ التذكرة")]
        public string TicketDate { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد تاريخ زمن الوصول")]
        public string Time { get; set; }
        public string Date { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد مدينة الوصول")]
        public string CityId { get; set; }
        public string CityName { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال خطوط الطيران")]
        public string AirLineName { get; set; }

        public string TicketById { get; set; }
        public string TicketByName { get; set; }
        public bool IsApproved { get; set; }
    }
}
