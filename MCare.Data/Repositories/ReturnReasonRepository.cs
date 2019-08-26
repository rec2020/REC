using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class ReturnReasonRepository : IReturnReasonRepository
    {
        private NajmetAlraqeeContext _context;

        public ReturnReasonRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddReturnReason(ReturnReason reason)
        {
            _context.ReturnReasons.Add(reason);
            _context.SaveChanges();

            return reason.Id;
        }

        public ReturnReason GetReturnReasonById(int id)
        {
            return _context.ReturnReasons.Find(id);
        }

        public IQueryable<ReturnReason> GetReturnReasons()
        {
            return _context.ReturnReasons;
        }

        public bool RemoveReturnReason(int id)
        {
            var country = _context.Countries.SingleOrDefault(x => x.Id == id);
            if (country == null)
                return false;

            _context.Countries.Remove(country);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateReturnReason(int id, ReturnReason reason)
        {
            throw new NotImplementedException();
        }
    }
}
