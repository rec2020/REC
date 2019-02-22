using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class CurrencyViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "الرجاء الدخال اسم العملة")]
        public string Name { get; set; }

        [Required(ErrorMessage = "الرجاء الدخال رمز العملة")]
        public string Symbol { get; set; }

        [Required(ErrorMessage = "الرجاء الدخال معامل  التحويل")]
        public decimal? ExchangeRate { get; set; }
        public int? CurrencyTypeId { get; set; }

        public string CurrencyTypeName { get; set; }
    }
}
