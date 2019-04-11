using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class CountryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال اسم البلد")]
        public string Name { get; set; }
        
      
       
    }
}
