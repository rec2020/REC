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
        //public virtual ContractSelect ContractSelect { get; set; }
        //public virtual ContractDelegation ContractDelegation { get; set; }
        //public virtual ContractVisa ContractVisa { get; set; }
        //public virtual ContractTicket ContractTicket { get; set; }
    }
}
