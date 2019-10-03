using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
   public  interface IRecruitmentQaidDetailTypeRepository
    {
        IQueryable<RecruitmentQaidDetailType> GetRecruitmentQaidDetailTypes();

        RecruitmentQaidDetailType GetRecruitmentQaidDetailTypeById(int id);
    }
}
