using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NajmetAlraqee.Data.Entities
{
    public class Contract : Base
    {
        [Key]
        public int Id { get; set; }
        public int? ContractTypeId { get; set; }
        public int? ContractStatusId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public string ContractDate { get; set; }
        public int? ContractYear { get; set; }
        public int? EmployeeNumber  { get; set; }
        public decimal? EmployeeCost { get; set; }
        public decimal VatCost { get; set; }
        public decimal  ContractCost { get; set; }
        public decimal? Remainder { get; set; }
        public decimal? Paid { get; set; }
        public decimal? Recieved { get; set; }
        public int? NationalityId { get; set; }
        public int? ArrivalCityId { get; set; }
        public string ContractNote  { get; set; }
        public int?  TestDay { get; set; }
        public string  ExperienceYear { get; set; }
        public int?  ContractInterVal { get; set; }
        public decimal? SalaryMonth { get; set; }
        public int?  VicationDays { get; set; }
        public string  QulaficationNote { get; set; }
        public int? JobTypeId { get; set; }
        public int? ForeignAgencyId { get; set; }
        public int?  OldContractNo { get; set; }

        public int? VisaNumber { get; set; }
        public string VisaDate { get; set; }
        public bool? IsDone { get; set; }
        public int?  LateDays { get; set; }
        public int? FinancialPeriodId { get; set; }

        public virtual ContractStatus ContractStatus { get; set; }
        public virtual ContractType ContractType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employees { get; set; }
        public virtual  City ArrivalCity { get; set; }
        public virtual ForeignAgency ForeignAgency { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual FinancialPeriod FinancialPeriod { get; set; }

    }
}
