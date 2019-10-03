using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class RecruitmentQaidDetailTypeRepository : IRecruitmentQaidDetailTypeRepository
    {

        private NajmetAlraqeeContext _context;

        public RecruitmentQaidDetailTypeRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public RecruitmentQaidDetailType GetRecruitmentQaidDetailTypeById(int id)
        {
            return _context.RecruitmentQaidDetailTypes.Find(id);
        }

        public IQueryable<RecruitmentQaidDetailType> GetRecruitmentQaidDetailTypes()
        {
            return _context.RecruitmentQaidDetailTypes;
        }
    }
}
