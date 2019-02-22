using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class JobTypeReository : IJobTypeReository
    {

        private NajmetAlraqeeContext _context;

        public JobTypeReository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public long AddJobType(JobType job)
        {
            _context.JobTypes.Add(job);
            _context.SaveChanges();

            return job.Id;
        }

        public JobType GetJobTypeById(long Id)
        {
            return _context.JobTypes
                .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<JobType> GetJobTypes()
        {
            return _context.JobTypes;
        }

        public bool RemoveJobType(long Id)
        {
            JobType jobtype = GetJobTypeById(Id);
            if (jobtype == null)
                return false;

            _context.Remove(jobtype);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateJobType(long Id, JobType job)
        {
            JobType existjob = GetJobTypeById(Id);
            if (existjob == null)
                return false;
            existjob.Name = job.Name;
            _context.Update(existjob);
            _context.SaveChanges();

            return true;
        }
    }
}
