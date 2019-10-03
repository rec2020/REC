using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class RecruitmentQaid
    {
        public int Id { get; set; }

        public int? TypeId { get; set; }

        public string QaidDate { get; set; }

        public int? FinancialPeriodId { get; set; }

        public int? StatusId { get; set; }


        public virtual  FinancialPeriod FinancialPeriod { get; set; }

        public virtual RecruitmentQaidStatus Status { get; set; }

        public virtual RecruitmentQaidType Type { get; set; }


    }
}
