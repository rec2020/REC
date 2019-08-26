using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class AccountTreeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage =" الرجاء ادخال رقم الحساب ")]
        public string AccountNo { get; set; }
        [Required(ErrorMessage = " الرجاء ادخال  الحساب ")]
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public int? AccountLevel { get; set; }
        [Required(ErrorMessage = " الرجاء تحديد تبويب الحساب ")]
        public int? AccClassificationId { get; set; }
        [Required(ErrorMessage = " الرجاء تحديد نوع  الحساب ")]
        public int? AccTypeId { get; set; }
        public string Accprev { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Balance { get; set; }
        public int? ParentId { get; set; }
        public decimal? PriceInExhibtion { get; set; }
        public decimal? HighLimitForBalance { get; set; }
        public int? EhalkPrecent { get; set; }
        public string FixedAssetDate { get; set; }
        public string JE { get; set; }
        public string CostCenter { get; set; }
    }
}
