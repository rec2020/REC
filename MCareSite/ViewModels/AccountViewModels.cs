using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class ResendOtpViewModel
    {       
        [Required(ErrorMessage = "MobileRequired")]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
    }

    public class OTPCode
    {
        [Required(ErrorMessage = "OTPRequired")]
        [Display(Name = "OTP")]
        public string OTP { get; set; }

        [Required(ErrorMessage = "MobileRequired")]
        [Display(Name = "Mobile")]
        public string Mobile { get; set; }
    }

    public class ChnagePasswordInputModel
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string NewPasswordConfirmation { get; set; }
    }


}
