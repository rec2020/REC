using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class ForeignAgencyJobRepository : IForeignAgencyJobRepository
    {

        private NajmetAlraqeeContext _context;

        public ForeignAgencyJobRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddForeignAgencyJob(ForeignAgencyJob agencyjob)
        {
            agencyjob.IsActive = true;
            _context.ForeignAgencyJobs.Add(agencyjob);
            _context.SaveChanges();
            return agencyjob.Id;
        }

        public ForeignAgencyJob GetForeignAgencyJobById(int Id)
        {
            return _context.ForeignAgencyJobs.Include(x => x.Currency).Include(x => x.JobType).Include(x=>x.Nationality)
                .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<ForeignAgencyJob> GetForeignAgencyJobs()
        {
            return _context.ForeignAgencyJobs.Include(x => x.Currency).Include(x => x.JobType).Include(x => x.Nationality);
        }

        public bool RemoveForeignAgencyJob(int Id)
        {
            ForeignAgencyJob agencyjob = GetForeignAgencyJobById(Id);
            if (agencyjob == null)
                return false;
            _context.Remove(agencyjob);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateForeignAgencyJob(int Id, ForeignAgencyJob agencyjob)
        {
            ForeignAgencyJob existagencyjob = GetForeignAgencyJobById(Id);
            if (existagencyjob == null)
                return false;
            existagencyjob.NationalityId = agencyjob.NationalityId;
            existagencyjob.IsActive = agencyjob.IsActive;
            existagencyjob.JobTypeId = agencyjob.JobTypeId;
            existagencyjob.Price = agencyjob.Price;


            _context.Update(existagencyjob);
            _context.SaveChanges();
            return true;
        }
    }
}
