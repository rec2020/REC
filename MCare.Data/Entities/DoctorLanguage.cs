using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajmetAlraqee.Data.Entities
{
    public class DoctorLanguage
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public long LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
