using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NajmetAlraqee.Data.Entities
{
    public class DoctorVacation
    {
        public long Id { get; set; }
        public long HospitalId { get; set; }
        public long DoctorId { get; set; }
        public long VacationStatusId { get; set; }
        public long VacationTypeId { get; set; }
        public DateTime StartingOn { get; set; }
        public DateTime EndingOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual VacationStatus VacationStatus { get; set; }
        public virtual VacationType VacationType { get; set; }
    }
}
