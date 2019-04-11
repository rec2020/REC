using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class SpecificContract
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? SpecialEmployeeId { get; set; }
        public int? ForeignAgencyId { get; set; }
        public string ForeignAgencyName { get; set; }
        public string LicenceNumber { get; set; }
        public decimal ContractCost { get; set; }
        public decimal VAT { get; set; }
        public string DelegationDate { get; set; }
        public int? ContractStatusId { get; set; }



        public virtual Customer Customer { get; set; }
        public virtual SpecialEmployee SpecialEmployee { get; set; }
        public virtual ForeignAgency ForeignAgency { get; set; }
        public virtual ContractStatus ContractStatus { get; set; }
    }
}
