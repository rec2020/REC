using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NajmetAlraqee.Data.Entities
{
    public class DoctorScheduleConfiguration
    {
        public long Id { get; set; }
        public long HospitalId { get; set; }
        public long DoctorId { get; set; }
        public DateTime StartOn { get; set; }
        public DateTime EndOn { get; set; }
        public string MorningStartingTime { get; set; }
        public string MorningEndingTime { get; set; }
        public string EveningStartingTime { get; set; }
        public string EveningEndingTime { get; set; }
        public int PeroidInMintues { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
