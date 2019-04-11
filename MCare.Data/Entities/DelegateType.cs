using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class DelegateType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual UserDelegate UserDelegate { get; set; }
    }
}
