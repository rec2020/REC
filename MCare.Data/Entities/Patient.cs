using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class Patient
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public long GenderId { get; set; }
        public long NationalityId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string BirthDate { get; set; }
        public virtual User User { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Nationality Nationality { get; set; }        
    }
}
