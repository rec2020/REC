using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class User: IdentityUser
    {       
        public string Mobile { get; set; }        
        public bool MobileIsVerified { get; set; }
        public string OTP { get; set; }
    }
}
