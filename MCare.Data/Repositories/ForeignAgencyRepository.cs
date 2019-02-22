using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class ForeignAgencyRepository : IForeignAgencyRepository
    {

        private NajmetAlraqeeContext _context;

        public ForeignAgencyRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddAgency(ForeignAgency agency)
        {
            var bankinfo = _context.BankDetails.SingleOrDefault(x => x.Id == agency.BankDetailId);
            if (bankinfo != null)
            {
                agency.BankName = bankinfo.Name;
                agency.BankAccountNo = bankinfo.AccountNumber;
            }
            var currencyinfo = _context.Currencies.SingleOrDefault(x => x.Id == agency.CurrencyId);
            if (currencyinfo!=null) { agency.CurrencyName = currencyinfo.Name; }

            var jobinfo = _context.JobTypes.SingleOrDefault(x => x.Id == agency.JobTypeId);
            if (jobinfo != null) { agency.JobTypeName = jobinfo.Name; }

            var nationalityinfo = _context.Nationalities.SingleOrDefault(x => x.Id == agency.NationalityId);
            if (nationalityinfo != null) { agency.NationalityName = nationalityinfo.Name; }
            agency.IsActive = true;
            _context.ForeignAgencies.Add(agency);
            _context.SaveChanges();
            return agency.Id;
        }
        public ForeignAgency GetAgencyById(int Id)
        {
            return _context.ForeignAgencies
                .SingleOrDefault(p => p.Id == Id);
        }
        public IQueryable<ForeignAgency> GetAgencies()
        {
            return _context.ForeignAgencies;
        }
        public bool RemoveAggency(int Id)
        {
            ForeignAgency agency = GetAgencyById(Id);
            if (agency == null)
                return false;
            _context.Remove(agency);
            _context.SaveChanges();
            return true;
        }
        public bool UpdateAgency(int Id, ForeignAgency agency)
        {
            ForeignAgency existagency = GetAgencyById(Id);
            if (existagency == null)
                return false;
            existagency.OfficeName = agency.OfficeName;
            existagency.NationalityId = agency.NationalityId;
            existagency.BankDetailId = agency.BankDetailId;
            existagency.AccountNumber = agency.AccountNumber;
            existagency.Email = agency.Email;
            existagency.IsActive = agency.IsActive;
            existagency.JobTypeId = agency.JobTypeId;
            existagency.OfficeNumber = agency.OfficeNumber;
            existagency.Phone = agency.Phone;
            existagency.Price = agency.Price;
            existagency.ResponsibleUser = agency.ResponsibleUser;
            
            var bankinfo = _context.BankDetails.SingleOrDefault(x => x.Id == agency.BankDetailId);
            if (bankinfo != null)
            {
                existagency.BankName = bankinfo.Name;
                existagency.BankAccountNo = bankinfo.AccountNumber;
            }
            var currencyinfo = _context.Currencies.SingleOrDefault(x => x.Id == agency.CurrencyId);
            if (currencyinfo != null) { existagency.CurrencyName = currencyinfo.Name; }

            var jobinfo = _context.JobTypes.SingleOrDefault(x => x.Id == agency.JobTypeId);
            if (jobinfo != null) { existagency.JobTypeName = jobinfo.Name; }

            var nationalityinfo = _context.Nationalities.SingleOrDefault(x => x.Id == agency.NationalityId);
            if (nationalityinfo != null) { existagency.NationalityName = nationalityinfo.Name; }


            _context.Update(existagency);
            _context.SaveChanges();
            return true;
        }
    }
}
