using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class FinancialPeriod
    {
        public int Id { get; set; }
        public int? Month { get; set; }
        public int Year { get; set; }
        public string FromData { get; set; }
        public string  ToDate { get; set; }
        public int? FinancialPeriodStatusId { get; set; }
        public virtual FinancialPeriodStatus FinancialPeriodStatus { get; set; }
    }
}
