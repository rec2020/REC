using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class PatientAppointmentViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Please Insert Patient Name.")]
        public long PatientId { get; set; }
        [Required(ErrorMessage = "Please Insert Patient Name.")]
        public long DoctorScheduleId { get; set; }
        public long GenderId { get; set; }
        public string  GenderName { get; set; }
        public long AppointementStatusId { get; set; }
        public string AppointmentOn { get; set; }
        public DateTime CreatedOn { get; set; }

        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Insert Notes.")]
        public string Notes { get; set; }

        public bool CouldCancel { get; set; }

        public DoctorScheduleViewModel DoctorSchedule { get; set; }
        public AppointmentStatusViewModel AppointementStatus { get; set; }        
        public GenderViewModel Gender { get; set; }

        // doctor information
        public DoctorViewModel DoctorViewModel { get; set; }
    }

    public class AppointmentInputModel
    {
        [Required]
        public int DoctorScheduleId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public int GenderId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Notes { get; set; }
    }
}
