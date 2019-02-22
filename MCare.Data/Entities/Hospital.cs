using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajmetAlraqee.Data.Entities
{
    public class Hospital
    {
        public long Id { get; set; }
        public long CountryId { get; set; }
        public long CityId { get; set; }
        public long HospitalTypeId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string ArabicDescription { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicAddress { get; set; }
        public string EnglishAddress { get; set; }
        public string MapLocation { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LogoPath { get; set; }
        public string ImagePath { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public virtual Country Country { get; set; }
        public virtual City City { get; set; }
        public virtual HospitalType HospitalType { get; set; }
    }
}
