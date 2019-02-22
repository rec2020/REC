using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajmetAlraqee.Data.Entities
{
    public class HospitalDoctor
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public long HospitalId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}
