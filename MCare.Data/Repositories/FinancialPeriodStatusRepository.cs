using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class FinancialPeriodStatusRepository : IFinancialPeriodStatusRepository
    {
        private NajmetAlraqeeContext _context;

        public FinancialPeriodStatusRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public IQueryable<FinancialPeriodStatus> GetFinancialPeriodStatus()
        {
            return _context.FinancialPeriodStatuses;
        }
        public FinancialPeriodStatus GetFinancialPeriodStatusById(int Id)
        {
            return _context.FinancialPeriodStatuses
               .SingleOrDefault(p => p.Id == Id);
        }
    }
}
