using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class ContractTicket
    {
        [Key]
        public int Id { get; set; }

        public int ContractId { get; set; }
        public int? EmployeeId { get; set; }
        public string ArrivalDate { get; set; }
        public string TicketDate { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public int? CityId { get; set; }
        public string AirLineName { get; set; }
        public string TicketById { get; set; }
        public bool  IsApproved { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual City City { get; set; }
        public virtual User TicketBy { get; set; }
    }
}
