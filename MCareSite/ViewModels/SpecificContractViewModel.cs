using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class SpecificContractViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="الرجاء تحديد العميل ")]
        public int? CustomerId { get; set; }
        public int? ContractTypeId { get; set; }
        public int? SpecialEmployeeId { get; set; }
        public int? ForeignAgencyId { get; set; }
        //[Required(ErrorMessage = "الرجاء تحديد اسم الوكيل  ")]
        public string ForeignAgencyName { get; set; }
        //[Required(ErrorMessage = "الرجاء تحديد رخصة الوكيل  ")]
        public string LicenceNumber { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد قيمة العقد ")]
        public decimal ContractCost { get; set; }
        public decimal ContractInterVal { get; set; }
        public string ContractDate { get; set; }
        public decimal VAT { get; set; }
        public string DelegationDate { get; set; }
        public int? ContractStatusId { get; set; }
        public string QulaficationNote { get; set; }
        public string  CreatedByName { get; set; }
        public string CreatedById { get; set; }
        public int? CountryId { get; set; }
        [Required(ErrorMessage = "الرجاء تحديد المهنة   ")]
        public int? JobTypeId { get; set; }
        public decimal? Remainder { get; set; }
        public decimal? Paid { get; set; }
    }
}
