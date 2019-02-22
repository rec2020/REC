using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class NationalityViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال الجنسية")]
        public string Name { get; set; }
    }
}
