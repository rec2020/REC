using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
   public  class ForeignAgent
    {
        [Key]
        public int Id { get; set; }

        public string  Name { get; set; }

        public int JobTypeId { get; set; }
       
        public int Price { get; set; }

        public int StatusId { get; set; }

        public int CurrencyId { get; set; }

        public virtual JobType JobType { get; set; }

        public virtual ForeignAgentStatus Status  { get; set; }
    }
}
