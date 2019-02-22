using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
    public interface ICurrencyTypeRepository
    {
        IQueryable<CurrencyType> GetCurrencyTypes();
        CurrencyType GetCurrencyTypeById(int id);
        int AddCurrencyType(CurrencyType currency);
        bool UpdateCurrencyType(int id, CurrencyType currency);
        bool RemoveCurrencyType(int id);
    }
}
