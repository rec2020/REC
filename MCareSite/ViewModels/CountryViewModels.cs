using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class CountryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Arabic Name.")]
        public string ArabicName { get; set; }
        [Required(ErrorMessage = "Please enter English Name.")]
        public string EnglishName { get; set; }
    }
}
