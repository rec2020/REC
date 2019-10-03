using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class ForeignAgencyViewModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="الرجاء ادخال رقم المكتب ")]
        public int? OfficeNumber { get; set; }
        //[Required(ErrorMessage = "الرجاء ادخال الجنسية ")]
        //public int? NationalityId { get; set; }
        //public string NationalityName { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال اسم المكتب ")]
        public string OfficeName { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال حساب الدليل")]
        public string AccountTreeId { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال المسؤول من المكتب ")]
        public string ResponsibleUser { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال الايميل ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال رقم الجوال ")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال البنك")]
        public int? BankDetailId { get; set; }
        //public string BankName { get; set; }
        //public string  BankAccountNo { get; set; }
        //public bool IsActive { get; set; }
        //[Required(ErrorMessage = "الرجاء ادخال الوظيفة ")]
        //public int? JobTypeId { get; set; }
        //public string JobTypeName { get; set; }
        //[Required(ErrorMessage = "الرجاء ادخال السعر")]
        //public decimal? Price { get; set; }
        //[Required(ErrorMessage = "الرجاء ادخال العملة ")]
        //public int? CurrencyId { get; set; }

        //public string CurrencyName { get; set; }
    }
}
