using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Constants;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class RecruitmentQaidRepository : IRecruitmentQaidRepository
    {
        private NajmetAlraqeeContext _context;
        public RecruitmentQaidRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddRecruitmentQaid(RecruitmentQaid recruitmentQaid)
        {
            recruitmentQaid.StatusId = (int)EnumHelper.RecruitmentQaidStatus.Open;
            var getCurrentFinancialPeriod = _context.FinancialPeriods.Where(x => x.FinancialPeriodStatusId == (int)EnumHelper.FinancPeriodStatus.CURRENT).SingleOrDefault();
            if (getCurrentFinancialPeriod != null)
            {
                recruitmentQaid.FinancialPeriodId = getCurrentFinancialPeriod.Id;
            }
            _context.RecruitmentQaids.Add(recruitmentQaid);
            _context.SaveChanges();
            return recruitmentQaid.Id;
        }
        public RecruitmentQaid GetRecruitmentQaidById(int Id)
        {
            return _context.RecruitmentQaids.Include(x => x.FinancialPeriod).Include(x=>x.Type)
                .Include(x => x.Status)
                .SingleOrDefault(p => p.Id == Id);
        }
        public IQueryable<RecruitmentQaid> GetRecruitmentQaids()
        {
            return _context.RecruitmentQaids.Include(x => x.FinancialPeriod).Include(x => x.Type)
                .Include(x => x.Status);
        }
        public bool RemoveRecruitmentQaid(int Id)
        {
            RecruitmentQaid recruitmentQaid = GetRecruitmentQaidById(Id);
            if (recruitmentQaid == null)
                return false;
            _context.Remove(recruitmentQaid);
            _context.SaveChanges();
            return true;
        }
        public bool UpdateRecruitmentQaid(int Id, RecruitmentQaid recruitmentQaid)
        {
            RecruitmentQaid existrecruitmentQaid = GetRecruitmentQaidById(Id);
            if (existrecruitmentQaid == null)
                return false;
            existrecruitmentQaid.QaidDate = recruitmentQaid.QaidDate;
            existrecruitmentQaid.TypeId = recruitmentQaid.TypeId;

            _context.Update(existrecruitmentQaid);
            _context.SaveChanges();
            return true;
        }

        public bool CloseRecruitmentQaid(int Id, RecruitmentQaid recruitmentQaid)
        {
             var  CreditSum = _context.RecruitmentQaidDetails.Where(x => x.QaidId == recruitmentQaid.Id).Sum(x=>x.Credit);
             var  DebitSum = _context.RecruitmentQaidDetails.Where(x => x.QaidId == recruitmentQaid.Id).Sum(x => x.Debit);
            decimal reminder =1;
            if ( CreditSum > 0 && DebitSum > 0) { 
              reminder = (decimal)(CreditSum - DebitSum);
            }

            if (reminder ==0 ) { 
            RecruitmentQaid existrecruitmentQaid = GetRecruitmentQaidById(Id);
            if (existrecruitmentQaid == null)
                return false;
            existrecruitmentQaid.StatusId = (int)EnumHelper.RecruitmentQaidStatus.Close;

            _context.Update(existrecruitmentQaid);
            _context.SaveChanges();
            }
            return true;
        }
    }
}
