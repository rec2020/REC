using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class ContractSelect
    {
        [Key]
        public int Id { get; set; }
        public int ContractId { get; set; }
      
        public string SelectDate { get; set; }
        public int?  PolNumer { get; set; }
        public string PolNumerDate { get; set; }
        public int? ForeignAgencyId { get; set; }
        public string SelectById { get; set; }

        public virtual User SelectBy { get; set; }
        public virtual  Contract Contract { get; set; }
        public virtual ForeignAgency ForeignAgency { get; set; }
        
    }
}
