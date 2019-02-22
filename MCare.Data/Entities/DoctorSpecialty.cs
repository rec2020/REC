using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajmetAlraqee.Data.Entities
{
    public class DoctorSpecialty
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public long SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; }
    }
}
