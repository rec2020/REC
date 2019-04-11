using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class ContractViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد نوع العقد")]
        public int? ContractTypeId { get; set; }
        public string ContractTypeName { get; set; }
        public int? ContractStatusId { get; set; }

        [Required(ErrorMessage = "الرجاء تحديد المهنة")]
        public int? JobTypeId { get; set; }
        public string JobTypeName { get; set; }
        public string ContractStatusName { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد العميل")]
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد تاريخ العقد")]
        public string ContractDate { get; set; }
        public int? ContractYear { get; set; }
        public int? EmployeeNumber { get; set; }
        public decimal? EmployeeCost { get; set; }
        public decimal VatCost { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد قيمة العقد")]
        public decimal ContractCost { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد مدينة الوصول ")]
        public int? ArrivalCityId { get; set; }
        public string ArrivalCityName { get; set; }
        public string ContractNote { get; set; }
        public int? ForeignAgencyId { get; set; }
        public int? TestDay { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد سنوات الخبرة ")]
        public string ExperienceYear { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد فترة العقد ")]
        public int? ContractInterVal { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد الراتب الشهري ")]
        public decimal? SalaryMonth { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد فترة الاجازة ")]
        public int? VicationDays { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد الموهلات/المهارات ")]
        public string QulaficationNote { get; set; }

        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public int? ModifybyId { get; set; }
        public string CreationDate { get; set; }





    }
}
