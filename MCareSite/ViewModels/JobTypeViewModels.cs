using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class JobTypeViewModels
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="الرجاء أدخال الوظيفة ")]
        public string Name { get; set; }
    }
}
