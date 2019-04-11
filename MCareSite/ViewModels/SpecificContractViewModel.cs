using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class SpecificContractViewModel
    {
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
    }
}
