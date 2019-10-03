using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class RecruitmentQaidTypeRepository : IRecruitmentQaidTypeRepository
    {

        private NajmetAlraqeeContext _context;

        public RecruitmentQaidTypeRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public RecruitmentQaidType GetRecruitmentQaidTypesById(int id)
        {
            return _context.RecruitmentQaidTypes.Find(id);
        }

        public IQueryable<RecruitmentQaidType> GetRecruitmentQaidTypes()
        {
            return _context.RecruitmentQaidTypes;
        }
    }
}
