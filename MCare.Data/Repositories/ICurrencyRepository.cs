using NajmetAlraqee.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NajmetAlraqee.Data.Repositories
{
     public  interface ICurrencyRepository
    {
        IQueryable<Currency> GetCurrencies();
        Currency GetCurrencyById(int id);
        int AddCurrency(Currency currency);
        bool UpdateCurrency(int id, Currency currency);
        bool RemoveCurrency(int id);
    }
}
