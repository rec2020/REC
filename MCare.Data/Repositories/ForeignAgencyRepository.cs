using Microsoft.EntityFrameworkCore;
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
            return _context.ForeignAgencies.Include(x=>x.BankDetail).Include(x=>x.Currency).Include(x=>x.JobType).Include(x=>x.Nationality) ;
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

            _context.Update(existagency);
            _context.SaveChanges();
            return true;
        }
    }
}
