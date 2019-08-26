using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class FinancialPeriodViewModel
    {
        public int Id { get; set; }
        public int? Month { get; set; }
        public int Year { get; set; }
        public string FromData { get; set; }
        public string ToDate { get; set; }
        public int? FinancialPeriodStatusId { get; set; }
    }
}
