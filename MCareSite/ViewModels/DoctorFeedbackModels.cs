using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class DoctorFeedbackInputModel
    {
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public double Rate { get; set; }
    }

    public class DoctorFeedbackViewModel
    {
        public long Id { get; set; }
        public long PatientId { get; set; }
        public long DoctorId { get; set; }
        public string Body { get; set; }
        public double Rate { get; set; }
        public string CreatedOn { get; set; }
        public string PatientName { get; set; }
    }
}
