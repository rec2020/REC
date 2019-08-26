using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IForeignAgencyJobRepository
    {
        int AddForeignAgencyJob(ForeignAgencyJob agencyjob);
        ForeignAgencyJob GetForeignAgencyJobById(int Id);
        IQueryable<ForeignAgencyJob> GetForeignAgencyJobs();
        bool RemoveForeignAgencyJob(int Id);
        bool UpdateForeignAgencyJob(int Id, ForeignAgencyJob agencyjob);
    }
}
