using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class RecruitmentQaidStatusRepository : IRecruitmentQaidStatusRepository
    {

        private NajmetAlraqeeContext _context;

        public RecruitmentQaidStatusRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public IQueryable<RecruitmentQaidStatus> GetRecruitmentQaidStatus()
        {
            return _context.RecruitmentQaidStatuses;
        }

        public RecruitmentQaidStatus GetRecruitmentQaidStatusById(int id)
        {
            return _context.RecruitmentQaidStatuses.Find(id);
        }
    }
}
