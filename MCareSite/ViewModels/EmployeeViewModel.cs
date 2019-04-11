using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NajmetAlraqee.Site.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        //BASIC INFORMATION 
        [Required]
        public string FirstName { get; set; }
        public string Father { get; set; }
        public string GrandFather { get; set; }
        public string Family { get; set; }
        public int? FileNo { get; set; }
        public int? NationalityId { get; set; }
        public int? GenderId { get; set; }
        public int? ReligionId { get; set; }
        
        public string BirhtDate { get; set; }
        public int? Age { get; set; }
        public int? SocialStatusId { get; set; }
        public int? FamilyNo { get; set; }
        public int? NumberTime { get; set; }
     
        public string ContractDate { get; set; }
        public int? EmployeeStatusId { get; set; }
        // IDENTITY INFORMATION 
        public string PassportNo { get; set; }
        public string IssuePlace { get; set; }
        
        public string IssueDate { get; set; }
        
        public string ExpireDate { get; set; }
        public string IdentityNo { get; set; }
        public string IdentitySource { get; set; }
        public string IdentityIssueDate { get; set; }
        public string IdentityExpireDate { get; set; }
        public string VisaNo { get; set; }
        public string ArrivalDate { get; set; }
        public string BorderNo { get; set; }
        public string EntrancePort { get; set; }
        public int? KafeelNo { get; set; }
        public string KafeelName { get; set; }
        public int? NewKafeelNo { get; set; }
        public string NewKafeelName { get; set; }
        public string NewKafeelAddress { get; set; }
        public int? JobTypeId { get; set; }
        public int? DriverLicenseNo { get; set; }
        public string DriverLicenseIssueDate { get; set; }
        public string DriverLicenseExpireDate { get; set; }
        public int? LicenseNo { get; set; }
        public string LicenseExpireDate { get; set; }
        public string AddressInOrigin { get; set; }
        public string PhoneInOrigin { get; set; }

        // EMPLOYEEMENT & FINANCE INFORMATION 

        public decimal? BasicSalary { get; set; }
        public decimal? HousingAllowance { get; set; }
        public decimal? TransportationAllowance { get; set; }
        public decimal? FuelAllowance { get; set; }
        public decimal? Amountdeducted { get; set; }
        public decimal? Telephoneallowance { get; set; }
        public decimal? Subsistence { get; set; }
        public decimal? TotalSalary { get; set; }
        public int? ForeignAgencyId { get; set; }
        public int? GroupNo { get; set; }


        public string EmbassyContractDate { get; set; }
        public int? EmbassyContractNo { get; set; }

        public string NationalityName { get; set; }
        public string GenderName { get; set; }
        public string SocialStatusName { get; set; }
        public string EmployeeStatusName { get; set; }
        public string JobTypeName { get; set; }
        public string ForeignAgencyName { get; set; }
        public string ReligonName { get; set; }
    }
}
