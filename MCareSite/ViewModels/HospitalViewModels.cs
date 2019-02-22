using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class HospitalViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Please enter Country name.")]
        public long? CountryId { get; set; }
        public string CountryName { get; set; }
        [Required(ErrorMessage = "Please enter City name.")]
        public long? CityId { get; set; }
        
        public string  cityName { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter English name.")]
        public string EnglishName { get; set; }
        [Required(ErrorMessage = "Please enter Arabic name.")]
        public string ArabicName { get; set; }
        public string Description { get; set; }
        public string ArabicDescription { get; set; }
        public string EnglishDescription { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter English Address.")]
        public string EnglishAddress { get; set; }
        [Required(ErrorMessage = "Please enter Arabic Address.")]
        public string ArabicAddress { get; set; }
        [Required(ErrorMessage = "Please enter Your Main Number.")]
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string MapLocation { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string LogoPath { get; set; }
        public IFormFile LogoPathFile { get; set; }
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Please Insert Image.")]
        public IFormFile ImagePathFile { get; set; }
        [Required(ErrorMessage = "Please enter Hospital Type.")]
        public long? HospitalTypeId { get; set; }
        public string  HospitalTypeName { get; set; }
       //public HospitalTypeViewModel HospitalType { get; set; }
        public CityViewModel City { get; set; }
        public CountryViewModel Country { get; set; }
    }
}
