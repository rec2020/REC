using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string IdentityNo { get; set; }
        public string FirstPhone { get; set; }
        public string SecondPhone { get; set; }
        public int TypeId { get; set; }
        public string IdentiyImage { get; set; }
        public string FamilyImage { get; set; }
        public bool IsActive { get; set; }
         public int UserDelegateId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public virtual CustomerType Type { get; set; }

        public virtual UserDelegate UserDelegate { get; set; }

    }
}
