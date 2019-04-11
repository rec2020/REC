using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class SpecialEmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PassportNo { get; set; }
        public int? NationalityId { get; set; }
        public string NationalityName { get; set; }
    }
}
