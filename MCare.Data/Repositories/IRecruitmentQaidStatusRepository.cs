using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IRecruitmentQaidStatusRepository
    {

        IQueryable<RecruitmentQaidStatus> GetRecruitmentQaidStatus();
        RecruitmentQaidStatus GetRecruitmentQaidStatusById(int id);
    }
}
