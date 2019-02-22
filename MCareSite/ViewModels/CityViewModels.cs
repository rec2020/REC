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
        public long Id { get; set; }
        [Required(ErrorMessage = "Please enter Country Name.")]
        public long? CountryId { get; set; }
        [Required(ErrorMessage = "Please enter Arabic Name.")]
        public string ArabicName { get; set; }
        [Required(ErrorMessage = "Please enter English Name.")]
        public string EnglishName { get; set; }
        public string CountryName { get; set; }
        public SelectList countries { get; set; }
        public CountryViewModel Country { get; set; }
    }
}
