using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class ContractVisa
    {
        [Key]
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int? EmployeeId { get; set; }
        public string VisaDate { get; set; }
        public string VisaById { get; set; }


        public virtual Contract Contract { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User VisaBy { get; set; }
    }
}
