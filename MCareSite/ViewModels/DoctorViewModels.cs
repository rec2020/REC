using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class DoctorViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Please enter You User Name.")]
        public string UserId { get; set; }
        public string  UserName { get; set; }
        [Required(ErrorMessage = "Please enter The Hospital.")]
        public long HospitalId { get; set; }
        public string HospitalName { get; set; }
        [Required(ErrorMessage = "Your Gender is Required!.")]
        public long GenderId { get; set; }
        public string GenderName { get; set; }
        [Required(ErrorMessage = "Nationality is required!.")]
        public long NationalityId { get; set; }
        public string NationalityName { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        [Required(ErrorMessage = "Please enter Your name in Arabic.")]
        public string ArabicName { get; set; }
        [Required(ErrorMessage = "Please enter Your name in English.")]
        public string EnglishName { get; set; }
        [Required(ErrorMessage = "Please enter Your Bio in Arabic.")]
        public string ArabicBio { get; set; }
        [Required(ErrorMessage = "Please enter Your Bio in English.")]
        public string EnglishBio { get; set; }
        public string CVPath { get; set; }
        [Required(ErrorMessage = "Please put your CV!.")]
        public IFormFile CVPathFile { get; set; }
        //public string IdentityNo { get; set; }
        [Required(ErrorMessage = "Please enter Your Mobile Number.")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "Please enter Your Phone Number.")]
        public string PhoneNo { get; set; }
        public string PhoneExtension { get; set; }
        //public string CVPath { get; set; }
        public decimal Rate { get; set; }
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Please Insert Image.")]
        public IFormFile ImagePathFile { get; set; }
        [Required(ErrorMessage = "Please Enter Your Bitrh Date.")]
        public string BirthDate { get; set; }
        public string BirthDateString { get; set; }
        public string Experience { get; set; }
        public string ExperienceString { get; set; }
        public string IdentityNo { get; set; }

        // other fields
        public IEnumerable<LanguageViewModel> Languages { get; set; }
        public IEnumerable<EducationLevelViewModel> EducationLevels { get; set; }
        public IEnumerable<SpecialtyViewModel> Specialties { get; set; }        
        public IEnumerable<DoctorScheduleViewModel> Schedules { get; set; }

        // 
        public long? SpecialtyId { get; set; }
        public long? LanguageId { get; set; }
        public long? EducationlevelId { get; set; }

      

    }
}
