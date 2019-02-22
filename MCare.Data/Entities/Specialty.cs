using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajmetAlraqee.Data.Entities
{
    public class Specialty
    {
        public long Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
