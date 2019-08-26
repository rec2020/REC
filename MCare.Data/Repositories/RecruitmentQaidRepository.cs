using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
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
            _context.RecruitmentQaids.Add(recruitmentQaid);
            _context.SaveChanges();
            return recruitmentQaid.Id;
        }
        public RecruitmentQaid GetRecruitmentQaidById(int Id)
        {
            return _context.RecruitmentQaids.Include(x => x.FromAccount).Include(x=>x.ToAccount)
                .SingleOrDefault(p => p.Id == Id);
        }
        public IQueryable<RecruitmentQaid> GetRecruitmentQaids()
        {
            return _context.RecruitmentQaids.Include(x => x.FromAccount).Include(x => x.ToAccount);
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
            existrecruitmentQaid.FromAccountId = recruitmentQaid.FromAccountId;
            existrecruitmentQaid.ToAccountId = recruitmentQaid.ToAccountId;
            existrecruitmentQaid.QaidDate = recruitmentQaid.QaidDate;
            existrecruitmentQaid.Amount = recruitmentQaid.Amount;
            existrecruitmentQaid.Note = recruitmentQaid.Note;

            _context.Update(existrecruitmentQaid);
            _context.SaveChanges();
            return true;
        }
    }
}
