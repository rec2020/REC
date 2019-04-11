using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class JobType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual ForeignAgency ForeignAgency { get; set; }
        //public virtual Employee Employee { get; set; }
        //public virtual Contract Contract { get; set; }


    }
}
