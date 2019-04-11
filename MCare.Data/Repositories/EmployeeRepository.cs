using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private NajmetAlraqeeContext _context;

        public EmployeeRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return employee.Id;
        }

        public Employee GetEmployeeById(int Id)
        {
            return _context.Employees.Include(x => x.EmployeeStatus).Include(x => x.ForeignAgency)
                .Include(x => x.Gender).Include(x => x.JobType).Include(x => x.Nationality)
                .Include(x => x.Religion).Include(x => x.SocialStatus)
                 .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<Employee> GetEmployees()
        {
            return _context.Employees.Include(x=>x.EmployeeStatus).Include(x=>x.ForeignAgency)
                .Include(x => x.Gender).Include(x => x.JobType).Include(x => x.Nationality)
                .Include(x => x.Religion).Include(x=>x.SocialStatus);
        }

        public bool RemoveEmployee(int Id)
        {
            Employee employee = GetEmployeeById(Id);
            if (employee == null)
                return false;

            _context.Remove(employee);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateEmployee(int Id, Employee emp)
        {
            Employee existEmployee = GetEmployeeById(Id);
            if (existEmployee == null)
                return false;
            existEmployee.FirstName = emp.FirstName;
            existEmployee.AddressInOrigin = emp.AddressInOrigin;
            existEmployee.Age = emp.Age;
            existEmployee.Amountdeducted = emp.Amountdeducted;
            existEmployee.ArrivalDate = emp.ArrivalDate;
            existEmployee.BasicSalary = emp.BasicSalary;
            existEmployee.BirhtDate = emp.BirhtDate;
            existEmployee.BorderNo = emp.BorderNo;
            existEmployee.ContractDate = emp.ContractDate;
            existEmployee.DriverLicenseExpireDate = emp.DriverLicenseExpireDate;


            existEmployee.DriverLicenseIssueDate = emp.DriverLicenseIssueDate;
            existEmployee.DriverLicenseNo = emp.DriverLicenseNo;
            existEmployee.EmbassyContractDate = emp.EmbassyContractDate;
            existEmployee.EmbassyContractNo = emp.EmbassyContractNo;
            
            existEmployee.EntrancePort = emp.EntrancePort;
            existEmployee.ExpireDate = emp.ExpireDate;
            existEmployee.Family = emp.Family;
            existEmployee.FamilyNo = emp.FamilyNo;
            existEmployee.Father = emp.Father;
            existEmployee.FileNo = emp.FileNo;
            existEmployee.FirstName = emp.FirstName;



            existEmployee.FuelAllowance = emp.FuelAllowance;
            existEmployee.GenderId = emp.GenderId;
            existEmployee.GrandFather = emp.GrandFather;
            existEmployee.GroupNo = emp.GroupNo;
            existEmployee.HousingAllowance = emp.HousingAllowance;
            existEmployee.IdentityExpireDate = emp.IdentityExpireDate;
            existEmployee.IdentityIssueDate = emp.IdentityIssueDate;
            existEmployee.IdentityNo = emp.IdentityNo;
            existEmployee.IdentitySource = emp.IdentitySource;
            existEmployee.IssueDate = emp.IssueDate;


            existEmployee.IssuePlace = emp.IssuePlace;
            existEmployee.JobTypeId = emp.JobTypeId;
            existEmployee.KafeelName = emp.KafeelName;
            existEmployee.KafeelNo = emp.KafeelNo;
            existEmployee.LicenseExpireDate = emp.LicenseExpireDate;
            existEmployee.LicenseNo = emp.LicenseNo;
            existEmployee.NationalityId = emp.NationalityId;
            existEmployee.NewKafeelAddress = emp.NewKafeelAddress;
            existEmployee.NewKafeelName = emp.NewKafeelName;
            existEmployee.NewKafeelNo = emp.NewKafeelNo;

            existEmployee.NumberTime = emp.NumberTime;
            existEmployee.PassportNo = emp.PassportNo;
            existEmployee.PhonrInOrigin = emp.PhonrInOrigin;
            existEmployee.ReligionId = emp.ReligionId;
            existEmployee.SocialStatusId = emp.SocialStatusId;
            existEmployee.Subsistence = emp.Subsistence;

            existEmployee.Telephoneallowance = emp.Telephoneallowance;
            existEmployee.TotalSalary = emp.TotalSalary;
            existEmployee.TransportationAllowance = emp.TransportationAllowance;
            existEmployee.VisaNo = emp.VisaNo;
            existEmployee.PhonrInOrigin = emp.PhonrInOrigin;

            _context.Update(existEmployee);
            _context.SaveChanges();

            return true;
        }
    }
}
