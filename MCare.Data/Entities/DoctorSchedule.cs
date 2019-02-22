using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajmetAlraqee.Data.Entities
{
    public class DoctorSchedule
    {
        public long Id { get; set; }
        public long HospitalId { get; set; }
        public long DoctorId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public long ScheduleStatusId { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Hospital Hospital { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual ScheduleStatus ScheduleStatus { get; set; }
    }
}
