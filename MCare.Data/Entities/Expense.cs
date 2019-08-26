using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public  class Expense
    {
        [Key]
        public int Id { get; set; }

        public int? Code { get; set; }

        public string  Name { get; set; }

        public string   AccountNumber { get; set; }

        //public string PartnerCode { get; set; }
    }
}
