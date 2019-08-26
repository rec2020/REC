using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class ForeignAgencyJobViewModel
    {

        public int Id { get; set; }
        public int? NationalityId { get; set; }
        public bool? IsActive { get; set; }
        public int? JobTypeId { get; set; }
        public decimal? Price { get; set; }
        public int? CurrencyId { get; set; }
        public int? ForeignAgencyId { get; set; }

    }
}
