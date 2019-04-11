using NajmetAlraqee.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "الرجاء اختيار البلد")]
        public int? CountryId { get; set; }
        [Required(ErrorMessage = "الرجاء ادخال المدينة")]
        public string Name { get; set; }
        //public string CountryName { get; set; }
        public SelectList countries { get; set; }
        
    }
}
