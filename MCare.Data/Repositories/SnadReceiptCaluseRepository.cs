using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class SnadReceiptCaluseRepository : ISnadReceiptCaluseRepository
    {

        private NajmetAlraqeeContext _context;

        public SnadReceiptCaluseRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public SnadReceiptCaluse GetSnadReceiptCaluseById(int id)
        {
            return _context.SnadReceiptCaluses.Find(id);
        }

        public IQueryable<SnadReceiptCaluse> GetSnadReceiptCaluses()
        {
            return _context.SnadReceiptCaluses;
        }
    }
}
