using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IRecruitmentQaidDetailRepository
    {
        int AddRecruitmentQaidDetail(RecruitmentQaidDetail del);

        RecruitmentQaidDetail GetRecruitmentQaidDetailById(int Id);

        IQueryable<RecruitmentQaidDetail> GetRecruitmentQaidDetails();

        bool RemoveRecruitmentQaidDetail(int Id);

        bool UpdateRecruitmentQaidDetail(int Id, RecruitmentQaidDetail del);

       
    }
}
