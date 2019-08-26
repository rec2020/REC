using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public  class ForeignAgency
    {
        [Key]
        public int Id { get; set; }
        public int? OfficeNumber { get; set; }
        public string  OfficeName { get; set; }
        public string  AccountNumber { get; set; }
        public string  ResponsibleUser { get; set; }
        public string Email { get; set; }
        public string  Phone { get; set; }
        public int? BankDetailId { get; set; }
        public string BankAccountNo { get; set; }

        public decimal? DeservedAmount { get; set; }
        public decimal? RemainderAmount { get; set; }
        public decimal? TransferAmount { get; set; }
        public decimal? OpenBalance { get; set; }
        public decimal? CloseBalance { get; set; }




        public virtual  BankDetail BankDetail { get; set; }
        //public virtual Nationality Nationality { get; set; }
        //public virtual Currency Currency  { get; set; }
        //public virtual JobType JobType { get; set; }
       
    }
}
