using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
   public class Partner
    {
        [Key]
        public int Id { get; set; }
        public string  Name { get; set; }
        public decimal?   Percentage { get; set; }
        public decimal?  Deserved { get; set; }
        public decimal? Expenses { get; set; }
        public decimal?  Transfer { get; set; }
        public decimal? Remiander { get; set; }
    }
}
