using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class LoginInputModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginViewModel
    {
        public string Token { get; set; }
        public string Expiration { get; set; }
        public PatientViewModel PatientProfile { get; set; }
    }
}
