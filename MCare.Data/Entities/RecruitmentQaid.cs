using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class RecruitmentQaid
    {
        public int Id { get; set; }
        public string QaidDate { get; set; }
        public int? FromAccountId { get; set; }
        public int? ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public virtual  AccountTree FromAccount { get; set;}
        public virtual AccountTree ToAccount { get; set; }
    }
}
