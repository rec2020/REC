using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajmetAlraqee.Data.Entities
{
    public class Doctor
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public long GenderId { get; set; }
        public long NationalityId { get; set; }
        public long HospitalId { get; set; }

        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string ArabicBio { get; set; }
        public string EnglishBio { get; set; }
        public string IdentityNo { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public string PhoneExtension { get; set; }
        public string ArabicCVPath { get; set; }
        public string EnglishCVPath { get; set; }
        public decimal Rate { get; set; }
        public string ImagePath { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime Experience { get; set; }

        public virtual User User { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Nationality Nationality { get; set; }

        public virtual IEnumerable<DoctorSpecialty> DoctorSpecialtys { get; set; }
        public virtual IEnumerable<DoctorEducationLevel> DoctorEducationLevels { get; set; }
        public virtual IEnumerable<DoctorLanguage> DoctorLanguages { get; set; }
        public virtual IEnumerable<DoctorSchedule> DoctorSchedules { get; set; }
    }
}
