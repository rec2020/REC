using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class CustomerViewModel
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string IdentityNo { get; set; }
        public string FirstPhone { get; set; }
        public string SecondPhone { get; set; }
        public int TypeId { get; set; }
        public string IdentiyImage { get; set; }
        public IFormFile IdentiyImageFile { get; set; }
        public string FamilyImage { get; set; }
        public IFormFile FamilyImageFile { get; set; }
        public bool IsActive { get; set; }
        public int DelegateId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
    }
}
