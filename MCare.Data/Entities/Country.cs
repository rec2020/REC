using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajmetAlraqee.Data.Entities
{
    public class Country
    {    
        public long Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
    }
}
