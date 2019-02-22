using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajmetAlraqee.Data.Entities
{
    public class City
    {       
        public long Id { get; set; }
        public long CountryId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public virtual Country Country { get; set; }
    }
}
