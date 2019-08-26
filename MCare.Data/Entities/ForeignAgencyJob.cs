using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
   public class ForeignAgencyJob
    {
        public int Id { get; set; }
        public int? NationalityId { get; set; }
        public bool? IsActive { get; set; }
        public int? JobTypeId { get; set; }
        public decimal? Price { get; set; }
        public int? CurrencyId { get; set; }
        public int? ForeignAgencyId { get; set; }

        public virtual ForeignAgency ForeignAgency { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual JobType JobType { get; set; }
    }
}
