using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
   public interface IRecruitmentQaidTypeRepository
    {
        IQueryable<RecruitmentQaidType> GetRecruitmentQaidTypes();

        RecruitmentQaidType GetRecruitmentQaidTypesById(int id);
    }
}
