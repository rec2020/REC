using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Symbol { get; set; }
        public decimal ExchangeRate {get; set; }
        public int? CurrencyTypeId { get; set; }
        public string CurrencyTypeName { get; set; }
        public virtual CurrencyType CurrencyType  { get; set; }
    }
}
