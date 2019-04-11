using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class ContractHistory
    {
        [Key]
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int? ContractStatusId { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string ActionDate { get; set; }
        public int? ForeignAgencyId { get; set; }
        public string ForeignAgencyName { get; set; }
        public string ActionById { get; set; }
        public string ActionByName { get; set; }
        public int? ActionId { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }


        public virtual Contract Contract { get; set; }
        public virtual ContractStatus ContractStatus { get; set; }
        public virtual ContractAction Action { get; set; }
     
    }
}
