using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class RecruitmentQaidDetail
    {
        public int Id { get; set; }

        public int? QaidId { get; set; }

        public int? TypeId { get; set; }

        public int? AccountTreeId { get; set; }

        public decimal?  Credit { get; set; }

        public decimal? Debit { get; set; }

        public string  Note  { get; set; }

        public virtual RecruitmentQaidDetailType Type { get; set; }

        public virtual RecruitmentQaid Qaid { get; set; }

        public virtual AccountTree AccountTree { get; set; }
    }
}
