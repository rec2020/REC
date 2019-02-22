using NajmetAlraqee.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class DoctorScheduleConfigurationViewModels
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Please Hospital Name.")]
        public long HospitalId { get; set; }
        public string HospitalName { get; set; }
        [Required(ErrorMessage = "Please Doctor Name.")]
        public long DoctorId { get; set; }
        public string DoctorName { get; set; }
        [Required(ErrorMessage = "Please enter Start on Date.")]
        public DateTime StartOn { get; set; }
        [Required(ErrorMessage = "Please Enter End on Date.")]
        public DateTime EndOn { get; set; }
        
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy t}", ApplyFormatInEditMode = true)]
        public DateTime? MorningStartingTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy t}", ApplyFormatInEditMode = true)]
        public DateTime? MorningEndingTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy t}", ApplyFormatInEditMode = true)]
        public DateTime? EveningStartingTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy t}", ApplyFormatInEditMode = true)]
        public DateTime? EveningEndingTime { get; set; }
        [Required(ErrorMessage = "Please Enter Period  in Mintues.")]
        public int PeroidInMintues { get; set; }
        public  HospitalViewModel Hospital { get; set; }
        public  DoctorViewModel Doctor { get; set; }
    }
}
