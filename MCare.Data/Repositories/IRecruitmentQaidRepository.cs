using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IRecruitmentQaidRepository
    {
        IQueryable<RecruitmentQaid> GetRecruitmentQaids();
        RecruitmentQaid GetRecruitmentQaidById(int Id);
        int AddRecruitmentQaid(RecruitmentQaid recruitmentQaid);
        bool UpdateRecruitmentQaid(int Id, RecruitmentQaid recruitmentQaid);
        bool RemoveRecruitmentQaid(int Id);
        bool CloseRecruitmentQaid(int Id, RecruitmentQaid recruitmentQaid);
    }
}
