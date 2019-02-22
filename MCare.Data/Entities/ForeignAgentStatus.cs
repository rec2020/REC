using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
     public  class ForeignAgentStatus
    { 
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
