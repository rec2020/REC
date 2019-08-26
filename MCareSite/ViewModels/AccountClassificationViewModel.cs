using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class AccountClassificationViewModel
    {
        public int Id { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public int? TypeId { get; set; }
    }
}
