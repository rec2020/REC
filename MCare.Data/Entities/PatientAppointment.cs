using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajmetAlraqee.Data.Entities
{
    public class PatientAppointment
    {
        public long Id { get; set; }
        public long PatientId { get; set; }
        public long DoctorScheduleId { get; set; }
        public long AppointementStatusId { get; set; }
        public long GenderId { get; set; }
        public string AppointmentOn { get; set; }
        public DateTime CreatedOn { get; set; }

        public string FullName { get; set; }
        public string Mobile { get; set; }       
        public string Email { get; set; }
        public string Notes { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual DoctorSchedule DoctorSchedule { get; set; }
        public virtual AppointmentStatus AppointementStatus { get; set; }
    }
}
