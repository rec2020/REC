using NajmetAlraqee.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqeeSite.ViewModels
{
    public class DoctorVacationViewModel
    {
        public long Id { get; set; }
        public long HospitalId { get; set; }
        public string HospitalName { get; set; }
        public long DoctorId { get; set; }
        public long VacationStatusId { get; set; }
        public long VacationTypeId { get; set; }
        public DateTime StartingOn { get; set; }
        public DateTime EndingOn { get; set; }
        public DateTime CreatedOn { get; set; }
        //public  HospitalViewModel Hospital { get; set; }
        //public DoctorViewModel Doctor { get; set; }
        //public  VacationStatusViewModel VacationStatus { get; set; }
        //public  VacationTypeViewModel VacationType { get; set; }
    }
}
