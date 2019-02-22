using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqeeSite.ViewModels
{
    public class AdminDashBoardViewModels
    {
        public Decimal? Doctors { get; set; }
        public Decimal? Hospitals { get; set; }
        public Decimal? HospitalTypes { get; set; }
        public Decimal? Specialties { get; set; }
        public Decimal? Countries { get; set; }
        public Decimal? Cities { get; set; }

        public Decimal? DoctorLanguages { get; set; }

        public Decimal? Patients { get; set; }
        public Decimal? PatientAppointments { get; set; }
        public Decimal? ConfirmAppointment { get; set; }

        public Decimal? CanceledAppointment { get; set; }


    }
    public class HospitalDashBoardViewModels
    {
        public Decimal? Doctors { get; set; }
      
      
        public Decimal? Specialties { get; set; }
        public Decimal? Countries { get; set; }
        public Decimal? Cities { get; set; }

        public Decimal? DoctorLanguages { get; set; }

        public Decimal? Patients { get; set; }
        public Decimal? PatientAppointments { get; set; }
        public Decimal? Offers { get; set; }


    }
}
