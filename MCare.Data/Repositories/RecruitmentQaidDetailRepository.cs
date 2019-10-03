using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class RecruitmentQaidDetailRepository : IRecruitmentQaidDetailRepository
    {
        private NajmetAlraqeeContext _context;
        public RecruitmentQaidDetailRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        // GetAll
        public IQueryable<RecruitmentQaidDetail> GetRecruitmentQaidDetails()
        {
            return _context.RecruitmentQaidDetails.Include(x => x.AccountTree).
                Include(x => x.Type).Include(x => x.Qaid);
        }
        // GetById
        public RecruitmentQaidDetail GetRecruitmentQaidDetailById(int Id)
        {
            return _context.RecruitmentQaidDetails.Include(x=>x.AccountTree).
                Include(x=>x.Type).Include(x=>x.Qaid)
               .SingleOrDefault(p => p.Id == Id);
        }
        //  Add
        public int AddRecruitmentQaidDetail(RecruitmentQaidDetail del)
        {
            _context.RecruitmentQaidDetails.Add(del);
            _context.SaveChanges();
          
            //  Update In AccountTree 
            AccountTree existAcc =_context.AccountTrees.Where(x=>x.Id==del.AccountTreeId).SingleOrDefault();
            if (existAcc != null) { 
               
            if (del.TypeId == 1)
            {
                  existAcc.Credit = existAcc.Credit + del.Credit;
            }
            else { 
                  existAcc.Debit = existAcc.Debit +  del.Debit;
            }
            _context.Update(existAcc);
            _context.SaveChanges();
            }

            return del.Id;
        }
        // Update
        public bool UpdateRecruitmentQaidDetail(int Id, RecruitmentQaidDetail del)
        {
            RecruitmentQaidDetail existdetails = GetRecruitmentQaidDetailById(Id);
            if (existdetails == null)
                return false;
            existdetails.TypeId = del.TypeId;
            existdetails.Note = del.Note;
            existdetails.AccountTreeId = del.AccountTreeId;
            existdetails.Credit = del.Credit;
            existdetails.Debit = del.Debit;

            _context.Update(existdetails);
            _context.SaveChanges();

            return true;
        }
        // Remove
        public bool RemoveRecruitmentQaidDetail(int Id)
        {
            RecruitmentQaidDetail details = GetRecruitmentQaidDetailById(Id);
            if (details == null)
                return false;

            _context.Remove(details);
            _context.SaveChanges();

            return true;
        }
       
    }
}
