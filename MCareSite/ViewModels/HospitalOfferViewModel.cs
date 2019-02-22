using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class HospitalOfferViewModel
    {
        public long Id { get; set; }
        public long HospitalId { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter English Title.")]
        public string EnglishTitle { get; set; }
        [Required(ErrorMessage = "Please enter Arabic Title.")]
        public string ArabicTitle { get; set; }
        public string Body { get; set; }
        public string EnglishBody { get; set; }
        public string ArabicBody { get; set; }

        public string CreatedOn { get; set; }
        [Required(ErrorMessage = "Please enter Happend On Date.")]
        public DateTime HappendOn { get; set; }
        [Required(ErrorMessage = "Please enter End On Date.")]
        public DateTime EndOn { get; set; }
        public string ArabicImagePath { get; set; }
        [Required(ErrorMessage = "Please Insert Arabic Image.")]
        public IFormFile ArabicImagePathFile { get; set; }

        public string EnglishImagePath { get; set; }
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Please Insert English Image.")]
        public IFormFile EnglishImagePathFile { get; set; }
        public string HospitalName { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
    }
}
