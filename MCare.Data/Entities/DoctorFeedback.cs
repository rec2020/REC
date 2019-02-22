using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class DoctorFeedback
    {
        public long Id { get; set; }
        public long PatientId { get; set; }
        public long DoctorId { get; set; }        
        public string Body { get; set; }
        public double Rate { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
