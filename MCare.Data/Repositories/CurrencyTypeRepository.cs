using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public class CurrencyTypeRepository : ICurrencyTypeRepository
    {

        private NajmetAlraqeeContext _context;

        public CurrencyTypeRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }
        public int AddCurrencyType(CurrencyType currency)
        {
            throw new NotImplementedException();
        }

        public CurrencyType GetCurrencyTypeById(int id)
        {
            return _context.CurrencyTypes.Find(id);
        }

        public IQueryable<CurrencyType> GetCurrencyTypes()
        {
            return _context.CurrencyTypes;
        }

        public bool RemoveCurrencyType(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCurrencyType(int id, CurrencyType currency)
        {
            throw new NotImplementedException();
        }
    }
}
