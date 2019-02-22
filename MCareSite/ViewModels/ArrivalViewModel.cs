using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class ArrivalViewModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="الرجاء ادخال أسم جهة الوصول")]
        public string Name { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال بلد جهة الوصول")]
        public string Country { get; set; }
    }
}
