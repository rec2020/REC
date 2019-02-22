using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajmetAlraqee.Data.Entities
{    
    public class DoctorEducationLevel
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public long EducationLevelId { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }
    }
}
