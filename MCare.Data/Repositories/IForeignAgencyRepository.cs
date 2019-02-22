using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IForeignAgencyRepository
    {

        int AddAgency(ForeignAgency agency);
        ForeignAgency GetAgencyById(int Id);
        IQueryable<ForeignAgency> GetAgencies();
        bool RemoveAggency(int Id);
        bool UpdateAgency(int Id, ForeignAgency agency);
    }
}
