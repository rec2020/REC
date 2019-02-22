using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class DoctorScheduleViewModel
    {
        public long Id { get; set; }
        public long HospitalId { get; set; }
        public long DoctorId { get; set; }
        public string Time { get; set; }
        public long ScheduleStatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public ScheduleStatusViewModel ScheduleStatus { get; set; }
        public DateTime Date { get; internal set; }
    }
}
