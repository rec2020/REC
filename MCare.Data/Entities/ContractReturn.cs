using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class ContractReturn
    {
        [Key]
        public int Id { get; set; }
        public int? ContractId { get; set; }
        public int? ContractTypeId { get; set; }
        public int? ReturnReasonId { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeReturnDate  { get; set; }
        public string  KafeelName { get; set; }
        public string KafeelPhone { get; set; }
        public string KafeelAddress{ get; set; }
        public string  KfalaTranportDate { get; set; }
        public string  ExitDate { get; set; }
        public string ExitTime { get; set; }
        public string  AirLine { get; set; }
        public string  CancelDate { get; set; }
        public string CancelNote { get; set; }
        public string CreatedById { get; set; }

        public virtual  ReturnReason ReturnReason { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual ContractType ContractType { get; set; }
        public virtual  Employee Employee { get; set; }
    }
}
