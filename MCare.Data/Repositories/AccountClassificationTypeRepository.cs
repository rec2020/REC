using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NajmetAlraqee.Data.Entities;

namespace NajmetAlraqee.Data.Repositories
{
    public class AccountClassificationTypeRepository : IAccountClassificationTypeRepository
    {

        private NajmetAlraqeeContext _context;

        public AccountClassificationTypeRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public AccountClassificationType GetAccountClassificationTypeById(int Id)
        {
            return _context.AccountClassificationTypes
              .SingleOrDefault(p => p.Id == Id);
        }

        public IQueryable<AccountClassificationType> GetAccountClassificationTypes()
        {
            return _context.AccountClassificationTypes;
        }

      
    }
}
