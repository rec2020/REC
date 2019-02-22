using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajmetAlraqee.Data.Entities
{
    public class HospitalOffer
    {
        public long Id { get; set; }
        public long HospitalId { get; set; }
        public string ArabicTitle { get; set; }
        public string EnglishTitle { get; set; }
        public string ArabicBody { get; set; }
        public string EnglishBody { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? HappendOn { get; set; }
        public DateTime? EndOn { get; set; }
        public string ArabicImagePath { get; set; }
        public string EnglishImagePath { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}
