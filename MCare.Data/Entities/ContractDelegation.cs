using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class ContractDelegation
    {
        [Key]
        public int Id { get; set; }

        public int? ContractId { get; set; }
        public int? ForeignAgencyId { get; set; }
        public string  DelegationDate { get; set; }
        public string DelegateById { get; set; }


        public virtual User DelegateBy { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual ForeignAgency ForeignAgency { get; set; }
    }
}
