using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
   public interface IJobTypeReository
    {
        long AddJobType(JobType job);
        JobType GetJobTypeById(long Id);
        IQueryable<JobType> GetJobTypes();
        bool RemoveJobType(long Id);
        bool UpdateJobType(long Id, JobType job);
    }
}
