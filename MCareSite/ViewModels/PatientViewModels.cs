using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class PatientViewModel
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string MobileNo { get; set; }
        public long GenderId { get; set; }
        public long NationalityId { get; set; }
        public string GenderName { get; set; }
        public string NationalityName { get; set; }

        public bool IsProfileUpdated { get; set; }

        public int OpenBookings { get; set; }
        public int CanceledBookings { get; set; }
        public int CompletedBookings { get; set; }
    }

    public class PatientUpdateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string BirthDate { get; set; }
        [Required]
        public int GenderId { get; set; }
        [Required]
        public long NationalityId { get; set; }
    }
}
