using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
   public class SnadReceiptTypeRepository : ISnadReceiptTypeRepository
    {

        private NajmetAlraqeeContext _context;

        public SnadReceiptTypeRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        

        public SnadReceiptType GetSnadReceiptTypeById(int id)
        {
            return _context.SnadReceiptTypes.Find(id);
        }

        public IQueryable<SnadReceiptType> GetSnadReceiptTypes()
        {
            return _context.SnadReceiptTypes;
        }
      
    }
}
