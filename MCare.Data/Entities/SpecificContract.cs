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
        public string  ContractDate { get; set; }
        public decimal ContractInterVal { get; set; }
        public string LicenceNumber { get; set; }
        public decimal ContractCost { get; set; }
        public decimal VAT { get; set; }
        public string DelegationDate { get; set; }
        public int? ContractStatusId { get; set; }
        public int?  CountryId { get; set; }
        public string QulaficationNote { get; set; }
        public int? JobTypeId { get; set; }
        public string CreatedById { get; set; }
        public int? ContractTypeId { get; set; }
         public decimal? Remainder { get; set; }
        public decimal? Paid { get; set; }


        public virtual ContractType ContractType { get; set; }
        public virtual Country Country { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual SpecialEmployee SpecialEmployee { get; set; }
        public virtual ForeignAgency ForeignAgency { get; set; }
        public virtual ContractStatus ContractStatus { get; set; }
    }
}
